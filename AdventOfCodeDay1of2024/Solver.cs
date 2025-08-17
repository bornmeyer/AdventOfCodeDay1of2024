using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay1
{
    public class Solver(DataReader dataReader)
    {
        public async Task<Int32> SolveAsync()
        {
            var file = new FileInfo("lists.txt");

            List<Int32> left = [];
            List<Int32> right = [];

            Func<Int32, Int32, Int32> getDistance = (left, right) => left switch {
                _ when left > right => left - right,
                _ when left < right => right - left,
                _ => 0
            };

            await foreach (var current in dataReader.ReadDataAsync(file))
            {
                left.Add(current.Item1);
                right.Add(current.Item2);
            }
            var rightOrdered = right.OrderDescending();
            var result = left.OrderDescending().Aggregate(new Accumulator(0, 0), (acc, current) =>
            {
                return new Accumulator(acc.Value + getDistance(current, rightOrdered.ElementAt(acc.Index)), acc.Index + 1);
            });
            return result.Value;
        }
    }
}
