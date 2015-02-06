using System;
using System.AddIn;
using MixedModeBridge;
using ServiceLoaderAddInView;

namespace MixedModeAddIn
{
	[AddIn("Service1 loader", Version = "0.0.0.1")]
	public class MixedModeAddIn : IServiceLoader
	{
		private Class1 _mixedModeInterface;

		public bool LoadService()
		{
			_mixedModeInterface = new Class1();
			Console.WriteLine("LoadService: {0}", _mixedModeInterface.GetHello());
			return true;
		}

		public bool StopService()
		{
			Console.WriteLine("StopService: {0}", _mixedModeInterface.GetHello());
			return true;
		}

		public bool StartService()
		{
			Console.WriteLine("StartService: {0}", _mixedModeInterface.GetHello());
			return true;
		}

		public bool RestartService()
		{
			Console.WriteLine("RestartService: {0}", _mixedModeInterface.GetHello());
			return true;
		}
    }
}
