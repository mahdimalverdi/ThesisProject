using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisProject.ArangoDB.Data
{
    public class ArangoDBConnectionOptionsBuilder
    {
        private readonly string baseUrl;
        private readonly string username;
        private readonly string password;

        public ArangoDBConnectionOptionsBuilder(string baseUrl, string username, string password)
        {
            this.baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            this.username = username ?? throw new ArgumentNullException(nameof(username));
            this.password = password ?? throw new ArgumentNullException(nameof(password));

            this.Options = new ArangoDBConnectionOptions(baseUrl, username, password);
        }

        public ArangoDBConnectionOptions Options { get; private set; }
    }
}
