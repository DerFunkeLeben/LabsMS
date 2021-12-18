using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_CW
{
    public class Stack<T>
    {
        class Node
        {
            public T data;
            public Node next;
            public Node(T data, Node next = null)
            {
                this.data = data;
                this.next = next;
            }
        }
        public Stack()
        {
            head = null;
        }
        Node head;
        public void Push(T data)
        {
            head = new Node(data, head);
        }
        public T Pop()
        {
            T data;
            if (head != null)
            {
                data = head.data;
                head = head.next;
            }
            else data = default;
            return data;
        }
        public T Peek()
        {
            if (head != null)
                return head.data;
            else return default;
        }
    }
}
