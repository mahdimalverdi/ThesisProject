using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ThesisProject.ArangoDB.Data;
using ThesisProject.ArangoDB.Data.Classes.Requests;
using ThesisProject.ArangoDB.Data.Data;
using ThesisProject.ArangoDB.Data.Repositories;
using ThesisProject.Contracts;
using ThesisProject.Contracts.AttributeValues;
using ThesisProject.Contracts.Elements;
using ThesisProject.Contracts.Instances;

namespace ThesisProject
{
    class Program
    {
        public class AddEntityRequest : BaseAddDocumentRequest<Guid>
        {
            public BaseInstance Instance { get; set; }
        }

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var builder = new ArangoDBConnectionOptionsBuilder("http://185.97.118.66:8529/", "root", @"e)btg<JF\\G8(~F.s");
            using var connection = new ArangoDBConnection(builder.Options);
            await connection.ConnectAsync();

            var repository = new DocumentRepository(connection, "Entities");

            Random random = new Random();

            Stopwatch stopwatch = new Stopwatch();
            var requests = new List<AddEntityRequest>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var attributes = new HashSet<BaseAttributeValue>();
                attributes.Add(new IntAttributeValue() { AttributeId = 2, Values = Enumerable.Range(0, random.Next() % 10 + 1).ToHashSet() });
                attributes.Add(new StringAttributeValue() { AttributeId = 3, Values = Enumerable.Range(0, random.Next() % 10 + 1).Select(n => n.ToString()).ToHashSet() });

                Guid guid = Guid.NewGuid();
                var request = new AddEntityRequest()
                {
                    Instance = new EntityInstance()
                    {
                        AttributeValues = attributes,
                        ElementId = (long)random.Next() % 3,
                        Id = guid
                    },
                    _key = guid
                };

                requests.Add(request);
            }

            var tasks = new List<Task>();

            Console.WriteLine("start!");
            stopwatch.Start();
           await repository.AddRangeAsync<AddEntityRequest, Guid>(requests);

            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
