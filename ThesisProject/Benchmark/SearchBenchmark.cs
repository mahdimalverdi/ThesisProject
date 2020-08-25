using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisProject.Abstraction;
using ThesisProject.Contracts.Instances;

namespace ThesisProject.Benchmark
{
    public class SearchBenchmark : BaseBenchmark
    {
        private const string Function = "Search";
        private readonly IGraphAlgorithms graphAlgorithms;
        private DateTime dateTime;

        public SearchBenchmark(
            IGraphAlgorithms graphAlgorithms,
            List<EntityInstance> entityInstances,
            List<LinkInstance> linkInstances) : base(Function, entityInstances, linkInstances)
        {
            this.graphAlgorithms = graphAlgorithms ?? throw new ArgumentNullException(nameof(graphAlgorithms));
        }

        public void Init(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        protected override async Task<string> FunctionAsync()
        {
            var path = await graphAlgorithms.SearchAsync(dateTime);

            return dateTime.ToString();
        }
    }
}
