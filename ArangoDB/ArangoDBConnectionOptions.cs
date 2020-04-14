using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisProject.ArangoDB
{
    public class ArangoDBConnectionOptions
    {
        internal ArangoDBConnectionOptions(string baseUrl, string username, string password)
        {
            BaseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        internal string BaseUrl { get; private set; }
        internal string Username { get; private set; }
        internal string Password { get; private set; }
    }
}
