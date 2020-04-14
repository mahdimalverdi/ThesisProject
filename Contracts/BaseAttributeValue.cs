using CharCode.Base.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThesisProject.Contracts
{
    public abstract class BaseAttributeValue
    {
        public long AttributeId { get; set; }

        public List<object> Value { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is BaseAttributeValue attributeValue)
            {
                return this.AttributeId.Equals(attributeValue.AttributeId);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.AttributeId.GetHashCode();
        }
    }

    public abstract class BaseAttributeValue<T> : BaseAttributeValue
    {
        public new List<T> Value { get { return base.Value.Cast<T>().ToList(); } set{ base.Value = value.Cast<object>().ToList(); } }
    }
}
