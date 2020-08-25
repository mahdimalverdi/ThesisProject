using System;
using System.Collections.Generic;
using System.Text;
using ThesisProject.Contracts.Instances;

namespace Utility
{
    public interface IDataGenerator
    {
        public List<EntityInstance> EntityInstances { get; }
        public List<LinkInstance> LinkInstances { get; }
    }
}
