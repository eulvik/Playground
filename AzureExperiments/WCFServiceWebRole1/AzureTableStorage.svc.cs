using StorageService;
using StorageServiceImplementation;

namespace AzureTableStorageWebRole
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class Service1 : IStorageService
	{
		private AzureStorageImpl _impl;

		public Service1()
		{
			_impl = new AzureStorageImpl();
		}
		public void PutString(string id, string data)
		{
			_impl.StoreString(id, data);
		}

		public string GetString(string id)
		{
			return _impl.GetString(id);
		}
	}
}
