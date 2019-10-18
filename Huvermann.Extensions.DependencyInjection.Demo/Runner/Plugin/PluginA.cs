using System;
using System.Collections.Generic;
using System.Text;

namespace Huvermann.Extensions.DependencyInjection.Demo.Runner.Plugin
{
    public class PluginA : IPlugin
    {
        public string PluginName()
        {
            return $"I am plugin A";
        }
    }
}
