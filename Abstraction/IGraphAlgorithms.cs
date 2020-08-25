using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThesisProject.Abstraction
{
    public interface IGraphAlgorithms
    {
        Task<List<List<Guid>>> KShortestPathAsync(Guid start, Guid end, int k, bool isDirective);
        Task<List<Guid>> SearchAsync(DateTime dateTime);
        Task<List<Guid>> ShortestPathAsync(Guid start, Guid end, bool isDirective);
    }
}
