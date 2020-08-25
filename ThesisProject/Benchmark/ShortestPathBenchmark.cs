using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisProject.Abstraction;
using ThesisProject.Contracts.Instances;

namespace ThesisProject.Benchmark
{
    public class ShortestPathBenchmark : BaseBenchmark
    {
        private const string Function = "ShortestPath";
        private readonly IGraphAlgorithms graphAlgorithms;
        private bool isDirective;

        public ShortestPathBenchmark(
            IGraphAlgorithms graphAlgorithms,
            List<EntityInstance> entityInstances,
            List<LinkInstance> linkInstances) : base(Function, entityInstances, linkInstances)
        {
            this.graphAlgorithms = graphAlgorithms ?? throw new ArgumentNullException(nameof(graphAlgorithms));
        }


        public void Init(bool isDirective)
        {
            this.isDirective = isDirective;
        }

        protected override async Task<string> FunctionAsync()
        {
            var path = await graphAlgorithms.ShortestPathAsync(
                entityInstances.First().Id,
                entityInstances.Last().Id,
                isDirective);

            return isDirective.ToString();
        }
    }
}
