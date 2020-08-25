using ArangoDBNetStandard;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThesisProject.Abstraction;
using ThesisProject.Abstraction.Instances;
using ThesisProject.Contracts.Instances;

namespace ThesisProject.ArangoDB
{
    public class ArangoDBLinkInstanceRepository : 
        ArangoDBBaseInstanceRepository<LinkInstance, ArangoDBLinkInstance>,
        ILinkInstanceRepository
    {
        public ArangoDBLinkInstanceRepository(ArangoDBClient arangoDBClient, IMapper mapper) :
            base(arangoDBClient, mapper, ArangoDBConsts.LinksCollectionName)
        {
        }
    }
}
