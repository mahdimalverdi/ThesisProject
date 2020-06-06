using CharCode.Base.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisProject.Contracts
{
    public abstract class BaseInstance : IModel<Guid>
    {
        public Guid Id { get; set; }

        public long ElementId { get; set; }

        public HashSet<BaseAttributeValue> AttributeValues { get; set; }
    }
}
