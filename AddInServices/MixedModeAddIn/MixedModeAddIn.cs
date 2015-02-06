using System;
using System.AddIn;
using System.IO;
using log4net;
using MixedModeBridge;
using ServiceLoaderAddInView;

namespace MixedModeAddIn
{
	[AddIn("Service1 loader", Version = "0.0.0.1")]
	public class MixedModeAddIn : IServiceLoader
	{
		private ILog _log = LogManager.GetLogger(typeof (MixedModeAddIn));

		private Class1 _mixedModeInterface;

		public MixedModeAddIn()
		{
			log4net.Config.XmlConfigurator.Configure();
		}
		public bool LoadService()
		{
			_mixedModeInterface = new Class1();
			_log.DebugFormat("LoadService: {0}", _mixedModeInterface.GetHello());
			return true;
		}

		public bool StopService()
		{
			_log.DebugFormat("StopService: {0}", _mixedModeInterface.GetHello());
			return true;
		}

		public bool StartService()
		{
			_log.DebugFormat("StartService: {0}", _mixedModeInterface.GetHello());
			return true;
		}

		public bool RestartService()
		{
			_log.DebugFormat("RestartService: {0}", _mixedModeInterface.GetHello());
			return true;
		}
    }
}
