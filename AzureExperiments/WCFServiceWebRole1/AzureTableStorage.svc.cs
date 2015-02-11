using StorageService;
using StorageServiceImplementation;

namespace AzureTableStorageWebRole
{
	public class AzureTableStorage : IStorageService
	{
		private readonly AzureStorageImpl _impl;

		public AzureTableStorage()
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
