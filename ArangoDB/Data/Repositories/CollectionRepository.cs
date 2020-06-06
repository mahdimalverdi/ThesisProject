using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ThesisProject.ArangoDB.Data.Classes.Responses;

namespace ThesisProject.ArangoDB.Data.Repositories
{
    public class CollectionRepository
    {
        private const string RepositoryUrl = "/_api/collection";
        private readonly ArangoDBConnection connection;

        public CollectionRepository(ArangoDBConnection connection)
        {
            this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public async Task<GetAllCollectionResponse> GetAllAsync()
        {
            using var command = this.connection.CreateCommand(HttpMethod.Get, RepositoryUrl);

            var result = await command.ExecuteAsync<GetAllCollectionResponse>();

            return result;
        }
    }
}
