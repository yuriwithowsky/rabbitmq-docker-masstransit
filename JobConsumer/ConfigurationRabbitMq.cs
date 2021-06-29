using System;
using Job.Messages;
using JobConsumer.Consumers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace JobConsumer
{
    public static class ConfigurationRabbitMq
    {
        public static IServiceCollection AddMassTransitWithRabbitMq(this IServiceCollection services)
        {
            services.AddMassTransit(options =>
            {
                options.AddConsumersFromNamespaceContaining<SendMessageConsumer>();

                options.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri("rabbitmq://rabbitmq"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ReceiveEndpoint("message_queue", e =>
                    {
                        // e.ConfigureConsumeTopology = false;
                        
                        //e.Consumer<SendMessageConsumer>();
                        e.ConfigureConsumer<SendMessageConsumer>(context);

                        // e.Bind<TextMessage>(s => {
                        //     s.RoutingKey = "ciclano";
                        //     s.ExchangeType = ExchangeType.Direct;
                        // });
                    });
                    // cfg.ReceiveEndpoint("message_queue_fulano", e =>
                    // {
                    //     e.ConfigureConsumeTopology = false;
                        
                    //     //e.Consumer<SendMessageConsumer>();
                    //     e.ConfigureConsumer<SendMessageConsumer>(context);

                    //     e.Bind<TextMessage>(s => {
                    //         s.RoutingKey = "fulano";
                    //         s.ExchangeType = ExchangeType.Direct;
                    //     });
                    // });
                });
            });
            services.AddMassTransitHostedService(); 

            return services;
        }
    }
}