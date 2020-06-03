using MyBinaryTree.Model;
using System;

namespace MyBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var myTree = new MyTree<int>();
            for (int i = 0; i < 10; i++)
            {
                myTree.Add(i);
            }
            myTree.Add(5);
            myTree.Add(7);
            myTree.Add(3);
            myTree.Add(1);
            myTree.Add(2);
            myTree.Add(8);
            myTree.Add(6);
            myTree.Add(9);
            myTree.Add(4);
            myTree.WriteTree();
            Console.WriteLine("==================");
            Console.WriteLine(myTree);
            Console.WriteLine("==================");
            Console.WriteLine("Preorder:");
            foreach (var item in myTree.Preorder())
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n==================");
            Console.WriteLine("Postorder:");
            foreach (var item in myTree.Postorder())
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n==================");
            Console.WriteLine("Inorder:");
            foreach (var item in myTree.Inorder())
            {
                Console.Write(item + " ");
            }
            Console.ReadLine();
        }
    }
}
