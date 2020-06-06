using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisProject.ArangoDB.Data.Classes.Responses
{
    public sealed class GetAllCollectionResponse : BaseResponse
    {
        public List<Collection> Result { get; set; }
    }
}
