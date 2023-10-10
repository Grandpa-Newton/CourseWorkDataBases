using Lab03.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Lab03.Services
{
    public class CachedDifficultiesService
    {
        private TestingSystemDbContext db;
        private IMemoryCache cache;
        private int _rowsNumber;
        public CachedDifficultiesService(TestingSystemDbContext context, IMemoryCache memoryCache)
        {
            db = context;
            cache = memoryCache;
            _rowsNumber = 3;
        }

        public IEnumerable<Difficulty> GetDifficulties()
        {
            string cacheKey = "GetDifficultys";
            IEnumerable<Difficulty> difficulties = null;
            if (!cache.TryGetValue(cacheKey, out difficulties))
            {

                Console.WriteLine($"Сложности извлечены из базы данных");
                difficulties = db.Difficulties.Take(_rowsNumber).ToList();
                if (difficulties != null)
                {
                    cache.Set(cacheKey, difficulties,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(256)));
                }
            }
            else
            {

                Console.WriteLine($"Сложности извлечены из кэша");
            }

            return difficulties;
        }
    }
}
