using MediaLink.Lib;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var client = new MathWebClient();
            client.Add(1, 2);
        }
    }
}
