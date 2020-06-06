using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisProject.ArangoDB.Data.Classes.Requests
{
    public class AuthenticationRequest
    {
        public string username { get; set; }

        public string password { get; set; }
    }
}
