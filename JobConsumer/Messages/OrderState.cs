using System;
using Automatonymous;

namespace JobConsumer.Messages
{
    public class OrderState : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }

        public string Message { get; set; }
        public int CurrentState { get; set; }
    }
}