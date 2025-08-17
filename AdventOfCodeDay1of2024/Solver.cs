using AdventOfCodeDay1of2024;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay1
{
    public class Solver(DataProducer dataProducer)
    {
        public async Task<Int32> SolveDayOneAsync()
        {
            List<Int32> left = [];
            List<Int32> right = [];

            Func<Int32, Int32, Int32> getDistance = (left, right) => left switch {
                _ when left > right => left - right,
                _ when left < right => right - left,
                _ => 0
            };

            await foreach (var current in dataProducer)
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

        public async Task<Int32> SolveDayTwoAsync()
        {
            Dictionary<Int32, Int32> left = [];
            List<Int32> right = [];

            await foreach (var current in dataProducer)
            {
                left.Add(current.Item1, 0);
                right.Add(current.Item2);
            }
            var rightOrdered = right.OrderDescending();
            return left.OrderByDescending(x => x.Key)
                .Select(kvPair => new KeyValuePair<Int32, Int32>(kvPair.Key, right.Count(x => x == kvPair.Key)))
                .Sum(kvPair => kvPair.Value * kvPair.Key);
        }
    }
}
