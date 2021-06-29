using System.Threading.Tasks;
using Job.Messages;
using MassTransit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace JobConsumer.Consumers
{
    public class SendMessageConsumer : IConsumer<TextMessage>
    {
        private readonly ILogger<SendMessageConsumer> logger;

        public SendMessageConsumer(ILogger<SendMessageConsumer> logger)
        {
            this.logger = logger;
        }
        public async Task Consume(ConsumeContext<TextMessage> context)
        {
            context.TryGetPayload<object>(out object payload);
            logger.LogInformation($"Mensagem recebida! Texto {context.Message.Text} de {context.Message.Destination} SourceAddress {context.SourceAddress} ResponseAddress {context.ResponseAddress} DestinationAddress {context.DestinationAddress} Payload {JsonConvert.SerializeObject(payload)} Headers {JsonConvert.SerializeObject(context.Headers)}");
            
            await Task.Delay(1000);
        }
    }
}