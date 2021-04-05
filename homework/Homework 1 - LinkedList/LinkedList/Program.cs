using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// A project that creates doubly linked lists.
/// </summary>
namespace LinkedList
{
    /// <summary>
    /// The main program to run and use doubly linked lists.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main method to run the program.
        /// </summary>
        /// <param name="args">The arguments to run the program.</param>
        static void Main(string[] args)
        {
            // Fields
            bool continueRunning;
            int index;
            string userInput;
            CustomLinkedList<string> customLinkedList;
            Random rng;

            // Initialize fields
            continueRunning = true;
            customLinkedList = new CustomLinkedList<string>();
            index = default;
            rng = new Random();

            // Get five pieces of input
            while (continueRunning)
            {
                Console.Write("Type something: ");

                userInput = Console.ReadLine();

                switch (userInput.ToLower())
                {
                    case "q":
                        continueRunning = false;
                        break;
                    case "quit":
                        continueRunning = false;
                        break;
                    case "print":
                        // Print the list in order
                        Console.WriteLine("The following items are in the list:");
                        for (int i = 0; i < customLinkedList.Count; i++)
                        {
                            Console.WriteLine($"{customLinkedList[i]}");
                        }
                        Console.WriteLine();
                        break;
                    case "count":
                        // Announce the count
                        Console.WriteLine($"There are currently {customLinkedList.Count} items in the list.\n");
                        break;
                    case "clear":
                        // Clear the list
                        customLinkedList.Clear();
                        Console.WriteLine("The list has been cleared\n");
                        break;
                    case "remove":
                        // Remove a random item
                        index = rng.Next(0, customLinkedList.Count);
                        Console.WriteLine($"Removed {customLinkedList.RemoveAt(index)} from index {index}\n");
                        break;
                    case "reverse":
                        // Print reverse list
                        Console.WriteLine("The following items are in the list (in reverse order):");
                        customLinkedList.PrintReverse();
                        Console.WriteLine();
                        break;
                    case "scramble":
                        // Fields
                        string data;

                        // Initialize fields
                        data = null;

                        // Header
                        Console.WriteLine("Moving a random element to a new, random position");

                        // Generate random index
                        index = rng.Next(0, customLinkedList.Count);

                        // Remove and announce removal
                        Console.WriteLine($" - Removing {data = customLinkedList.RemoveAt(index)} from index {index}");

                        // Generate new random index
                        index = rng.Next(0, customLinkedList.Count);

                        // Announce insertion
                        Console.WriteLine($" - Inserting into index {index}\n");

                        // Insert
                        customLinkedList.Insert(data, index);
                        break;

                    default:
                        customLinkedList.Add(userInput);
                        Console.WriteLine($"\"{userInput}\" has been added to the list");
                        Console.WriteLine();
                        break;
                }
            }

            Console.WriteLine("Thanks for typing!");

            // Keep the window open
            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
        }
    }
}
