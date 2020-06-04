using System;
using System.Collections.Generic;

namespace MyBinaryTree.Model
{
    public class MyTree<T>
        where T:IComparable, IComparable<T>
    {
        /// <summary>
        /// Root element.
        /// </summary>
        public Node<T> Root { get; private set; }
        /// <summary>
        /// Quantity of elements.
        /// </summary>
        public int Count { get; private set; } 
        /// <summary>
        /// Adding of element.
        /// </summary>
        /// <param name="data"></param>
        public void Add (T data)
        {
            if (Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return;
            }
            Root.Add(data);
            Count++;
        }
        /// <summary>
        /// Going within elements by preordering.
        /// </summary>
        /// <returns></returns>
        public List<T> Preorder()
        {
            if (Root == null)
            {
                return new List<T>();
            }
            return Preorder(Root);
        }
        /// <summary>
        /// Helper for going within elements by preordering.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private List<T> Preorder(Node<T> node)
        {
            var lst = new List<T>();
            if(node !=null)
            {
                lst.Add(node.Data);
                if (node.Left!=null)
                {
                    lst.AddRange(Preorder(node.Left));
                }
                if (node.Right != null)
                {
                    lst.AddRange(Preorder(node.Right));
                }
            }
            return lst;
        }
        /// <summary>
        /// Going within elements by postordering.
        /// </summary>
        /// <returns></returns>
        public List<T> Postorder()
        {
            if (Root == null)
            {
                return new List<T>();
            }
            return Postorder(Root);
        }
        /// <summary>
        /// Helper for going within elements by postordering.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private List<T> Postorder(Node<T> node)
        {
            var lst = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    lst.AddRange(Postorder(node.Left));
                }
                if (node.Right != null)
                {
                    lst.AddRange(Postorder(node.Right));
                }
                lst.Add(node.Data);
            }
            return lst;
        }
        /// <summary>
        /// Going within elements by inordering.
        /// </summary>
        /// <returns></returns>
        public List<T> Inorder()
        {
            if (Root == null)
            {
                return new List<T>();
            }
            return Inorder(Root);
        }
        /// <summary>
        /// Helper for going within elements by inordering.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private List<T> Inorder(Node<T> node)
        {
            var lst = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    lst.AddRange(Inorder(node.Left));
                }
                lst.Add(node.Data);
                if (node.Right != null)
                {
                    lst.AddRange(Inorder(node.Right));
                } 
            }
            return lst;
        }
        /// <summary>
        /// Helper to get node of the tree as string.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private string GetNodeString(Node<T> node)
        {
            string result = $"Node {node.Data}: ";
            if (node.Left != null && node.Right != null)
            {
                result += $"{node.Left} {node.Right}\n";
            }
            if (node.Left != null && node.Right == null)
            {
                result += $"{node.Left}\n";
            }
            if (node.Left == null && node.Right != null)
            {
                result += $"{node.Right}\n";
            }
            if (node.Left == null && node.Right == null)
            {
                result += "No nodes\n";
            }
            return result;
        }
        /// <summary>
        /// Going within elements by breadthordering.
        /// </summary>
        /// <returns></returns>
        public List<T> BreadthOrder()
        {
            if (Root == null)
            {
                return new List<T>();
            }
            var lst = new List<T>();
            var q = new Queue<Node<T>>();
            q.Enqueue(Root);
            while (!(q.Count == 0))
            {
                var current = q.Dequeue();
                lst.Add(current.Data);
                if (current.Left != null)
                {
                    q.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    q.Enqueue(current.Right);
                }
            }
            return lst;
        }
        /// <summary>
        /// Method to get the tree as string as Preorder.
        /// </summary>
        /// <returns></returns>
        public string GetTreeString()
        {
            string result = "";
            if (Root == null)
            {
                result = "Empty Tree";
            }
            result += GetTreeString(Root);
            return result;
        }
        /// <summary>
        /// Helper to get the tree as string as Preorder.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private string GetTreeString(Node<T> node)
        {
            string result = "";
            if (node != null)
            {
                result += GetNodeString(node);
                if (node.Left != null && node.Right != null)
                {
                    result += GetTreeString(node.Left);
                    result += GetTreeString(node.Right);
                }
                if (node.Left != null && node.Right == null)
                {
                    result += GetTreeString(node.Left);
                }
                if (node.Left == null && node.Right != null)
                {
                    result += GetTreeString(node.Right);
                }
            }
            return result;
        }
        /// <summary>
        /// Override method to get the the tree as string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return GetTreeString2();
        }
        /// <summary>
        /// Writing the tree to console.
        /// </summary>
        public void WriteTree()
        {
            if (Root == null)
            {
                Console.WriteLine("Empty Tree");
            }
            WriteTree(Root);
        }
        /// <summary>
        /// Heleper to write the tree to console.
        /// </summary>
        /// <param name="node"></param>
        private void WriteTree(Node<T> node)
        {
            if (node != null)
            {
                WriteNode(node);
                if (node.Left != null && node.Right != null)
                {
                    WriteTree(node.Left);
                    WriteTree(node.Right);
                }
                if (node.Left != null && node.Right == null)
                {
                    WriteTree(node.Left);
                }
                if (node.Left == null && node.Right != null)
                {
                    WriteTree(node.Right);
                }
            }
        }
        /// <summary>
        /// Write nodes of the tree to console.
        /// </summary>
        /// <param name="node"></param>
        private void WriteNode(Node<T> node)
        {
            Console.Write("Node " + node.Data + ": ");
            if (node.Left != null && node.Right != null)
            {
                Console.WriteLine(node.Left + " " + node.Right);
            }
            if (node.Left != null && node.Right == null)
            {
                Console.WriteLine(node.Left);
            }
            if (node.Left == null && node.Right != null)
            {
                Console.WriteLine(node.Right);
            }
            if (node.Left == null && node.Right == null)
            {
                Console.WriteLine("No nodes");
            }
        }
        /// <summary>
        /// Method to get the tree as string as BreadthOrder.
        /// </summary>
        /// <returns></returns>
        public string GetTreeString2()
        {
            if (Root == null)
            {
                return "Empty Tree";
            }
            string result = "";
            var q = new Queue<Node<T>>();
            q.Enqueue(Root);
            while (!(q.Count ==0))
            {
                var current = q.Dequeue();
                result += GetNodeString(current);
                if (current.Left != null)
                {
                    q.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    q.Enqueue(current.Right);
                    
                }
            }
            return result;
        }
    }
}
