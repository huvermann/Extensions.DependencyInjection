//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;

//namespace Huvermann.Extensions.DependencyInjection.Modularity
//{
//    public static class AssemblyScanner
//    {
//        private static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
//        {
//            if (assembly == null) throw new ArgumentNullException("assembly");
//            try
//            {
//                return assembly.GetTypes();
//            }
//            catch (ReflectionTypeLoadException e)
//            {
//                return e.Types.Where(t => t != null);
//            }
//        }

//        public static IEnumerable<Type> GetModules<TModule>()
//        {
//            List<Type> result = new List<Type>();
//            var it = typeof(TModule);
//            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
//            foreach (var assembly in allAssemblies)
//            {
//                var moduleTypes = GetLoadableTypes(assembly).Where(x => it.IsAssignableFrom(x));
//                result.AddRange(moduleTypes);
//            }

//            return result;
//        }

//        //void Configure(IServiceCollection services)
//        //{
//        //    List<Type> modules = new List<Type>();
//        //    var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
//        //    foreach (var assembly in allAssemblies)
//        //    {
//        //        var ldblTypes = GetLoadableTypes(assembly);
//        //        modules.AddRange(ldblTypes);
//        //    }

//        //}
//    }
//}
