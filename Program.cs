using System;
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

			var t1 = new Task(() => {
				Console.Write("Task 1 start");
				PrintCurrentThread();
				Thread.Sleep(1000);
				Console.Write("Task 1 end");
				PrintCurrentThread();
			});
			t1.Start();

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey(true);
		}

		/// <summary>
		/// Выводит в текущую строку консоли номер потока.
		/// </summary>
		public static void PrintCurrentThread() {
			string tStr = new string($"(thread {Thread.CurrentThread.ManagedThreadId:D2})");
			Console.CursorLeft = Console.WindowWidth - tStr.Length;
			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Console.WriteLine(tStr);
			Console.ResetColor();
		}
	}

}
