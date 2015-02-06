using System;
using MixedModeBridge;

namespace MixedModeTest
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Class1 bridge = new Class1();
			Console.WriteLine("Hello called: {0}", bridge.GetHello());
			Console.ReadLine();
		}
	}
}