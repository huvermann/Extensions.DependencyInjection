using Huvermann.Extensions.DependencyInjection.Abstractions.Modularity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Huvermann.Extensions.DependencyInjection.Modularity
{
    public static class ModuleLoader
    {
        private static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }

        public static IEnumerable<Type> GetModules<TModule>()
        {
            List<Type> result = new List<Type>();
            var it = typeof(TModule);
            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in allAssemblies)
            {
                var moduleTypes = GetLoadableTypes(assembly).Where(x => !x.IsInterface && it.IsAssignableFrom(x));
                result.AddRange(moduleTypes);
            }

            return result;
        }

        private static void LoadExternalPlugins()
        {
            var path = Thread.GetDomain().BaseDirectory;
            string[] pluginFiles = Directory.GetFiles(path, "*.dll");

            var allPlugins = pluginFiles.SelectMany(file => Assembly.LoadFile(file).GetExportedTypes())
                .Where(type => typeof(IRegistrationModule).IsAssignableFrom(type))
                .Select(t => (IRegistrationModule)Activator.CreateInstance(t))
                .ToArray();
        }

        public static void Configure(IServiceCollection services)
        {
            LoadExternalPlugins();
            var moduleTypes = GetModules<IRegistrationModule>();
            var moduleInstances = CreateModulesFromTypes(moduleTypes);
            foreach (var module in moduleInstances)
            {
                module.Configure(services);
            }
        }

        private static IEnumerable<IRegistrationModule> CreateModulesFromTypes(IEnumerable<Type> moduleTypes)
        {
            List<IRegistrationModule> result = new List<IRegistrationModule>();
            foreach (var item in moduleTypes)
            {
                object instance = Activator.CreateInstance(item);
                IRegistrationModule module = instance as IRegistrationModule;
                if (module != null)
                {
                    result.Add(module);
                }
            }
            return result;
        }
    }
}
