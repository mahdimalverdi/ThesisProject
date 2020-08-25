using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisProject.Abstraction;
using ThesisProject.Abstraction.Instances;
using ThesisProject.Contracts.Instances;

namespace ThesisProject.Benchmark
{
    public class GetBenchmark : BaseBenchmark
    {
        private const string Function = "Get";
        protected readonly IEntityInstanceRepository entityInstanceRepository;
        protected readonly ILinkInstanceRepository linkInstanceRepository;

        public GetBenchmark(
            IEntityInstanceRepository entityInstanceRepository,
            ILinkInstanceRepository linkInstanceRepository,
            List<EntityInstance> entityInstances,
            List<LinkInstance> linkInstances) : base(Function, entityInstances, linkInstances)
        {
            this.entityInstanceRepository = entityInstanceRepository ?? throw new ArgumentNullException(nameof(entityInstanceRepository));
            this.linkInstanceRepository = linkInstanceRepository ?? throw new ArgumentNullException(nameof(linkInstanceRepository));
        }

        protected override async Task<string> FunctionAsync()
        {
            var entities = await entityInstanceRepository.Get(entityInstances.Select(e => e.Id));
            var links = await linkInstanceRepository.Get(linkInstances.Select(e => e.Id));

            return "";
        }
    }
}
