using System;
using System.Threading;

namespace Lab1 {
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
    public class Menu {
        public void ShowMenu() {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\n**MENU**\n");
            Console.WriteLine("1. init new table of identifiers");
            Console.WriteLine("2. print table");
            Console.WriteLine("3. add item");
            Console.WriteLine("4. find item");
            Console.WriteLine("5. remove item");
            Console.WriteLine("6. exit\n");

            Console.ResetColor();
        }

        public void Init(LinkedListNode list) {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n**CREATING NEW TABLE OF IDENTIFIERS**\n");
            Console.WriteLine("Input items. To finish - input empty name of identifier \n");

            while(true)
            {
                Console.Write("Name: ");
                var name = Console.ReadLine();

                if(name == "")
                    break;

                Console.Write("Attribute: ");
                var attr = Console.ReadLine();

                Identifier id = new Identifier
                {
                    Name = name,
                    Attr = attr
                };

                list.Add(id);
                Console.WriteLine();
            }

            Console.WriteLine("\nNew table has been successfully created\n");
            Thread.Sleep(3000);
            Console.ResetColor();
        }

        public void Print(LinkedListNode list) {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n**PRINT TABLE**");

            if(list.Count == 0) 
                Console.WriteLine("\n*---EMPTY---*");
            else
                list.Print();

            Thread.Sleep(3000);
            Console.ResetColor();
        }

        public void Add(LinkedListNode list) {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n**ADD ITEM**\n");
            Console.WriteLine("Input item you wanna add\n");

            Console.Write("Name: ");
            var name = Console.ReadLine();

            Console.Write("Attribute: ");
            var attr = Console.ReadLine();

            Identifier id = new Identifier {
                Name = name,
                Attr = attr
            };
            list.Add(id);

            Console.WriteLine("\n**SUCCESS**\n");
            Thread.Sleep(3000);
            Console.ResetColor();
        }

        public void Remove(LinkedListNode list) {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("\n**REMOVE ITEM**\n");
            Console.WriteLine("Input name of item you wanna remove\n");

            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine(list.Remove(name) ? "\n**SUCCESS**\n" : "\n**FAILED**\n");
            
            Thread.Sleep(3000);
            Console.ResetColor();
        }

        public void Find(LinkedListNode list) {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("\n**FIND ITEM**\n");
            Console.WriteLine("Input name of item you wanna find\n");

            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine(list.Contains(name) ? "\n**TABLE CONTAINS THIS ITEM**\n" : "\n**ITEM HAS NOT BEEN FOUND**\n");

            Thread.Sleep(3000);
            Console.ResetColor();
        }
    }
    internal class Program {
        private static void Main() {
            LinkedListNode list = new LinkedListNode();
            var running = true;
            while(running) {
                var menu = new Menu();
                menu.ShowMenu();

                int option = int.Parse(Console.ReadLine());
                switch(option) {
                    case 1:
                        menu.Init(list);
                        break;
                    case 2:
                        menu.Print(list);
                        break;
                    case 3:
                        menu.Add(list);
                        break;
                    case 4:
                        menu.Find(list);
                        break;
                    case 5:
                        menu.Remove(list);
                        break;
                    case 6:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("ERROR - INCORRECT OPTION");
                        break;
                }
            }
        }
    }
}
