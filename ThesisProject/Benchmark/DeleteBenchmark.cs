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
    public class DeleteBenchmark : BaseBenchmark
    {
        private const string Function = "Delete";
        protected readonly IEntityInstanceRepository entityInstanceRepository;
        protected readonly ILinkInstanceRepository linkInstanceRepository;

        public DeleteBenchmark(
            IEntityInstanceRepository entityInstanceRepository,
            ILinkInstanceRepository linkInstanceRepository,
            List<EntityInstance> entityInstances,
            List<LinkInstance> linkInstances) : base(
                Function,
                entityInstances,
                linkInstances)
        {
            this.entityInstanceRepository = entityInstanceRepository ?? throw new ArgumentNullException(nameof(entityInstanceRepository));
            this.linkInstanceRepository = linkInstanceRepository ?? throw new ArgumentNullException(nameof(linkInstanceRepository));
        }

        protected override async Task<string> FunctionAsync()
        {
            await entityInstanceRepository.DeleteRange(entityInstances.Select(e => e.Id));
            await linkInstanceRepository.DeleteRange(linkInstances.Select(e => e.Id));

            return "";
        }
    }
}
