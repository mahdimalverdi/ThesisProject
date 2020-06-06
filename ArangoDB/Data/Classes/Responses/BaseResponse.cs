using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisProject.ArangoDB.Data.Classes.Responses
{
    public abstract class BaseResponse
    {
        public bool Error { get; set; }

        public int Code { get; set; }
    }
}
