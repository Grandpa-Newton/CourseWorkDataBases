using Lab03.Models;
using Microsoft.Extensions.Caching.Memory;
using static System.Net.Mime.MediaTypeNames;

namespace Lab03.Services
{
    public class CachedTestsService
    {
        private TestingSystemDbContext db;
        private IMemoryCache cache;
        private int _rowsNumber;
        public CachedTestsService(TestingSystemDbContext context, IMemoryCache memoryCache)
        {
            db = context;
            cache = memoryCache;
            _rowsNumber = 20;
        }

        public IEnumerable<Test> GetTests()
        {
            IEnumerable<Test> tests = new List<Test>();
            tests = db.Tests.ToList();

            return tests;
        }

        public IEnumerable<Test> GetTests(string cacheKey)
        {
           // string cacheKey = "GetTests";
            IEnumerable<Test> tests = null;
            if (!cache.TryGetValue(cacheKey, out tests))
            {

                Console.WriteLine($"Тесты извлечены из базы данных");
                tests = db.Tests.Take(_rowsNumber).ToList();
                if (tests != null)
                {
                    cache.Set(cacheKey, tests,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(256)));
                }
            }
            else
            {

                Console.WriteLine($"Тесты извлечены из кэша");
            }

            return tests;
        }
    }
}
