
using System;
using System.Reflection;

namespace Huvermann.Extensions.DependencyInjection.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Class1 test = new Class1();

            Assembly EntryAssembly;

            EntryAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            foreach (AssemblyName Name in EntryAssembly.GetReferencedAssemblies())
            {
                Console.WriteLine("Name: {0}", Name.ToString());
            }
            

            Startup startup = new Startup();
            startup.Start();
        }
    }
}
