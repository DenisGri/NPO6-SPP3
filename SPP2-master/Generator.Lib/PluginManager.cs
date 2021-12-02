using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Generator.SDK;

namespace Generator
{
    public static class PluginManager
    {
        private const string Dir = "../../../../Plugins";

        public static Dictionary<Type, IGenerator> LoadPlugins(Random random)
        {
            var pluginDictionary = new Dictionary<Type, IGenerator>();
            
            var files = Directory.GetFiles(Dir, "*.dll");

            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), file));
                
                var pluginTypes = assembly.GetTypes()
                    .Where(t => typeof(IGenerator).IsAssignableFrom(t) && !t.IsInterface)
                    .ToArray();

                foreach (var pluginType in pluginTypes)
                {
                    var pluginInstance = (IGenerator)Activator.CreateInstance(pluginType, random);
                    pluginDictionary.Add(pluginInstance.Type, pluginInstance);                    
                    Console.WriteLine(pluginInstance);
                }

            }
            Console.WriteLine("Get all plugins");
            return pluginDictionary;
        }

    }

}