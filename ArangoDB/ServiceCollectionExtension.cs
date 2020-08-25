using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ThesisProject.Contracts.Instances;
using ThesisProject.Abstraction.Instances;
using ArangoDBNetStandard;
using ArangoDBNetStandard.Transport.Http;
using ThesisProject.Abstraction;

namespace ThesisProject.ArangoDB
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddArangoDB(this IServiceCollection serviceDescriptors)
        {
            var transport = HttpApiTransport.UsingBasicAuth(
                               new Uri("http://185.239.107.111:8529"),
                               "_system",
                               "root",
                               "6600068167");

            var arangoDBClient = new ArangoDBClient(transport);

            serviceDescriptors.AddAutoMapper(typeof(ServiceCollectionExtension), typeof(MappingProfile));

            serviceDescriptors.AddTransient<IEntityInstanceRepository, ArangoDBEntityInstanceRepository>();
            serviceDescriptors.AddTransient<ILinkInstanceRepository, ArangoDBLinkInstanceRepository>();
            serviceDescriptors.AddTransient<IGraphAlgorithms, ArangoDBGraphAlgorithms>();
            serviceDescriptors.AddSingleton(arangoDBClient);

            return serviceDescriptors;
        }
    }
}
