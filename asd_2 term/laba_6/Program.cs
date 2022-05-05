using System;
using System.IO;
using static System.Console;
namespace ASD_Laba6
{
    class Stack
    {
        public class StackException : Exception
        {
            public StackException(string msg) : base(msg) { }
        }
        class Item
        {
            public Item(string data, Item next)
            {
                this.data = data;
                this.next = next;
            }
            public string data;
            public Item next;
        }

        private Item head;
        public Stack()
        {
            head = null;
        }
        public void push(string data)
        {
            head = new Item(data, head);
        }
        public string pop()
        {
            if (head == null)
            {
                throw new StackOverflowException("Stack is empty");
            }
            string data = head.data;
            head = head.next;
            return data;
        }
        public void print()
        {
            if (head == null)
            {
                WriteLine("[]");
                return;
            }
            Write("[");
            for (Item item = head; item != null; item = item.next)
            {
                Write($" <{item.data}> ");
            }
            WriteLine("]");
        }
    }
    enum TagType
    {
        OPEN, CLOSE
    }
    class TagException : Exception
    {
        public TagException(string msg) : base(msg) { }
    }
    public class Program
    {
        static string corectExample =
            @"<html>
                <head><title>Hello</title></head>
                <body>
                    <p>This appears in the<i>browser</i>.</p>
                </body>
            </html>";
        static string wrongExample =
        @"<html>
                <head><title>Hello</title></head>
                <body>
                    <p>This appears in the<i>browser</i>.
                </body>
            </html>";
        static void Main(string[] args)
        {
            string command = "help";
            while (command != "exit")
            {
                switch (command)
                {
                    case "help":
                        help();
                        break;
                    case "example":
                        example();
                        break;
                    case "random":
                        random();
                        break;
                    default:
                        WriteLine("Invalid command. Enter 'help' to read possible commands");
                        break;
                }
                Write("command >");
                ConsoleColor old = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Cyan;
                command = ReadLine().Trim().ToLower();
                Console.ForegroundColor = old;
            }
        }
        static void help()
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            WriteLine(" help");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            WriteLine("To see the list of commands");
            Console.ForegroundColor = ConsoleColor.Cyan;
            WriteLine(" example");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            WriteLine("To show the example");
            Console.ForegroundColor = ConsoleColor.Cyan;
            WriteLine(" random");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            WriteLine("To check your own example");
            Console.ForegroundColor = ConsoleColor.Cyan;
            WriteLine(" exit");
            Console.ForegroundColor = old;
            WriteLine();
        }
        static void example()
        {
            ConsoleColor old = Console.ForegroundColor;       
            WriteLine("What example do you want (wrong/correct)?:"); 
            Write(">");
            Console.ForegroundColor = ConsoleColor.Cyan;    
            String command = ReadLine().Trim().ToLower();
            Console.ForegroundColor = old;
            switch (command)
            {
                case "wrong":
                    parsing(wrongExample);
                    break;
                case "correct":
                    parsing(corectExample);
                    break;
                default:
                    WriteLine("incorect command. Enter 'help' to see possible commands");
                    break;
            }
        }
        static void random()
        {
            try
            {
            WriteLine("Please write path to the file for parsing:");
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            String fileName = ReadLine();
            Console.ForegroundColor = old;
            
                StreamReader reader = new StreamReader(fileName);
                String text = "";
                reader.Close();           
            while (!reader.EndOfStream)
            {
                text += reader.ReadLine() + "\n";
            }
            parsing(text);
            }
            catch (Exception e)
            {               
                WriteLine("There's wrong path to the file");
                WriteLine(e.Message);
                return;
            }
        }   
    static void parsing(string text)
    {
        try
        {
            Stack openTags = new Stack();
            WriteLine(text);
            string open;
            string tag;
            TagType type;
            while (text != "")
            {
                (tag, type, text) = findTag(text);
                if (tag != null)
                {
                    switch (type)
                    {
                        case TagType.OPEN:
                            openTags.push(tag);
                            Write($"find open tag:'{tag}'. Push this tag to stack. Stack now:");
                            openTags.print();
                            break;
                        case TagType.CLOSE:
                            try
                            {
                                open = openTags.pop();
                                Write($"find close tag:'{tag}'.Get tag from stack. Stack now:");
                                openTags.print();
                                if (tag != open)
                                {
                                    throw new TagException($"Open tag'{open}' but close tag'{tag}'");
                                }
                            }
                            catch (Stack.StackException e)
                            {
                                throw new TagException($"Close tag '{tag}' hasn't open tag");
                            }
                            break;
                    }
                }
            }
                ConsoleColor old = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Cyan;
                WriteLine("text is correct");
                Console.ForegroundColor = old;
            }
        catch (TagException e)
        {
                ConsoleColor old = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Cyan;
                WriteLine($"Text is incorect {e.Message}");
                Console.ForegroundColor = old;
            }
    }
    static (string tag, TagType type, string restText) findTag(string text)
    {
        int start = text.IndexOf("<");
        if (start == -1) return (null, TagType.OPEN, "");
        int end = text.IndexOf(">");
        if (end == -1) throw new TagException("There is a open '<' without close '>'");
        if (end == start + 1) throw new TagException("There is an incorrect tag '<>'");
        if (text[start + 1] == '/')
        {
            return (text.Substring(start + 2, end - start - 2), TagType.CLOSE, text.Substring(end + 1));
        }
        else
        {
            return (text.Substring(start + 1, end - start - 1), TagType.OPEN, text.Substring(end + 1));

        }
    }
}
} 
