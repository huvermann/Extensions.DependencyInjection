using System;
using System.Collections.Generic;
using System.Text;

namespace Huvermann.Extensions.DependencyInjection.Demo.Runner
{
    public class Foo : IFooService
    {
        public Foo()
        {
            Console.WriteLine("The constructor if Foo has been called.");
        }

        public void DoSomething()
        {
            Console.WriteLine("Foo is doing someting...");
        }
    }
}
