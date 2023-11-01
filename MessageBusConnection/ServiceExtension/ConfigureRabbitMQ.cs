using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessageBusConnection.ServiceExtension
{
    public static class ConfigureRabbitMQ
    {
        [Obsolete]
        public static IServiceCollection ConfigureBus(this IServiceCollection services, IConfiguration config)
        {
            var username = config["RabbitMQ:Username"];
            var password = config["RabbitMQ:Password"];
            var rabbitMqUrl = config["RabbitMQ:Url"];

            services.AddMassTransit(x =>
            {
                //register the consumers
                x.AddConsumer<SendSmsConsumer>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri(rabbitMqUrl), h =>
                    {
                        h.Username(username);
                        h.Password(password);
                    });
                    cfg.ReceiveEndpoint("SmsNotificationRequestMessage", consumer =>
                    {
                        consumer.Durable = true;
                        consumer.ConfigureConsumer<SendSmsConsumer>(provider);
                    });
                }));

            });

            services.AddSingleton<IHostedService, MessagingBusService>();

            return services;
        }
    }
}
