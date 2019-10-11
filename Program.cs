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
			var t1 = new Task(() => {
				Console.WriteLine("Task 1 start");
				Thread.Sleep(1000);
				Console.WriteLine("Task 1 end");
			});
			t1.Start();

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey(true);
		}
	}

}
