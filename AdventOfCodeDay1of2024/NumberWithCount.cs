using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay1of2024
{
    internal class NumberWithCount(Int32 number, Int32 count)
    {
        public Int32 Number => number;
        public Int32 Count => count;

        public NumberWithCount Update(Int32 number, Int32 count)
        {
            return new NumberWithCount(number, count);
        }
    }
}
