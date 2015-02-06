using System.ServiceModel;
using System.ServiceModel.Web;

namespace AddInService1
{
    [ServiceContract]
    public interface IAddInService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "/sayhello1")]
        string SayHello();
    }
}
