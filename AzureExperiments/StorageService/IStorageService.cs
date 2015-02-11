using System.ServiceModel;
using System.ServiceModel.Web;

namespace StorageService
{
	[ServiceContract]
	public interface IStorageService
	{
		[OperationContract]
		[WebGet(UriTemplate = "put/{id}/{data}")]
		void PutString(string id, string data);

		[OperationContract]
		[WebGet(UriTemplate = "get/{id}")]
		string GetString(string id);
	}
}