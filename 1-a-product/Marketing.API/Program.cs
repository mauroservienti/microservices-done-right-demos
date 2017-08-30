using Topshelf;

namespace Marketing.API
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

                x.SetDescription("Microservices Done Right sample: Marketing API");
                x.SetDisplayName("Marketing API");
                x.SetServiceName("MarketingAPI");
            });
        }
    }
}
