using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AdventOfCodeDay1
{
    public class DataReader
    {
        public async IAsyncEnumerable<(Int32, Int32)> ReadDataAsync(FileInfo file)
        {
            await foreach(var current in File.ReadLinesAsync(file.FullName))
            {
                var split = current.Split("   ") switch
                {
                    [var left, var right] => (Int32.Parse(left), Int32.Parse(right)),
                    _ => throw new ArgumentException()
                };
                yield return split;
            }
        }
    }
}
