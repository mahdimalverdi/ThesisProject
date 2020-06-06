using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ThesisProject.ArangoDB.Data.Data
{
    public class ArangoDBCommand : IDisposable
    {
        private readonly HttpRequestMessage request;

        public ArangoDBCommand(ArangoDBConnection connection, HttpMethod httpMethod, string commandUri)
        {
            Connection = connection ?? throw new ArgumentNullException(nameof(connection));
            HttpMethod = httpMethod ?? throw new ArgumentNullException(nameof(httpMethod));
            CommandUri = commandUri ?? throw new ArgumentNullException(nameof(commandUri));

            request = GetRequest();
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
            await Connection.HttpClient.SendAsync(request);
        }

        private HttpRequestMessage GetRequest()
        {
            return new HttpRequestMessage(HttpMethod, CommandUri);
        }

        private async Task<TOut> ExecuteWithResultAsync<TOut>()
        {
            var response = await Connection.HttpClient.SendAsync(request);

            var stream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<TOut>(stream);

            return result;
        }

        private StringContent GetContent<T>(T data)
        {
            var json = JsonSerializer.Serialize(data);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return content;
        }

        public void Dispose()
        {
            request.Dispose();
        }
    }
}
