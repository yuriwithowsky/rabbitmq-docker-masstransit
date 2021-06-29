using System;
using Job.Messages;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace JobProducer
{
    public static class ConfigurationRabbitMq
    {
        public static IServiceCollection AddMassTransitWithRabbitMq(this IServiceCollection services)
        {
            services.AddMassTransit(options =>
            {
                options.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri("rabbitmq://rabbitmq"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    // cfg.Send<TextMessage>(x =>
                    // {
                    //     x.UseRoutingKeyFormatter(context => context.Message.Destination);

                    //     //x.UseCorrelationId(context => context.Message.TransactionId);
                    // });
                    // cfg.Publish<TextMessage>(x => x.ExchangeType = ExchangeType.Direct);
                });
            });

            return services;
        }
    }
}