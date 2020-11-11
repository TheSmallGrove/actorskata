using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Elite.ActorsKata.Generator.Actors;
using Elite.ActorsKata.Generator.Messages;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Proto;
using Proto.Router;

namespace Elite.ActorsKata.Generator
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var system = new ActorSystem();

            var props = Props.FromProducer(() => new ExpressionActor());

            var generator = system.Root.Spawn(props);

            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("exe");

                system.Root.Send(
                    generator, string.Empty);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
