using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ThesisProject.Abstraction;
using ThesisProject.Abstraction.Instances;
using ThesisProject.Contracts.Instances;

namespace ThesisProject.Benchmark
{
    public abstract class BaseBenchmark
    {
        private const string Path = "Log.txt";
        private readonly string function;
        protected readonly List<EntityInstance> entityInstances;
        protected readonly List<LinkInstance> linkInstances;

        protected BaseBenchmark(
            string function,
            List<EntityInstance> entityInstances,
            List<LinkInstance> linkInstances)
        {
            this.function = function ?? throw new ArgumentNullException(nameof(function));
            this.entityInstances = entityInstances ?? throw new ArgumentNullException(nameof(entityInstances));
            this.linkInstances = linkInstances ?? throw new ArgumentNullException(nameof(linkInstances));
        }

        public async Task BenchmarkAsync(string database)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var newLine = await FunctionAsync();

            stopwatch.Stop();

            string line = string.Join(',',
                database,
                function,
                newLine,
                entityInstances.Count,
                linkInstances.Count,
                stopwatch.ElapsedMilliseconds);
            await File.AppendAllLinesAsync(Path,new string[] { line });
        }

        protected abstract Task<string> FunctionAsync();
    }
}
