using System.ServiceModel.Web;
using StorageServiceImplementation;

namespace StorageService
{
	public class StorageService : IStorageService
	{
		private AzureStorageImpl _impl;

		public StorageService()
		{
			_impl = new AzureStorageImpl();
		}
		public void PutString(string id, string data)
		{
			SetResponseHeaders();
			_impl.StoreString(id, data);
		}

		public string GetString(string id)
		{
			SetResponseHeaders();
			return _impl.GetString(id);
		}

		private static void SetResponseHeaders()
		{
			if (WebOperationContext.Current != null)
			{
				OutgoingWebResponseContext context = WebOperationContext.Current.OutgoingResponse;
				context.Headers.Add(System.Net.HttpResponseHeader.CacheControl, "public");
				context.StatusCode = System.Net.HttpStatusCode.OK;
				context.Headers.Add("Access-Control-Allow-Origin", "*");
			}
		}
	}
}