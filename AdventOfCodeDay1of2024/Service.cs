using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay1
{
    public class Service(Solver solver) : IHostedLifecycleService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
        }

        public async Task StartedAsync(CancellationToken cancellationToken)
        {
            var result = await solver.SolveDayOneAsync();
            Console.WriteLine(result);
            result = await solver.SolveDayTwoAsync();
            Console.WriteLine(result);
        }

        public async Task StartingAsync(CancellationToken cancellationToken)
        {
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
        }

        public async Task StoppedAsync(CancellationToken cancellationToken)
        {
        }

        public async Task StoppingAsync(CancellationToken cancellationToken)
        {
        }
    }
}
