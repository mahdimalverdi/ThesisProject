using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThesisProject.Abstraction;
using ThesisProject.Abstraction.Instances;
using ThesisProject.Benchmark;
using ThesisProject.Contracts.Instances;

namespace ThesisProject
{
    public class BenchmarkManager 
    {
        private readonly AddRangeBenchmark addRangeBenchmark;
        private readonly DeleteBenchmark deleteBenchmark;
        private readonly GetBenchmark getBenchmark;
        private readonly KShortestPathsBenchmark kShortestPathsBenchmark;
        private readonly SearchBenchmark searchBenchmark;
        private readonly ShortestPathBenchmark shortestPathBenchmark;
        private readonly UpdateBenchmark updateBenchmark;

        public BenchmarkManager(
            AddRangeBenchmark addRangeBenchmark,
            DeleteBenchmark deleteBenchmark,
            GetBenchmark getBenchmark,
            KShortestPathsBenchmark kShortestPathsBenchmark,
            SearchBenchmark searchBenchmark,
            ShortestPathBenchmark shortestPathBenchmark,
            UpdateBenchmark updateBenchmark)
        {
            this.addRangeBenchmark = addRangeBenchmark ?? throw new ArgumentNullException(nameof(addRangeBenchmark));
            this.deleteBenchmark = deleteBenchmark ?? throw new ArgumentNullException(nameof(deleteBenchmark));
            this.getBenchmark = getBenchmark ?? throw new ArgumentNullException(nameof(getBenchmark));
            this.kShortestPathsBenchmark = kShortestPathsBenchmark ?? throw new ArgumentNullException(nameof(kShortestPathsBenchmark));
            this.searchBenchmark = searchBenchmark ?? throw new ArgumentNullException(nameof(searchBenchmark));
            this.shortestPathBenchmark = shortestPathBenchmark ?? throw new ArgumentNullException(nameof(shortestPathBenchmark));
            this.updateBenchmark = updateBenchmark ?? throw new ArgumentNullException(nameof(updateBenchmark));
        }

        public async Task BenchmarkAsync(string database)
        {
            Console.WriteLine("AddBenchmarkAsync");
            await AddBenchmarkAsync(database);

            Console.WriteLine("GetBenchmarkAsync");
            await GetBenchmarkAsync(database);

            Console.WriteLine("KShortestPathsBenchmarkAsync");
            await KShortestPathsBenchmarkAsync(true, database);
            await KShortestPathsBenchmarkAsync(false, database);

            Console.WriteLine("SearchBenchmarkAsync");
            await SearchBenchmarkAsync(new DateTime(2015, 01, 01), database);

            Console.WriteLine("ShortestPathBenchmarkAsync");
            await ShortestPathBenchmarkAsync(true, database);
            await ShortestPathBenchmarkAsync(false, database);

            Console.WriteLine("UpdateBenchmarkAsync");
            await UpdateBenchmarkAsync(database);

            Console.WriteLine("DeleteBenchmarkAsync");
            await DeleteBenchmarkAsync(database);
        }

        private async Task KShortestPathsBenchmarkAsync(bool isDirective, string database)
        {
            for (int i = 1; i < 6; i++)
            {
                await KShortestPathsBenchmarkAsync(i, isDirective, database);
            }
        }

        private async Task AddBenchmarkAsync(string database)
        {
            await this.addRangeBenchmark.BenchmarkAsync(database);
        }

        private async Task DeleteBenchmarkAsync(string database)
        {
            await this.deleteBenchmark.BenchmarkAsync(database);
        }

        private async Task GetBenchmarkAsync(string database)
        {
            await this.getBenchmark.BenchmarkAsync(database);
        }

        private async Task KShortestPathsBenchmarkAsync(int k, bool isDirective, string database)
        {
            this.kShortestPathsBenchmark.Init(k, isDirective);

            await this.kShortestPathsBenchmark.BenchmarkAsync(database);
        }

        private async Task SearchBenchmarkAsync(DateTime dateTime, string database)
        {
            this.searchBenchmark.Init(dateTime);

            await this.searchBenchmark.BenchmarkAsync(database);
        }

        private async Task ShortestPathBenchmarkAsync(bool isDirective, string database)
        {
            this.shortestPathBenchmark.Init(isDirective);

            await this.shortestPathBenchmark.BenchmarkAsync(database);
        }

        private async Task UpdateBenchmarkAsync(string database)
        {
            await this.updateBenchmark.BenchmarkAsync(database);
        }
    }
}
