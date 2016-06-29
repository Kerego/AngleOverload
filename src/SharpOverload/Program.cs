using System;
using System.Diagnostics;

namespace SharpOverload
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var a = new Angle(205, 44, 12);
			var b = new Angle(204, 44, 12);

			Console.WriteLine($"a = {a}");
			Console.WriteLine($"b = {b}");
			Console.WriteLine($"a + b = {a + b}");
			Console.WriteLine($"a - b = {a - b}");
			Console.WriteLine($"a > b = {a > b}");
			Console.WriteLine($"a < b = {a < b}");
			Console.WriteLine($"a == b : {a == b}");

			//checks perfs
			Stopwatch watch = Stopwatch.StartNew();

			for (int i = 0; i < 100000000; i++)
			{
				var aGreaterThanB = a > b;
			}

			watch.Stop();
			Console.WriteLine(watch.ElapsedMilliseconds);


			Console.Read();
		}
	}
	
}
