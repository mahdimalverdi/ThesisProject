using System;
using System.Collections.Generic;
using System.Text;
using ThesisProject.Contracts.Elements;

namespace ThesisProject.Contracts.Instances
{
    public class LinkInstance : BaseInstance
    {
        public EntityInstance From { get; set; }

        public EntityInstance To { get; set; }
    }
}
