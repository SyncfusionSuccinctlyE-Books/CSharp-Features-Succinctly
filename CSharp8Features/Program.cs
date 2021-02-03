using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp8Features
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = new Demo();

            _ = Console.ReadLine();
        }


        #region asynchronous streams
        //static async Task Main()
        //{
        //    //foreach (var item in await GetSomethingAsync())
        //    //{
        //    //    Console.WriteLine(item);
        //    //}


        //    await foreach (var item in GetSomethingAsync())
        //    {
        //        Console.WriteLine(item);
        //    }


        //    _ = Console.ReadLine();
        //}




        ////static async Task<IEnumerable<int>> GetSomethingAsync()
        ////{
        ////    var iValues = new List<int>();
        ////    for (var i = 0; i <= 10; i++)
        ////    {
        ////        await Task.Delay(1000);
        ////        iValues.Add(i);
        ////    }
        ////    return iValues;
        ////}

        //static async IAsyncEnumerable<int> GetSomethingAsync()
        //{
        //    for (var i = 0; i <= 10; i++)
        //    {
        //        yield return i;
        //        await Task.Delay(1000);
        //    }
        //} 
        #endregion


    }
}
