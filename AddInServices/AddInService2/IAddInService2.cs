using System.ServiceModel;
using System.ServiceModel.Web;

namespace AddInService2
{
    [ServiceContract]
    public interface IAddInService2
    {
        [OperationContract]
        [WebGet(UriTemplate = "/sayhello2")]
        string SayHelloService2();
    }
}
