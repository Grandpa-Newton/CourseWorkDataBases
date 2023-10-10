using Lab03.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Lab03.Services
{
    public class CachedAnswersService
    {
        private TestingSystemDbContext db;
        private IMemoryCache cache;
        private int _rowsNumber;
        public CachedAnswersService(TestingSystemDbContext context, IMemoryCache memoryCache)
        {
            db = context;
            cache = memoryCache;
            _rowsNumber = 20;
        }

     /*   public IEnumerable<Answer> GetAnswers()
        {
            return db.Answers.Take(_rowsNumber).ToList();
        }*/

        public Answer GetAnswer(int id)
        {
            cache.TryGetValue(id, out Answer? answer);

            if(answer == null)
            {
                answer = db.Answers.FirstOrDefault(a => a.AnswerId == id);

                if (answer != null)
                {
                    Console.WriteLine($"{answer.AnswerId} извлечён из базы данных");
                    cache.Set(answer.AnswerId, answer, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(256)));
                }
            }
            else
            {
                Console.WriteLine($"{answer.AnswerId} извлечен из кэша");
            }

            return answer;
        }


      /*  public void AddAnswer(string cacheKey)
        {
            IEnumerable<Answer> answers = db.Answers.Take(_rowsNumber);

            cache.Set(cacheKey, answers, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(256)
            });
        }*/

        public IEnumerable<Answer> GetAnswers()
        {
            string cacheKey = "GetAnswers";
            IEnumerable<Answer> answers = null;
            if(!cache.TryGetValue(cacheKey, out answers))
            {

                Console.WriteLine($"Ответы извлечены из базы данных");
                answers = db.Answers.Take(_rowsNumber).ToList();
                if(answers != null)
                {
                    cache.Set(cacheKey, answers,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(256)));
                }
            }
            else
            {

                Console.WriteLine($"Ответы извлечены из кэша");
            }

            return answers;
        }
    }
}
