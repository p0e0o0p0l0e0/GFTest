using System;

namespace DateTimeUtcNowTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DateTime dt;

            DateTime time = DateTime.Now;
            for(int i = 0; i < 10000; i++)
            {
                dt = DateTime.Now.AddSeconds(1);
            }
            Console.WriteLine("Now : {0}", (DateTime.Now - time).TotalMilliseconds); // 80.1674

            time = DateTime.UtcNow;
            TimeZoneInfo ChTimeZone = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
            for (int i = 0; i < 10000; i++)
            {
                dt = DateTime.UtcNow.AddSeconds(1);
                ChTimeZone.GetUtcOffset(dt);
            }
            Console.WriteLine("UtcNow : {0}", (DateTime.UtcNow - time).TotalMilliseconds); // 64.1545

        }
    }
}
