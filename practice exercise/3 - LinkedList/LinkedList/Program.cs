using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Fields
            CustomLinkedList<string> customLinkedList;

            // Initialize fields
            customLinkedList = new CustomLinkedList<string>();

            // Get five pieces of input
            for (int i = 0; i < 5; i ++)
            {
                // Prompt the user to enter data
                Console.Write("What are you adding to the list?: ");

                // Add data to the list
                customLinkedList.Add(Console.ReadLine());

                // Add spacing
                Console.WriteLine();
            }

            // Print list
            Console.WriteLine("\n\nHere is your list:\n");
            
            for (int i = 0; i < customLinkedList.Count; i++)
            {
                Console.WriteLine($"{customLinkedList[i]}\n");
            }

            // Keep the window open
            Console.WriteLine("\n\nPress any key to continue . . .");
            Console.ReadKey();
        }
    }
}
