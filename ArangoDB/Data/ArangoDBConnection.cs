﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ThesisProject.ArangoDB.Data.Classes.Requests;
using ThesisProject.ArangoDB.Data.Classes.Responses;
using ThesisProject.ArangoDB.Data.Data;

namespace ThesisProject.ArangoDB.Data
{
    public class ArangoDBConnection : IDisposable
    {
        private const string Scheme = "bearer";
        private readonly ArangoDBConnectionOptions options;

        public ArangoDBConnection(ArangoDBConnectionOptions options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }

        internal HttpClient HttpClient { get; private set; }

        public async Task ConnectAsync()
        {
            this.HttpClient = new HttpClient();
            this.HttpClient.BaseAddress = new Uri(this.options.BaseUrl);

            await this.MakeAuthenticationAsync();
        }

        public ArangoDBCommand CreateCommand(HttpMethod httpMethod, string commandUri)
        {
            var command = new ArangoDBCommand(this, httpMethod, commandUri);

            return command;
        }

        public void Dispose()
        {
            this.HttpClient.Dispose();
        }

        private async Task MakeAuthenticationAsync()
        {
            var command = CreateCommand(HttpMethod.Post, AranogDBConstants.AuthenticationApi);

            var data = new AuthenticationRequest()
            {
                username = this.options.Username,
                password = this.options.Password
            };
            var result = await command.ExecuteAsync<AuthenticationRequest, AuthenticationResponse>(data);

            this.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Scheme, result.jwt);
        }

    }
}
