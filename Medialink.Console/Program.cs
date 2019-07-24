using MediaLink.Lib;
using System;

namespace Medialink.RunConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MathWebClient();
            var result = client.Add(2, 3);
            Console.WriteLine("Hello World!");
        }
    }
}
