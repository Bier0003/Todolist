using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Todolist
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Todo>
            {
                new Todo
                {
                    TodoText = "Go to zoo"
                }
            };
            list.Add(new Todo { TodoText = "Go to thailand" });

            Console.WriteLine("Velkommen til TodoList Apps");
            Console.WriteLine("Vælge dn mulighed");
            Console.WriteLine("1) Tilføje liste");
            Console.WriteLine("2) Slet liste");
            Console.WriteLine("3) View liste");
            Console.WriteLine("4) Markeres som afsluttet");
            Console.WriteLine("E)Exit");

            String userInput = Console.ReadLine();

            Console.WriteLine("Du gerne:" + userInput + "\n");


        }
    }
}