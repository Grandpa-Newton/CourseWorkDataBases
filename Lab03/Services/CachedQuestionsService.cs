using Lab03.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Lab03.Services
{
    public class CachedQuestionsService
    {
        private TestingSystemDbContext db;
        private IMemoryCache cache;
        private int _rowsNumber;
        public CachedQuestionsService(TestingSystemDbContext context, IMemoryCache memoryCache)
        {
            db = context;
            cache = memoryCache;
            _rowsNumber = 20;
        }

        public IEnumerable<Question> GetQuestions()
        {
            string cacheKey = "GetQuestions";
            IEnumerable<Question> questions = null;
            if (!cache.TryGetValue(cacheKey, out questions))
            {

                Console.WriteLine($"Вопросы извлечены из базы данных");
                questions = db.Questions.Take(_rowsNumber).ToList();
                if (questions != null)
                {
                    cache.Set(cacheKey, questions,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(256)));
                }
            }
            else
            {

                Console.WriteLine($"Вопросы извлечены из кэша");
            }

            return questions;
        }
    }
}
