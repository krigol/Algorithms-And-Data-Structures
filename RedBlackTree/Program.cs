using System;

namespace RedBlackTree
{
    class Program
    {
        static void Main(string[] args)
        {
            RB tree = new RB();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(-1);
            tree.Insert(11);
            tree.Insert(6);
            tree.DisplayTree();
            tree.Delete(-1);
            tree.DisplayTree();
            tree.Delete(9);
            tree.DisplayTree();
            tree.Delete(5);
            tree.DisplayTree();
            Console.ReadLine();
        }
    }
}
