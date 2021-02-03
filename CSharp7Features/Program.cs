using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp7Features
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = new Demo();
        }

        #region generalized async return types
        //static async Task Main()
        //{

        //    Console.WriteLine(await GetSomeValueAsync());
        //    Console.WriteLine($"Wait 1 second");
        //    await Task.Delay(1000);
        //    Console.WriteLine("");

        //    Console.WriteLine(await GetSomeValueAsync());
        //    Console.WriteLine($"Wait 7 seconds");
        //    await Task.Delay(7000);
        //    Console.WriteLine("");

        //    Console.WriteLine(await GetSomeValueAsync());

        //    _ = Console.ReadLine();
        //}


        //public static async ValueTask<int> GetSomeValueAsync()
        //{
        //    Console.WriteLine($"DateTime.Now = {DateTime.Now.TimeOfDay}");
        //    Console.WriteLine($"ValueCache.TimeToLive = {ValueCache.TimeToLive.TimeOfDay}");

        //    if (DateTime.Now <= ValueCache.TimeToLive)
        //    {
        //        Console.WriteLine($"Return Cached value");
        //        return ValueCache.CachedValue;
        //    }

        //    var val = await DoSomethingAsync();
        //    ValueCache.CachedValue = val;
        //    Console.WriteLine($"Set time to live at 5 seconds");
        //    ValueCache.TimeToLive = DateTime.Now.AddSeconds(5.0);

        //    Console.WriteLine($"Return value");
        //    return val;
        //}


        //private static async Task<int> DoSomethingAsync()
        //{
        //    await Task.Delay(1);
        //    return DateTime.Now.Second;
        //} 
        #endregion

    }

    #region generalized async return types
    //public static class ValueCache
    //{
    //    public static int CachedValue { get; set; } = 0;
    //    public static DateTime TimeToLive { get; set; } = DateTime.MinValue;
    //} 
    #endregion
}
