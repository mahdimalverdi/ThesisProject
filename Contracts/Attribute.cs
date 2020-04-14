using CharCode.Base.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using ThesisProject.Contracts.Enums;

namespace ThesisProject.Contracts
{
    public sealed class Attribute : IModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public AttributeType Type { get; set; }
    }
}
