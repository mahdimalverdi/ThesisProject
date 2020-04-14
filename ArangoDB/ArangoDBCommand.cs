using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ThesisProject.ArangoDB
{
    public class ArangoDBCommand : IDisposable
    {
        private readonly HttpRequestMessage request;
        public ArangoDBCommand(ArangoDBConnection connection, HttpMethod httpMethod, string commandUri)
        {
            Connection = connection ?? throw new ArgumentNullException(nameof(connection));
            HttpMethod = httpMethod ?? throw new ArgumentNullException(nameof(httpMethod));
            CommandUri = commandUri ?? throw new ArgumentNullException(nameof(commandUri));

            this.request = GetRequest();
        }

        public ArangoDBConnection Connection { get; private set; }
        public HttpMethod HttpMethod { get; private set; }
        public string CommandUri { get; private set; }

        public async Task ExecuteAsync()
        {
            await Execute();
        }

        public async Task<T> ExecuteAsync<T>()
        {
            var result = await ExecuteWithResultAsync<T>();

            return result;
        }

        public async Task ExecuteAsync<T>(T data)
        {
            request.Content = GetContent(data);

            await Execute();
        }

        public async Task<TOut> ExecuteAsync<T, TOut>(T data)
        {
            request.Content = GetContent(data);

            var result = await ExecuteWithResultAsync<TOut>();

            return result;
        }

        private async Task Execute()
        {
            await this.Connection.HttpClient.SendAsync(request);
        }

        private HttpRequestMessage GetRequest()
        {
            return new HttpRequestMessage(HttpMethod, this.CommandUri);
        }

        private async Task<TOut> ExecuteWithResultAsync<TOut>()
        {
            var response = await this.Connection.HttpClient.SendAsync(request);

            var value = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TOut>(value);

            return result;
        }

        private static StringContent GetContent<T>(T data)
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(data, settings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return content;
        }

        public void Dispose()
        {
            this.request.Dispose();
        }
    }
}
