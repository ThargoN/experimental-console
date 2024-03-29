﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

//---------------------------------------------------------------------------
// Experimental console
//
// Проект для проведения различных экспериментов, т.к. язык сильно подзабыл.
// Так же буду приучаться комментарии писать только на русском - такова 
// специфика текущей работы.
//
// Так же здесь будут обкатываться разные техники работы с Git - опять же, 
// с целью набивания шише и получения XP. Качаем скилл [г@вно]кодинга.
//---------------------------------------------------------------------------

namespace Thargon.Experimental_console {

	class Program {
		static void Main() {
			Console.WriteLine("Starting console");
			PrintCurrentThread();

			Task.Factory.StartNew(() => DoJob(1, 2500));
			Task.Factory.StartNew(() => DoJob(2, 750));
			Task.Factory.StartNew(() => DoJob(3, 3000));
			Task.Factory.StartNew(() => DoJob(4, 2500));
			Task.Factory.StartNew(() => DoJob(5, 1000));

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey(true);
		}

		static readonly object _mtLock = new object();

		private static void DoJob(int id, int timeToWork) {
			lock (_mtLock) {
				Console.WriteLine($"Task {id} start");
				PrintCurrentThread();
			}

			Thread.Sleep(timeToWork);

			lock (_mtLock) {
				Console.WriteLine($"Task {id} end");
				PrintCurrentThread();
			}
		}
						
		/// <summary>
		/// Выводит в предыдущую строку консоли номер потока.
		/// </summary>
		public static void PrintCurrentThread() {
			string tStr = new string($"(thread {Thread.CurrentThread.ManagedThreadId:D2})");
			Console.SetCursorPosition(Console.WindowWidth - tStr.Length, Math.Max(Console.CursorTop - 1, 0));
			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Console.WriteLine(tStr);
			Console.ResetColor();
		}
	}

}
