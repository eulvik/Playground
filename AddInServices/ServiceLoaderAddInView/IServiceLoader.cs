using System.AddIn.Pipeline;

namespace ServiceLoaderAddInView
{
    [AddInBase]
    public interface IServiceLoader
    {
        bool LoadService();
        bool StopService();
        bool StartService();
        bool RestartService();
    }
}