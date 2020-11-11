using Proto;
using Proto.Router;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite.ActorsKata.Generator.Actors
{
    class OperandActor : IActor
    {
        public Task ReceiveAsync(IContext context)
        {
            if (context.Message is string)
            {
                var msg = context.Message.ToString();
                Console.WriteLine(msg + "aaa");
            }

            return Task.CompletedTask;
        }
    }
}
