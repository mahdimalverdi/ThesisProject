using System;
using System.Collections.Generic;
using System.Text;
using ThesisProject.Contracts.Elements;

namespace ThesisProject.Contracts.Instances
{
    public class LinkInstance : BaseInstance
    {
        public Guid From { get; set; }

        public Guid To { get; set; }
    }
}
