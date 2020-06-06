using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ThesisProject.ArangoDB.Data.Classes.Requests;
using ThesisProject.ArangoDB.Data.Data;

namespace ThesisProject.ArangoDB.Data.Repositories
{
    public class DocumentRepository
    {
        private const string RepositoryUrl = "_api/document/";
        private const string ImportUrl = "_api/import?type=list&collection=";
        private const int BatchSize = 1000;
        private readonly ArangoDBConnection connection;

        public DocumentRepository(ArangoDBConnection connection, string collection)
        {
            this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
            Collection = collection ?? throw new ArgumentNullException(nameof(collection));
        }

        public string Collection { get; private set; }

        public async Task AddAsync<T, TKey>(T entity) where T : BaseAddDocumentRequest<TKey>
        {
            string commandUri = $"{RepositoryUrl}{Collection}";
            using var command = this.connection.CreateCommand(HttpMethod.Post, commandUri);

            var result = await command.ExecuteAsync<T, object>(entity);
        }

        public async Task AddRangeAsync<T, TKey>(IEnumerable<T> entities) where T : BaseAddDocumentRequest<TKey>
        {
            var count = entities.Count() / BatchSize;

            var tasks = new List<Task>();

            foreach (var counter in Enumerable.Range(0, count))
            {
                var task = AddRangeAsync<T, TKey>(entities, counter);
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }

        private async Task<ArangoDBCommand> AddRangeAsync<T, TKey>(IEnumerable<T> entities, int counter) where T : BaseAddDocumentRequest<TKey>
        {
            string commandUri = $"{ImportUrl}{Collection}";
            var insertedEntities = entities.Skip(counter * BatchSize).Take(BatchSize);
            var command = this.connection.CreateCommand(HttpMethod.Post, commandUri);
            await command.ExecuteAsync(insertedEntities);
            return command;
        }
    }
}
