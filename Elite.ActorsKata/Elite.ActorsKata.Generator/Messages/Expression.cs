using System;
using System.Collections.Generic;
using System.Text;

namespace Elite.ActorsKata.Generator.Messages
{
    class Expression
    {
        public int Seed { get; init; }

        public override string ToString()
        {
            return $"seed: {this.Seed}";
        }
    }
}
