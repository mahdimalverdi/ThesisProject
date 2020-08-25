using Orient.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisProject.Abstraction.Instances;
using ThesisProject.Contracts.Instances;

namespace Thesis.OrientDB
{
    public class OrientDBEntityInstanceRepository : IEntityInstanceRepository
    {
        private readonly ODatabase database;

        public OrientDBEntityInstanceRepository(ODatabase database)
        {
            this.database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public async Task<List<EntityInstance>> AddRange(IEnumerable<EntityInstance> entities)
        {
            foreach (var entity in entities)
            {
                database.Insert(entity).Into("entities").Run();
            }

            return entities.ToList();
        }

        public Task DeleteRange(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task<List<EntityInstance>> Get(IEnumerable<Guid> id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EntityInstance>> UpdateRange(IEnumerable<EntityInstance> entities)
        {
            throw new NotImplementedException();
        }
    }
}
