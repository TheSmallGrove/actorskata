using Elite.ActorsKata.Generator.Messages;
using Proto;
using Proto.Mailbox;
using Proto.Router;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Elite.ActorsKata.Generator.Actors
{
    class ExpressionActor : IActor
    {
        public Task ReceiveAsync(IContext context)
        {
            if (context.Message is string)
            {
                var msg = context.Message.ToString();

                Console.WriteLine(msg + "exp");

                var opz = Props.FromProducer(() => new OperandActor());
                var exp = Props.FromProducer(() => new ExpressionActor());

                var group = context.NewRandomGroup(
                    context.Spawn(opz),
                    context.Spawn(exp)
                    );

                var pid = context.Spawn(group);

                context.Send(pid, msg + " ");
            }

            return Task.CompletedTask;
        }
    }
}
