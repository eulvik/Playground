using System;

namespace AddInService1
{
    public class AddInService1 : IAddInService1
    {
        public string SayHello()
        {
            return string.Format("Hello from AddInService1 with AppDomain={0}", AppDomain.CurrentDomain.FriendlyName);
        }
    }
}
