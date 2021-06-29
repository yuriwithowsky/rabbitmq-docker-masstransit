using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Job.Messages;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace JobProducer
{
    public class Worker : IHostedService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IBusControl _busControl;

        public Worker(ILogger<Worker> logger, IBusControl busControl)
        {
            _logger = logger;
            _busControl = busControl;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting worker");
            await _busControl.StartAsync(cancellationToken).ConfigureAwait(false);
                
            for (int i = 0; i < 1000; i++)
            {
                var destination = "ciclano";
                
                // if(i % 2 == 0)
                //     destination = "fulano";
                
                var text = "teste";
                _logger.LogInformation($"Enviando mensagem: {text} para {destination}");
                
                var endpoint = await _busControl.GetSendEndpoint(new Uri("queue:message_queue"));
                //if(destination == "ciclano")
                _logger.LogInformation($"Enviando por endpoint");
                await endpoint.Send<TextMessage>(new TextMessage { Text = text, Destination = destination });
                
                _logger.LogInformation($"Enviado com sucesso!");

                //await _busControl.Publish<TextMessage>(new { Text = text, Destination = destination });

                await Task.Delay(1000);
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping worker");
            await _busControl.StopAsync();
        }
    }
}
