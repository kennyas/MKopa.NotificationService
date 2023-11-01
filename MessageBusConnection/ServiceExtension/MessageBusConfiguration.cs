using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmsCore.Interface;
using SmsCore.Repository;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace MessageBusConnection.ServiceExtension
{
    public static class MessageBusConfiguration
    {
        [Obsolete]
        public static IServiceCollection AddMessagingBus(this IServiceCollection services,
         IConfiguration config)
        {
            services.ConfigureRabbitBus(config);
            services.TryAddScoped<IMessagePublisher, MessagePublisher>();
            return services;
        }

        [Obsolete]
        private static void ConfigureRabbitBus(this IServiceCollection services, IConfiguration config)
        {
            var dictionary = new Dictionary<string, Func<IServiceCollection, IConfiguration, IServiceCollection>>
        {
            { Environments.Development, ConfigureRabbitMQ.ConfigureBus}
        };

            dictionary[Environments.Development](services, config);
        }
    }
}

