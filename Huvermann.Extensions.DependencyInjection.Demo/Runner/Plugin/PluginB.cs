using System;
using System.Collections.Generic;
using System.Text;

namespace Huvermann.Extensions.DependencyInjection.Demo.Runner.Plugin
{
    public class PluginB : IPlugin
    {
        public string PluginName()
        {
            return "I am Plugin B";
        }
    }
}
