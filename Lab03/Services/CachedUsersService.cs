using Lab03.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Lab03.Services
{
    public class CachedUsersService
    {
        private TestingSystemDbContext db;
        private IMemoryCache cache;
        private int _rowsNumber;
        public CachedUsersService(TestingSystemDbContext context, IMemoryCache memoryCache)
        {
            db = context;
            cache = memoryCache;
            _rowsNumber = 20;
        }

        public IEnumerable<User> GetUsers()
        {
            string cacheKey = "GetUsers";
            IEnumerable<User> users = null;
            if (!cache.TryGetValue(cacheKey, out users))
            {

                Console.WriteLine($"Пользователи извлечены из базы данных");
                users = db.Users.Take(_rowsNumber).ToList();
                if (users != null)
                {
                    cache.Set(cacheKey, users,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(256)));
                }
            }
            else
            {

                Console.WriteLine($"Пользователи извлечены из кэша");
            }

            return users;
        }
    }
}
