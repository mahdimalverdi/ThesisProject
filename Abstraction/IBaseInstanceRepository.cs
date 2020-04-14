using System;
using System.Collections.Generic;
using System.Text;
using ThesisProject.Contracts;

namespace ThesisProject.Abstraction
{
    public interface IBaseInstanceRepository<TInstance> : IBaseRepository<TInstance, Guid> where TInstance: BaseInstance
    {
    }
}
