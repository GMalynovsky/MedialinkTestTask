using MediaLink.Lib;
using System;

namespace RootConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var client = MathClientBootstrapper.GetInjectedMathClient();
            Console.WriteLine(client.Add(3, 2));
            Console.WriteLine(client.Multiply(3, 2));
            Console.WriteLine(client.Divide(3, 2));
        }
    }
}
