using Lab03.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Lab03.Services
{
    public class CachedResultsService
    {
        private TestingSystemDbContext db;
        private IMemoryCache cache;
        private int _rowsNumber;
        public CachedResultsService(TestingSystemDbContext context, IMemoryCache memoryCache)
        {
            db = context;
            cache = memoryCache;
            _rowsNumber = 20;
        }

        public IEnumerable<Result> GetResults()
        {
            IEnumerable<Result> results = new List<Result>();
            results = db.Results.Take(_rowsNumber).ToList();

            return results;
        }

        public IEnumerable<Result> GetResults(string cacheKey)
        {
            IEnumerable<Result> results = null;
            if (!cache.TryGetValue(cacheKey, out results))
            {

                Console.WriteLine($"Результаты извлечены из базы данных");
                results = db.Results.Take(_rowsNumber).ToList();
                if (results != null)
                {
                    cache.Set(cacheKey, results,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(256)));
                }
            }
            else
            {

                Console.WriteLine($"Результаты извлечены из кэша");
            }

            return results;
        }
    }
}
