using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBusConnection.ServiceExtension
{
    public static class ConfigureRabbitMQ
    {
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

                    //receive endpoint for When an account has been approved
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
