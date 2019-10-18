using System;

namespace Huvermann.Extensions.DependencyInjection.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Startup startup = new Startup();
            startup.Start();
        }
    }
}
