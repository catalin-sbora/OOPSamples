using System;

namespace Generics
{
    
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> myTree = new BinaryTree<int>();
            myTree.Add(10);
            myTree.Add(20);
            myTree.Add(40);

            var treeList = myTree.ToList();

            foreach(var el in treeList)
            {
                Console.WriteLine($"{el}");
            }

           

        }
    }
}
