using System;
using Lesson2.Implementations;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuController menuController = new MenuController();
            menuController.Initialize();            
            menuController.AddAvailableShape(new CirclePlugin());
            menuController.EnterMenu();
        
        }
    }
}
