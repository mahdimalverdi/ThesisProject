using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisProject.Abstraction;
using ThesisProject.Contracts.Instances;

namespace ThesisProject.Benchmark
{
    public class KShortestPathsBenchmark : BaseBenchmark
    {
        private const string Function = "KShortestPath";
        private bool isDirective = true;
        private int k = 3;
        private readonly IGraphAlgorithms graphAlgorithms;

        public KShortestPathsBenchmark(
            IGraphAlgorithms graphAlgorithms,
            List<EntityInstance> entityInstances,
            List<LinkInstance> linkInstances) : base(Function, entityInstances, linkInstances)
        {
            this.graphAlgorithms = graphAlgorithms ?? throw new ArgumentNullException(nameof(graphAlgorithms));
        }

        public void Init(int k, bool isDirective)
        {
            this.k = k;
            this.isDirective = isDirective;
        }

        protected override async Task<string> FunctionAsync()
        {
            var path = await graphAlgorithms.KShortestPathAsync(
                entityInstances.First().Id,
                entityInstances.Last().Id,
                k,
                isDirective);

            return string.Join(' ', k, isDirective);
        }
    }
}
