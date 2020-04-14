using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ThesisProject.ArangoDB.Classes;

namespace ThesisProject.ArangoDB.Repositories
{
    public class CollectionRepository
    {
        private readonly ArangoDBConnection connection;

        public CollectionRepository(ArangoDBConnection connection)
        {
            this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public async System.Threading.Tasks.Task<GetAllCollectionResponse> GetAllAsync()
        {
            using var command = this.connection.CreateCommand(HttpMethod.Get, "/_api/collection");

            var result = await command.ExecuteAsync<GetAllCollectionResponse>();

            return result;
        }
    }
}
