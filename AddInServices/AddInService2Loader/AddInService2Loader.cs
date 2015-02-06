using System;
using System.AddIn;
using System.ServiceModel;
using ServiceLoaderAddInView;

namespace AddInService2Loader
{
    [AddIn("Service2 loader", Version = "0.0.0.1")]
    public class AddInService2Loader : IServiceLoader
    {
        private ServiceHost _service2Host;

        public bool LoadService()
        {
            Console.WriteLine("LoadService2 " + AppDomain.CurrentDomain.FriendlyName);
            try
            {
                _service2Host = new ServiceHost(typeof (AddInService2.AddInService2),
                    new Uri("http://localhost:6969/service2"));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool StopService()
        {
            Console.WriteLine("StopService2 " + AppDomain.CurrentDomain.FriendlyName);
            try
            {
                _service2Host.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool StartService()
        {
            Console.WriteLine("StartService2 " + AppDomain.CurrentDomain.FriendlyName);
            try
            {
                _service2Host.Open();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool RestartService()
        {
            throw new System.NotImplementedException();
        }
    }
}