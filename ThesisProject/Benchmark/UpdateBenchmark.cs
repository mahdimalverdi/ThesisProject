using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThesisProject.Abstraction;
using ThesisProject.Abstraction.Instances;
using ThesisProject.Contracts.Instances;

namespace ThesisProject.Benchmark
{
    public class UpdateBenchmark : BaseBenchmark
    {
        private const string Function = "Update";
        protected readonly IEntityInstanceRepository entityInstanceRepository;
        protected readonly ILinkInstanceRepository linkInstanceRepository;

        public UpdateBenchmark(
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
            entityInstances.ForEach(e => e.ElementId = 10);
            linkInstances.ForEach(e => e.ElementId = 11);

            await entityInstanceRepository.UpdateRange(entityInstances);
            await linkInstanceRepository.UpdateRange(linkInstances);

            return "";
        }
    }
}
