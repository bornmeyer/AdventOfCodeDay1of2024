using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AdventOfCodeDay1
{
    public class DataProducer : IAsyncEnumerable<(Int32, Int32)>
    {
        public async IAsyncEnumerator<(int, int)> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            var file = new FileInfo("lists.txt");
            await foreach (var current in File.ReadLinesAsync(file.FullName))
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
