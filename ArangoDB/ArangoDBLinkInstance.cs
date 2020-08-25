using System;
using System.Collections.Generic;
using System.Text;
using ThesisProject.Contracts.Instances;

namespace ThesisProject.ArangoDB
{
    public class ArangoDBLinkInstance: LinkInstance
    {
        public Guid _key
        {
            get
            {
                return  this.Id;
            }
            set
            {
                this.Id = value;
            }
        }

        public string _to
        {
            get
            {
                return $"{ArangoDBConsts.EntitiesCollectionName}/{this.To}" ;
            }
            set
            {
                this.To = Guid.Parse(value.Replace($"{ ArangoDBConsts.EntitiesCollectionName}/", ""));
            }
        }

        public string _from
        {
            get
            {
                return $"{ArangoDBConsts.EntitiesCollectionName}/{this.From}";
            }
            set
            {
                this.From = Guid.Parse(value.Replace($"{ ArangoDBConsts.EntitiesCollectionName}/", ""));
            }
        }
    }
}
