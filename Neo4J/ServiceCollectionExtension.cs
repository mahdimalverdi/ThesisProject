using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ThesisProject.Abstraction;
using ThesisProject.Abstraction.Instances;
using OrientDB_Net.binary.Innov8tive;
using Orient.Client;

namespace Thesis.OrientDB
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddOrientDB(this IServiceCollection serviceDescriptors)
        {
            ODatabase database = new ODatabase("37.152.180.240", 2424, "account-app",
            ODatabaseType.Document, "root", "6600068167");
            //serviceDescriptors.AddAutoMapper(typeof(ServiceCollectionExtension), typeof(MappingProfile));

            serviceDescriptors.AddTransient<IEntityInstanceRepository, OrientDBEntityInstanceRepository>();
            serviceDescriptors.AddTransient<ILinkInstanceRepository, OrientDBLinkInstanceRepository>();
            serviceDescriptors.AddTransient<IGraphAlgorithms, OrientDBGraphAlgorithms>();
            serviceDescriptors.AddSingleton(database);

            return serviceDescriptors;
        }
    }
}
