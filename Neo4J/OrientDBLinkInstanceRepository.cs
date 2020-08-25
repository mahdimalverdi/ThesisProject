using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThesisProject.Abstraction.Instances;
using ThesisProject.Contracts.Instances;

namespace Thesis.OrientDB
{
    internal class OrientDBLinkInstanceRepository : ILinkInstanceRepository
    {
        public Task<List<LinkInstance>> AddRange(IEnumerable<LinkInstance> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRange(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinkInstance>> Get(IEnumerable<Guid> id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinkInstance>> UpdateRange(IEnumerable<LinkInstance> entities)
        {
            throw new NotImplementedException();
        }
    }
}