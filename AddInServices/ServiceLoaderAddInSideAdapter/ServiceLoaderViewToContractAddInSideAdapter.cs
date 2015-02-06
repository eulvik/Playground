using System;
using System.AddIn.Pipeline;
using ServiceLoaderAddInView;
using ServiceLoaderContracts;

namespace ServiceLoaderAddInSideAdapter
{
    [AddInAdapter]
    public class ServiceLoaderViewToContractAddInSideAdapter :
        ContractBase, IServiceLoaderContract
    {
        private readonly IServiceLoader _view;

        public ServiceLoaderViewToContractAddInSideAdapter(IServiceLoader view)
        {
            _view = view;
        }

        public bool LoadService()
        {
            return _view.LoadService();
        }

        public bool StopService()
        {
            return _view.StopService();
        }

        public bool StartService()
        {
            return _view.StartService();
        }

        public bool RestartService()
        {
            return _view.RestartService();
        }
    }
}
