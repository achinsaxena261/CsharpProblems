using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestsApp
{
    public enum TreeTraversal{
        Inorder,
        Preorder,
        Postorder
    }
    public class BinarySearchTree
    {
        public Node Root { get; set; }

        public class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            Node() { }
            public Node(int value) { this.Value = value; }
        }

        public BinarySearchTree() { this.Root = null; }

        public void Add(int value)
        {
            Node node = new Node(value);
            if(Root == null)
            {
                Root = node;
            }
            else
            {
                Node current = Root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if(value <= current.Value)
                    {
                        current = current.Left;
                        if(current == null)
                        {
                            parent.Left = node;
                            break;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if(current == null)
                        {
                            parent.Right = node;
                            break;
                        }
                    }
                }
            }
        }

        public void PrintInorder(Node node, TreeTraversal type)
        {
            if (node == null)
                return;
            switch (type)
            {
                case TreeTraversal.Postorder:
                    PrintInorder(node.Left, type);
                    PrintInorder(node.Right, type);
                    Console.Write("{0} ", node.Value);
                    break;
                case TreeTraversal.Preorder:
                    Console.Write("{0} ", node.Value);
                    PrintInorder(node.Left, type);
                    PrintInorder(node.Right, type);
                    break;
                default:
                    PrintInorder(node.Left, type);
                    Console.Write("{0} ", node.Value);
                    PrintInorder(node.Right, type);
                    break;
            }

        }
    }
}
