using System;
using System.AddIn;
using System.ServiceModel;
using ServiceLoaderAddInView;

namespace AddInService1Loader
{
    [AddIn("Service1 loader", Version = "0.0.0.1")]
    public class AddInService1Loader : IServiceLoader
    {
        private ServiceHost _service1Host;

        public bool LoadService()
        {
            Console.WriteLine("LoadService1 " + AppDomain.CurrentDomain.FriendlyName);
            try
            {
                _service1Host = new ServiceHost(typeof(AddInService1.AddInService1), new Uri("http://localhost:6969/service1"));
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
            Console.WriteLine("StopService1 " + AppDomain.CurrentDomain.FriendlyName);
            try
            {
                _service1Host.Close();
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
            Console.WriteLine("StartService1 " + AppDomain.CurrentDomain.FriendlyName);
            try
            {
                _service1Host.Open();
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
            throw new NotImplementedException();
        }
    }
}
