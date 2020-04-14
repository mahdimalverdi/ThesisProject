using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisProject.ArangoDB
{
    public class ArangoDBContext
    {
        private readonly ArangoDBConnection connection;

        public ArangoDBContext(ArangoDBConnectionOptions options)
        {
            this.connection = new ArangoDBConnection(options ?? throw new ArgumentNullException(nameof(options)));
            this.connection.ConnectAsync().Wait();
        }
    }
}
