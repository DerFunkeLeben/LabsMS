using System;

namespace MS_CW
{
    public class Map<TKey, TValue> where TKey : IComparable where TValue : IComparable
    {
        class Node
        {
            public TKey key;
            public TValue data;
            public Node next;
            public Node(TKey key, TValue data, Node next = null)
            {
                this.key = key;
                this.data = data;
                this.next = null;
            }
        }
        public Map()
        {
            head = null;
            last = null;
            Size = 1;
        }
        Node head;
        Node last;
        public int Size { get; set; }
        public void Add(TKey key, TValue data)
        {
            if (Has(key)) return;
            if (head == null)
                last = head = new Node(key, data, head);
            else
                last = last.next = new Node(key, data);
            Size++;
        }
        public bool Has(TKey key)
        {
            Node temp = head;
            while (temp != null)
            {
                if (temp.key.CompareTo(key) == 0)
                    return true;
                temp = temp.next;
            }
            return false;
        }
        public TValue this[TKey key]
        {
            get
            {
                Node temp = head;
                while (temp != null)
                {
                    if (temp.key.CompareTo(key) == 0)
                        return temp.data;
                    temp = temp.next;
                }
                return default;
            }
            set
            {
                Node temp = head;
                while (temp != null)
                {
                    if (temp.key.CompareTo(key) == 0)
                    {
                        temp.data = value;
                        break;
                    }
                    temp = temp.next;
                }
            }
        }
        public TKey Get(string l)
        {
            Node temp = head;
            while (temp != null)
            {
                if (temp.data.CompareTo(l) == 0)
                    return temp.key;
                temp = temp.next;
            }
            return default;
        }
        ~Map()
        {
            Node temp = head;
            while (head != null)
            {
                head = head.next;
                temp.next = null;
                temp = head;
            }
        }
    }
}
