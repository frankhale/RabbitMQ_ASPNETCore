using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Messages
{
    public class BusService : IHostedService
    {
        private readonly IBusControl _busControl;

        public BusService(IBusControl busControl)
        {
            _busControl = busControl;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return _busControl.StartAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return _busControl.StopAsync(cancellationToken);
        }
    }

    public class ToAPI1
    {
        public string Value { get; set; }
    }

    public class ToAPI2
    {
        public string Value { get; set; }
    }

    public class SendMessage1Consumer : IConsumer<ToAPI1>
    {
        public Task Consume(ConsumeContext<ToAPI1> context)
        {
            Console.WriteLine($"Receive message1 value: {context.Message.Value}");
            return Task.CompletedTask;
        }
    }

    public class SendMessage2Consumer : IConsumer<ToAPI2>
    {
        public Task Consume(ConsumeContext<ToAPI2> context)
        {
            Console.WriteLine($"Receive message2 value: {context.Message.Value}");
            return Task.CompletedTask;
        }
    }
}
