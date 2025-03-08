using Microsoft.Extensions.DependencyInjection;
using HardwareCommunicationSDK.Communications;

namespace HardwareCommunicationSDK
{
    public static class DependencyInjectionConfig
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Register factory and protocol implementations
            services.AddSingleton<CommunicationFactory>();
            services.AddSingleton<ICommunicationProtocol, ModbusCommunication>();
            services.AddSingleton<ModbusCommunication>();

            return services.BuildServiceProvider();
        }
    }
}
