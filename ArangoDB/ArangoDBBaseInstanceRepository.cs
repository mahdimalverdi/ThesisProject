using ArangoDBNetStandard;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisProject.Contracts.Instances;

namespace ThesisProject.ArangoDB
{
    public class ArangoDBBaseInstanceRepository<T, TArango>
        where TArango : T, new()
        where T : new()
    {
        private const int BatchSize = 10000;
        private readonly ArangoDBClient arangoDBClient;
        private readonly IMapper mapper;
        private readonly string collectionName;

        public ArangoDBBaseInstanceRepository(ArangoDBClient arangoDBClient, IMapper mapper, string collectionName)
        {
            this.arangoDBClient = arangoDBClient ?? throw new ArgumentNullException(nameof(arangoDBClient));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.collectionName = collectionName ?? throw new ArgumentNullException(nameof(collectionName));
        }

        public async Task<T> Add(T entity)
        {
            var item = mapper.Map<TArango>(entity);

            var response = await arangoDBClient.Document.PostDocumentAsync(collectionName, item);

            return response.New;
        }

        public async Task<List<T>> AddRange(IEnumerable<T> entities)
        {
            var items = mapper.Map<List<TArango>>(entities);

            var result = new List<T>();

            foreach (var bulk in GetBulks(items))
            {
                var list = (await arangoDBClient.Document.PostDocumentsAsync(collectionName, bulk)).Select(e => e.New).Cast<T>();

                result.AddRange(list);
            }

            return result;
        }

        public async Task DeleteRange(IEnumerable<Guid> ids)
        {
            List<string> selectors = ids.Select(i => i.ToString()).ToList();

            foreach (var bulk in GetBulks(selectors))
            {
                await this.arangoDBClient.Document.DeleteDocumentsAsync(collectionName, bulk);
            }
        }

        public async Task<List<T>> Get(IEnumerable<Guid> ids)
        {
            List<string> selectors = ids.Select(i => i.ToString()).ToList();

            List<T> result = new List<T>();

            foreach (var bulk in GetBulks(selectors))
            {
                var list = await this.arangoDBClient.Document.GetDocumentsAsync<TArango>(collectionName, bulk);

                result.AddRange(list.Cast<T>());
            }

            return result;
        }

        public IEnumerable<List<T>> GetBulks<T>(IList<T> entities)
        {
            for (int i = 0; i < (double)entities.Count / BatchSize; i++)
            {
                yield return entities.Skip(i * BatchSize).Take(BatchSize).ToList();
            }
        }

        public async Task<List<T>> UpdateRange(IEnumerable<T> entities)
        {
            var items = mapper.Map<List<TArango>>(entities);

            var result = new List<T>();

            foreach (var bulk in GetBulks(items))
            {
                var list = (await arangoDBClient.Document.PutDocumentsAsync(collectionName, bulk)).Select(e => e.New).Cast<T>();

                result.AddRange(list);
            }

            return result;
        }
    }
}
