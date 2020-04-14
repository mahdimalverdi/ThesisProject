using CharCode.Base.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisProject.Contracts
{
    public abstract class BaseElement : IModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public byte[] Icon { get; set; }

        public List<Attribute> Attributes { get; set; }
    }
}
