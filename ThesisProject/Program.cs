using System;
using System.Net.Http;
using ThesisProject.ArangoDB;
using ThesisProject.ArangoDB.Repositories;

namespace ThesisProject
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var builder = new ArangoDBConnectionOptionsBuilder("http://185.97.118.66:8529/", "root", @"e)btg<JF\\G8(~F.s");
            using var connection = new ArangoDBConnection(builder.Options);
            await connection.ConnectAsync();

            var repository = new CollectionRepository(connection);

            await repository.GetAllAsync();

            var command = connection.CreateCommand(HttpMethod.Post, "_api/document/Entities");
            await command.ExecuteAsync(new
            {
                elementId = 2
            });
        }
    }
}
