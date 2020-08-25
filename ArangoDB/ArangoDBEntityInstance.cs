using System;
using System.Collections.Generic;
using System.Text;
using ThesisProject.Contracts.Instances;

namespace ThesisProject.ArangoDB
{
    public class ArangoDBEntityInstance : EntityInstance
    {
        public Guid _key
        {
            get
            {
                return this.Id;
            }
            set
            {
                this.Id = value;
            }
        }
    }
}
