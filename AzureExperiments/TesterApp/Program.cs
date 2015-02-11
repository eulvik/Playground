using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesterApp
{
	class Program
	{
		static void Main(string[] args)
		{
			ServiceReference1.IStorageService sr = new ServiceReference1.StorageServiceClient();
			Console.WriteLine("Performing get stuff");
			Console.WriteLine("Result: {0}", sr.GetString("hello"));
			Console.ReadLine();
		}
	}
}
