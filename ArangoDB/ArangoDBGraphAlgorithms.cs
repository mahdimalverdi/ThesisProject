using ArangoDBNetStandard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisProject.Abstraction;

namespace ThesisProject.ArangoDB
{
    public class ArangoDBGraphAlgorithms : IGraphAlgorithms
    {
        private readonly ArangoDBClient arangoDBClient;

        public ArangoDBGraphAlgorithms(ArangoDBClient arangoDBClient)
        {
            this.arangoDBClient = arangoDBClient ?? throw new ArgumentNullException(nameof(arangoDBClient));
        }

        public async Task<List<Guid>> ShortestPathAsync(Guid start, Guid end, bool isDirective)
        {
            string type = isDirective ? "OUTBOUND" : "ANY";

            var cursor = await arangoDBClient.Cursor.PostCursorAsync<Guid>(@$"
                  FOR a IN Entities FILTER a.Id == '{start}'
                  FOR d IN Entities FILTER d.Id == '{end}'
                  FOR v,e IN {type} SHORTEST_PATH  a TO d Links RETURN v.Id");

            return cursor.Result.ToList();
        }

        public async Task<List<List<Guid>>> KShortestPathAsync(Guid start, Guid end, int k, bool isDirective)
        {
            string type = isDirective ? "OUTBOUND" : "ANY";

            var cursor = await arangoDBClient.Cursor.PostCursorAsync<List<Guid>>(@$"
                  FOR a IN Entities FILTER a.Id == '{start}'
                  FOR d IN Entities FILTER d.Id == '{end}'
                  FOR p IN {type} K_SHORTEST_PATHS  a TO d Links limit {k} RETURN p.vertices[*].Id");

            return cursor.Result.ToList();
        }

        public async Task<List<Guid>> SearchAsync(DateTime dateTime)
        {
            var cursor = await arangoDBClient.Cursor.PostCursorAsync<Guid>($@"
                            for l in Links
                                let attribute = 
                                    (for a in l.AttributeValues[*]
                                        filter a.AttributeId == 3
                                                return a.Values)
                                Let values = 
                                    (for a in attribute[*]
                                    let value = DATE_TRUNC( a[0], 'day')
                                    filter  value > ""{dateTime:yyyy-MM-dd}""
                                        return value)
                                filter COUNT_DISTINCT(values) > 0
                                limit 10
                                return l.Id");

            return cursor.Result.ToList();
        }
    }
}
