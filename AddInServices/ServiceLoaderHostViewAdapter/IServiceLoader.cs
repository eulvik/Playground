namespace ServiceLoaderHostViewAdapter
{
    public interface IServiceLoader
    {
        bool LoadService();
        bool StopService();
        bool StartService();
        bool RestartService(); 
    }
}