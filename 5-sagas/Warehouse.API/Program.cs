using Topshelf;

namespace Warehouse.API
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<ServiceHost>(s =>
                {
                    s.ConstructUsing(name => new ServiceHost());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalService();
                x.StartAutomatically();

                x.SetDescription("Microservices Done Right sample: Warehouse API");
                x.SetDisplayName("Warehouse API");
                x.SetServiceName("WarehouseAPI");
            });
        }
    }
}
