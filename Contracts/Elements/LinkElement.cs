using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisProject.Contracts.Elements
{
    public sealed class LinkElement : BaseElement
    {
        public EntityElement From { get; set; }

        public EntityElement To { get; set; }
    }
}
