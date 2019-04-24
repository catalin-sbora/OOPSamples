using System;
using System.IO;
using System.Reflection;
using Lesson2.MainApp;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuController menuController = new MenuController();
            menuController.Initialize();     
            ShapePluginManager pluginManager = new ShapePluginManager();
            try
            {
                pluginManager.LoadPlugins();       
                foreach(var plugin in pluginManager.Plugins)
                {
                    menuController.AddAvailableShape(plugin);
                }
            }
            catch(DirectoryNotFoundException e)
            {
                Console.WriteLine($"WARNING: The plugins directory: {e.Message} does not exists. Press any key to continue ...");
                Console.ReadLine();
            }
            catch(ReflectionTypeLoadException e)
            {
                Console.WriteLine("TypeLoad error " + e.Message);
                return;
            }
            catch(Exception e)
            {
            
                Console.WriteLine("Unexpected error occured while loading the plugins. " + e.Message);
                return;
            }

            menuController.EnterMenu();
        
        }
    }
}
