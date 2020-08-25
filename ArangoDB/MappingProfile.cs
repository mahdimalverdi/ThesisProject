using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ThesisProject.Contracts.Instances;

namespace ThesisProject.ArangoDB
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ArangoDBEntityInstance, EntityInstance>().ReverseMap();
            CreateMap<ArangoDBLinkInstance, LinkInstance>().ReverseMap();
        }
    }
}
