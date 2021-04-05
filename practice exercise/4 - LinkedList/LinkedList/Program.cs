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
            for (int i = 0; i < 6; i ++)
            {
                // Prompt the user to enter data
                Console.Write("What are you adding to the list?: ");

                // Add data to the list
                customLinkedList.Add(Console.ReadLine());

                // Add spacing
                Console.WriteLine();
            }

            // Print list
            Console.WriteLine("\n\n>> Printing Linked List contents:\n");
            
            for (int i = 0; i < customLinkedList.Count; i++)
            {
                Console.WriteLine($"{customLinkedList[i]}");
            }

            // Delete some items from the list
            Console.WriteLine("\nAbout to remove items at indices 99, 5, 0, and 1\n");

            // Attempt to remove invalid index
            try
            {
                customLinkedList.Remove(99);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Attempt to remove last node, first node, and node in the middle
            try
            {
                customLinkedList.Remove(customLinkedList.Count - 1);
                customLinkedList.Remove(0);
                customLinkedList.Remove(1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Print list
            Console.WriteLine("\n>> Printing Linked List contents after successful removals:\n");
            
            for (int i = 0; i < customLinkedList.Count; i++)
            {
                Console.WriteLine($"{customLinkedList[i]}");
            }

            // Keep the window open
            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
        }
    }
}
