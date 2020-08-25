using ArangoDBNetStandard;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisProject.Abstraction.Instances;
using ThesisProject.Contracts.Instances;

namespace ThesisProject.ArangoDB
{
    public class ArangoDBEntityInstanceRepository :
        ArangoDBBaseInstanceRepository<EntityInstance, ArangoDBEntityInstance>, 
        IEntityInstanceRepository
    {
        public ArangoDBEntityInstanceRepository(ArangoDBClient arangoDBClient, IMapper mapper) : 
            base(arangoDBClient, mapper, ArangoDBConsts.EntitiesCollectionName)
        {
        }
    }
}
