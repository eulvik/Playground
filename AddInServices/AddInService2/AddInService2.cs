using System;

namespace AddInService2
{
    public class AddInService2 : IAddInService2
    {

        public string SayHelloService2()
        {
            return string.Format("Hello from AddInService2 with AppDomain={0}", AppDomain.CurrentDomain.FriendlyName);
        }
    }
}
