using System.AddIn.Pipeline;
using ServiceLoaderContracts;
using ServiceLoaderHostViewAdapter;

namespace ServiceLoaderHostSideAdapter
{
    [HostAdapter]
    public class ServiceLoaderContractToViewHostSideAdapter : IServiceLoader
    {
        private readonly IServiceLoaderContract _contract;
        private ContractHandle _handle;

        public ServiceLoaderContractToViewHostSideAdapter(IServiceLoaderContract contract)
        {
            _contract = contract;
            _handle = new ContractHandle(contract);
        }
        public bool LoadService()
        {
            return _contract.LoadService();
        }

        public bool StopService()
        {
            return _contract.StopService();
        }

        public bool StartService()
        {
            return _contract.StartService();
        }

        public bool RestartService()
        {
            return _contract.RestartService();
        }
    }
}
