using System;
using System.Linq;

namespace Lesson1.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            DataRepository repository = new DataRepository();
            repository.Initialize();

            ConsoleMenuController menuController = new ConsoleMenuController(repository);
            menuController.Initialize();
            menuController.EnterMainMenu();
            
        }
    }
}
