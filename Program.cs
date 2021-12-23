using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lists
{
    class DoublyLinkedHeadlessLoopList
    {
        private class DLNode
        {
            public int data;
            public DLNode next;
            public DLNode prev;
            public DLNode(int data)
            {
                this.data = data;
            }
        }

        DLNode tail;
        public DoublyLinkedHeadlessLoopList()
        {
            tail = null;
        }
        public void AddFirst(int data)
        {
            DLNode node = new DLNode(data);
            if (tail != null)
            {
                DLNode head = tail.next;
                head.prev = node;
                tail.next = node;
                node.next = head;
                node.prev = tail;
            }
            else
            {
                node.next = node;
                node.prev = node;
                tail = node;
            }
        }
        public void AddLast(int data)
        {
            DLNode node = new DLNode(data);
            if (tail != null)
            {
                DLNode head = tail.next;
                head.prev = node;
                tail.next = node;
                node.next = head;
                node.prev = tail;
            }
            else
            {
                node.next = node;
                node.prev = node;
            }
            tail = node;
        }
        public void AddAtPosition(int data, int pos)
        {
            DLNode node = new DLNode(data);
            if (tail == null)
            {
                node.next = node;
                node.prev = node;
                tail = node;
                return;
            }
            DLNode temp = tail;
            for (int count = 0; count < pos; count++)
            {
                temp = temp.next;
                if (temp == tail)
                {
                    temp.next.prev = node;
                    node.next = temp.next;
                    temp.next = node;
                    node.prev = temp;
                    tail = temp;
                    return;
                }
            }
            temp.next.prev = node;
            node.next = temp.next;
            temp.next = node;
            node.prev = temp;
        }
        public bool DeleteFirst()
        {
            if (tail == null)
            {
                return false;
            }
            DLNode head = tail.next;
            if (head == tail)
            {
                tail = null;
                return true;
            }
            DLNode node = head.next;
            node.prev = tail;
            tail.next = node;
            return true;
        }
        public bool DeleteLast()
        {
            if (tail == null)
            {
                return false;
            }
            DLNode head = tail.next;
            if (head == tail)
            {
                tail = null;
                return true;
            }
            DLNode node = tail.prev;
            node.next = head;
            head.prev = node;
            tail = node;
            return true;
        }
        public bool DeleteAtPosition(int pos)
        {
            if (tail == null)
            {
                return false;
            }
            DLNode head = tail.next;
            DLNode temp = head;
            for (int count = 0; count < pos; count++)
            {
                temp = temp.next;
                if (temp == head)
                {
                    return false;
                }
            }
            if (temp != tail)
            {
                temp.next.prev = temp.prev;
                temp.prev.next = temp.next;
            }
            else
            {
                if (head == tail)
                {
                    tail = null;
                    return true;
                }
                temp = tail.prev;
                temp.next = head;
                head.prev = temp;
                tail = temp;
            }
            return true;
        }
        public void Print()
        {
            if (tail == null)
            {
                WriteLine("empty list");
                return;
            }
            Write("[");
            for (DLNode node = tail.next; node != tail; node = node.next)
            {
                Write(node.data + ", ");
            }
            Write(tail.data);
            WriteLine("]");
        }

        public void Task(int data)
        {
            DLNode node = new DLNode(data);
            if (tail != null)
            {
                DLNode head = tail.next;
                if (data % 2 != 0)
                {
                    head.prev = node;
                    tail.next = node;
                    node.next = head;
                    node.prev = tail;
                    tail = node;
                }
                else
                {
                    head.next.prev = node;
                    node.next = head.next;
                    head.next = node;
                    node.prev = head;
                    if (head == tail)
                    {
                        tail = node;
                    }
                }
            }
            else
            {
                node.next = node;
                node.prev = node;
                tail = node;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedHeadlessLoopList list = new DoublyLinkedHeadlessLoopList();
            string command = "help";
            while (true)
            {
                switch (command)
                {
                    case "help":
                        onHelp();
                        break;
                    case "exit":
                        return;
                    case "add first":
                        onAddFirst(list);
                        break;
                    case "add last":
                        onAddLast(list);
                        break;
                    case "del first":
                        onDelFirst(list);
                        break;
                    case "del last":
                        onDelLast(list);
                        break;
                    case "add position":
                        onAddPosition(list);
                        break;
                    case "del position":
                        onDelPosition(list);
                        break;
                    case "task":
                        onTask(list);
                        break;
                    case "print":
                        onPrint(list);
                        break;
                    default:
                        onDefault();
                        break;
                }
                Write("command > ");
                command = ReadLine().Trim();
            }
        }

        static (bool, int) input(string prompt = null)
        {
            try
            {
                if (prompt == null)
                {
                    Write("number > ");
                }
                else
                {
                    Write(prompt + " > ");
                }
                return (true, Int32.Parse(ReadLine()));
            }
            catch (Exception e)
            {
                WriteLine("Invalid number. Enter command 'help' to see the list of commands");
                return (false, 0);
            }
        }
        static void onAddFirst(DoublyLinkedHeadlessLoopList list)
        {
            (bool success, int data) = input();
            if (success)
            {
                list.AddFirst(data);
                list.Print();
            }
        }
        static void onAddPosition(DoublyLinkedHeadlessLoopList list)
        {
            (bool success_1, int data) = input();
            (bool success_2, int position) = input("position");
            if (success_1 && success_2)
            {
                list.AddAtPosition(data, position);
                list.Print();
            }
        }

        static void onDelPosition(DoublyLinkedHeadlessLoopList list)
        {
            (bool success, int position) = input("position");
            if (success)
            {
                list.DeleteAtPosition(position);
                list.Print();
            }
        }

        static void onAddLast(DoublyLinkedHeadlessLoopList list)
        {
            (bool success, int data) = input();
            if (success)
            {
                list.AddLast(data);
                list.Print();
            }
        }

        static void onTask(DoublyLinkedHeadlessLoopList list)
        {
            (bool success, int data) = input();
            if (success)
            {
                list.Task(data);
                list.Print();
            }
        }

        static void onDelFirst(DoublyLinkedHeadlessLoopList list)
        {
            list.DeleteFirst();
            list.Print();
        }

        static void onDelLast(DoublyLinkedHeadlessLoopList list)
        {
            list.DeleteLast();
            list.Print();
        }

        static void onPrint(DoublyLinkedHeadlessLoopList list)
        {
            list.Print();
        }

        static void onHelp()
        {
            WriteLine("Possible commnads:");
            WriteLine("\thelp - show the list of possible commnads");
            WriteLine("\tadd fisrt - add number to the first position");
            WriteLine("\tadd last  - add number to the last position");
            WriteLine("\tdel fisrt - del number at the first position");
            WriteLine("\tdel last  - del number at the last position");
            WriteLine("\tadd position  - add number to the position");
            WriteLine("\tdel position  - delete number at the position");
            WriteLine("\ttask  - add number as in the task");
            WriteLine("\tprint  - print the list");
            WriteLine("\texit  - exit the program");
        }

        static void onDefault()
        {
            WriteLine("Invalid command. Enter 'help' to see the list of commands");
        }
    }
}