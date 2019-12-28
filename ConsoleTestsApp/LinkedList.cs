using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestsApp
{
    class LinkedList<T>
    {
        Node Head { get; set; }
        class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
        }

        public void Add(T value)
        {
            Node newNode = new Node();
            newNode.Value = value;
            if (this.Head == null)
            {
                newNode.Next = null;
                this.Head = newNode;
            }
            else
            {
                newNode.Next = null;
                Node temp = this.Head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = newNode;
            }
        }

        public void Add(T value, T key)
        {
            Node newNode = new Node();
            newNode.Value = value;
            Node temp = this.Head;
            while (!temp.Value.Equals(key))
            {
                temp = temp.Next;
            }
            newNode.Next = temp.Next;
            temp.Next = newNode;
        }

        public void Reverse()
        {
            Node prev = null, current = this.Head, next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            this.Head = prev;
        }

        public void CreateLoop(T key)
        {
            Node temp = this.Head, looped = null;
            while (temp.Next != null)
            {
                if (temp.Value.Equals(key))
                    looped = temp;
                temp = temp.Next;
            }
            temp.Next = looped;
        }

        public void FindLoop()
        {
            Node slowPtr = this.Head, fastPtr = this.Head;
            do
            {
                slowPtr = slowPtr.Next;
                fastPtr = fastPtr.Next.Next;
            }
            while (!slowPtr.Equals(fastPtr));

            slowPtr = this.Head;
            while(!slowPtr.Equals(fastPtr))
            {
                slowPtr = slowPtr.Next;
                fastPtr = fastPtr.Next;
            }
            Console.WriteLine("Loop found on node: {0}", slowPtr.Value);
        }

        public void Print()
        {
            Node temp = this.Head;
            while (temp != null)
            {
                Console.Write("{0} ", temp.Value);
                temp = temp.Next;
            }
        }
    }
}
