using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using ThesisProject.ArangoDB;
using ThesisProject.ArangoDB.Data.Classes.Requests;
using ThesisProject.Contracts;
using Utility;
using ThesisProject.Benchmark;
using ThesisProject.Abstraction.Instances;

namespace ThesisProject
{
    class Program
    {
        public class AddEntityRequest : BaseAddDocumentRequest<Guid>
        {
            public BaseInstance Instance { get; set; }
        }

        static async Task Main(string[] args)
        {
            for (int j = 0; j < 10; j++)
            {
                for (int i = 1; i < 6; i++)
                {
                    Console.WriteLine(i);
                    DataGenerator dataGenerator = new DataGenerator((int)Math.Pow(10, i), (int)Math.Pow(10, i) * 4);
                    dataGenerator.Generate();

                    await ArangoDBBenchmark(dataGenerator);
                }
            }
        }

        private static async Task ArangoDBBenchmark(DataGenerator dataGenerator)
        {
            var serviceProvider = GetServiceCollection(dataGenerator)
                .AddArangoDB()
                .BuildServiceProvider();

            await Benchmark(serviceProvider, "ArangoDb");
        }

        private static async Task Benchmark(ServiceProvider serviceProvider, string database)
        {
            var manager = serviceProvider.GetService<BenchmarkManager>();
            await manager.BenchmarkAsync(database);
        }

        private static IServiceCollection GetServiceCollection(DataGenerator dataGenerator)
        {
            return new ServiceCollection()
                            .AddSingleton(dataGenerator.EntityInstances)
                            .AddSingleton(dataGenerator.LinkInstances)
                            .AddSingleton<AddRangeBenchmark>()
                            .AddSingleton<DeleteBenchmark>()
                            .AddSingleton<GetBenchmark>()
                            .AddSingleton<KShortestPathsBenchmark>()
                            .AddSingleton<SearchBenchmark>()
                            .AddSingleton<ShortestPathBenchmark>()
                            .AddSingleton<UpdateBenchmark>()
                            .AddSingleton<BenchmarkManager>();
        }
    }
}
