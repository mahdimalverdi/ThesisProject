using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThesisProject.Abstraction;

namespace Thesis.OrientDB
{
    internal class OrientDBGraphAlgorithms : IGraphAlgorithms
    {
        public Task<List<List<Guid>>> KShortestPathAsync(Guid start, Guid end, int k, bool isDirective)
        {
            throw new NotImplementedException();
        }

        public Task<List<Guid>> SearchAsync(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public Task<List<Guid>> ShortestPathAsync(Guid start, Guid end, bool isDirective)
        {
            throw new NotImplementedException();
        }
    }
}