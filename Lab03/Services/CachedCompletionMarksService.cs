using Lab03.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Lab03.Services
{
    public class CachedCompletionMarksService
    {
        private TestingSystemDbContext db;
        private IMemoryCache cache;
        private int _rowsNumber;
        public CachedCompletionMarksService(TestingSystemDbContext context, IMemoryCache memoryCache)
        {
            db = context;
            cache = memoryCache;
            _rowsNumber = 20;
        }

        public IEnumerable<CompletionMark> GetCompletionMarks()
        {
            string cacheKey = "GetCompletionMarks";
            IEnumerable<CompletionMark> completionMarks = null;
            if (!cache.TryGetValue(cacheKey, out completionMarks))
            {

                Console.WriteLine($"Отметки о прохождении извлечены из базы данных");
                completionMarks = db.CompletionMarks.Take(_rowsNumber).ToList();
                if (completionMarks != null)
                {
                    cache.Set(cacheKey, completionMarks,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(256)));
                }
            }
            else
            {

                Console.WriteLine($"Отметки о прохождении извлечены из кэша");
            }

            return completionMarks;
        }
    }
}
