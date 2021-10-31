using System;
using System.Threading;

namespace Lab3 {
    public class Identifier {
        public string Name { get; set; }
        public string Attr { get; set; }
    }
    public class LinkedListNode {
        private LinkedListNode _head;
        private LinkedListNode _tail;
        public LinkedListNode() {}
        public LinkedListNode(Identifier value) {
            Value = value;
        }

        public Identifier Value { get; internal set; }
        public LinkedListNode Next { get; internal set; }

        public int Count {
            get;
            private set;
        }

        public LinkedListNode Head { get { return _head; } }

        public void Add(Identifier item) {
            LinkedListNode node = new LinkedListNode(item);

            if(_head == null) {
                _head = node;
                _tail = node;
            } else {
                _tail.Next = node;
                _tail = node;
            }
            Count++;
        }

        public bool Contains(string name) {
            LinkedListNode node = _head;
            while(node != null) {
                if(node.Value.Name == name)
                    return true;
                node = node.Next;
            }
            return false;
        }

        public bool Remove(string name) {
            LinkedListNode prev = null;
            LinkedListNode curr = _head;

            while(curr != null) {
                if(curr.Value.Name == name) {
                    if(prev != null) {
                        prev.Next = curr.Next;
                        if (curr.Next == null)
                            _tail = prev;
                    } else {
                        _head = _head.Next;
                        if(_head == null) 
                            _tail = null;
                    }
                    Count--;
                    return true;
                }
                prev = curr;
                curr = curr.Next;
            }
            return false;
        }

        public void Print()
        {
            LinkedListNode node = _head;
            while(node != null) {
                Console.WriteLine($"{node.Value.Name}, {node.Value.Attr}");
                node = node.Next;
            }
        }
    }
}
