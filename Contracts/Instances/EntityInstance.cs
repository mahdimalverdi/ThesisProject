using System;
using System.Collections.Generic;
using System.Text;
using ThesisProject.Contracts.Elements;

namespace ThesisProject.Contracts.Instances
{
    public class EntityInstance : BaseInstance
    {
        public new EntityElement Element { get { return base.Element as EntityElement; } set { base.Element = value; } }
    }
}
