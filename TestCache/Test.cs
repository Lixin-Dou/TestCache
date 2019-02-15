namespace TestCache
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Runtime;
    using LazyCache;

    namespace CsbMigration.OAuthService
    {
        public class Test
        {
            private int cacheTimeInSeconds = 5;
            private IAppCache cache;
            public Test()
            {
                this.cache = new CachingService();
            }
           public string GetCachedObject()
            {
                Func<Task<string>> fetchObjectFunc = FetchObject;
                var token = this.cache
                    .GetOrAdd("Token", fetchObjectFunc, DateTimeOffset.UtcNow.AddSeconds(this.cacheTimeInSeconds))
                    .GetAwaiter()
                    .GetResult();
                return token;
            }

            private Task<string> FetchObject()
            {
                cacheTimeInSeconds = 5;
                Console.WriteLine("Get object");
                return Task.FromResult(DateTimeOffset.UtcNow.ToString("o"));
            }
        }
    }
}