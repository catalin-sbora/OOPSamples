using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Lesson2.Abstractions;


namespace Lesson2.MainApp
{
    public class ShapePluginManager
    {        

        public ShapePluginManager()
        {
            Plugins = new List<IShapePlugin>();
        }
        public List<IShapePlugin> Plugins { get; protected set; }

        public void LoadPlugins()
        {
                        
            var executableLocation = Assembly.GetEntryAssembly().Location;
            var path = Path.Combine(Path.GetDirectoryName(executableLocation), "Plugins");
            var assemblies = Directory
                        .GetFiles(path, "*.dll", SearchOption.TopDirectoryOnly)
                        .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
                        .ToList();
            
           foreach(var assembly in assemblies)
           {
               var pluginInstances = LoadPluginsFromAssembly(assembly);
               Plugins.AddRange(pluginInstances);               
           }            
        }

        private IEnumerable<IShapePlugin> LoadPluginsFromAssembly(Assembly assemblyToScan)
        {
            var currentList = new List<IShapePlugin>();
            var exportedTypes = assemblyToScan.ExportedTypes;            
            var interfaceType = typeof(IShapePlugin);

            foreach(var type in exportedTypes)
            {
                if (interfaceType.IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                {
                   var pluginInstance = (IShapePlugin)Activator.CreateInstance(type);
                   currentList.Add(pluginInstance);
                }
            }

            return currentList;
        }

        
    }

}