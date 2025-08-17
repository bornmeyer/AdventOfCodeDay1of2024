using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay1
{
    internal class Accumulator(Int32 value, Int32 index)
    {
        public Int32 Value => value;
        public Int32 Index => index;

        public Accumulator Update(Int32 value, Int32 index)
        {
            return new Accumulator(value, index);
        }
    }
}
