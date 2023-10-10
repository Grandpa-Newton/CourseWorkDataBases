using Lab03.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Lab03.Services
{
    public class CachedTopicsService
    {
        private TestingSystemDbContext db;
        private IMemoryCache cache;
        private int _rowsNumber;
        public CachedTopicsService(TestingSystemDbContext context, IMemoryCache memoryCache)
        {
            db = context;
            cache = memoryCache;
            _rowsNumber = 5;
        }

        public IEnumerable<Topic> GetTopics()
        {
            string cacheKey = "GetTopics";
            IEnumerable<Topic> topics = null;
            if (!cache.TryGetValue(cacheKey, out topics))
            {

                Console.WriteLine($"Тематики извлечены из базы данных");
                topics = db.Topics.Take(_rowsNumber).ToList();
                if (topics != null)
                {
                    cache.Set(cacheKey, topics,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(256)));
                }
            }
            else
            {

                Console.WriteLine($"Тематики извлечены из кэша");
            }

            return topics;
        }
    }
}
