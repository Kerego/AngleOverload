using System;

namespace SharpOverload
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var a = new Angle(203, 53, 54);
			var b = new Angle(156, 44, 6);

			Console.WriteLine(a);
			Console.WriteLine(b);
			Console.WriteLine(a + b);

			Console.Read();
		}
	}
	
}
