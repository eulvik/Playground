using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesterApp.ServiceReference1;

namespace TesterApp
{
	class Program
	{
		static void Main(string[] args)
		{
			IStorageService sr = new StorageServiceClient();
			Console.WriteLine("Performing get stuff");
			Console.WriteLine("Result: {0}", sr.GetString("hello"));
			Console.ReadLine();
		}
	}
}
