using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisProject.ArangoDB.Data.Classes.Requests
{
    public abstract class BaseAddDocumentRequest<T>
    {
        public T _key { get; set; }
    }
}
