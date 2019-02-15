using System;
using System.Threading;
using System.Threading.Tasks;
using LazyCache;
using TestCache.CsbMigration.OAuthService;

namespace TestCache
{
    class Program
    {
        private DateTimeOffset testTime;
        static void Main(string[] args)
        {
            var testObject = new Test();

            var i = testObject.GetCachedObject();
            Console.WriteLine(i);
            Thread.Sleep(3000);
            i = testObject.GetCachedObject();
            Console.WriteLine(i);
        }
    }


}
