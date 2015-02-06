using System.AddIn.Contract;
using System.AddIn.Pipeline;

namespace ServiceLoaderContracts
{
    [AddInContract]
    public interface IServiceLoaderContract : IContract
    {
        bool LoadService();
        bool StopService();
        bool StartService();
        bool RestartService();
    }
}