using CharCode.Base.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThesisProject.Contracts
{
    public class BaseAttributeValue
    {
        public long AttributeId { get; set; }

        public HashSet<object> Values { get; set; }

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
        public new HashSet<T> Values { get { return base.Values.Cast<T>().ToHashSet(); } set{ base.Values = value.Cast<object>().ToHashSet(); } }
    }
}
