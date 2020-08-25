using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThesisProject.Abstraction;
using ThesisProject.Abstraction.Instances;
using ThesisProject.Contracts.Instances;

namespace ThesisProject.Benchmark
{
    public class AddRangeBenchmark : BaseBenchmark
    {
        private const string Function = "AddRange";
        protected readonly IEntityInstanceRepository entityInstanceRepository;
        protected readonly ILinkInstanceRepository linkInstanceRepository;

        public AddRangeBenchmark(
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
            await this.entityInstanceRepository.AddRange(this.entityInstances);
            await this.linkInstanceRepository.AddRange(this.linkInstances);

            return "";
        }
    }
}
