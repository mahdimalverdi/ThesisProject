using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisProject.ArangoDB.Classes
{
    public sealed class GetAllCollectionResponse : BaseResponse
    {
        public List<Collection> Result { get; set; }
    }
}
