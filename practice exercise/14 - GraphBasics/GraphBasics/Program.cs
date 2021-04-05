using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            // Fields
            string currentRoom;
            Graph graph;

            // Initialize fields
            currentRoom = "Drawing Room";
            graph = new Graph();

            // List all of the vertices in the Graph
            graph.ListAllVertices();

            // Continue until currentRoom is the exit
            while (currentRoom != "Exit")
            {
                // Temporary fields
                bool validInput;
                string userInput;
                string[] names;
                List<Vertex> adjVertices;

                // Initialize fields
                validInput = false;
                adjVertices = graph.GetAdjacentList(currentRoom);

                // Print information about location
                Console.WriteLine($"\nYou are currently in the {currentRoom}");
                Console.Write($"\tNearby are:");
                for (int i = 0; i < adjVertices.Count; i++)
                    Console.Write($"     {adjVertices[i].Name.ToLower()}");

                // Spacer
                Console.WriteLine();

                // While the user's input is not valid
                while (!validInput)
                {
                    // Get user input
                    Console.Write($"\tWhere would you like to go? ");
                    userInput = Console.ReadLine();

                    // Transform user input
                    names = userInput.Split(' ');
                    userInput = "";

                    for (int i = 0; i < names.Length; i++)
                    {
                        // Temporary fields
                        string name;

                        // Initialize fields
                        name = "";

                        // Lower case the name
                        names[i] = names[i].ToLower();

                        // Set name
                        name += names[i][0].ToString().ToUpper();

                        for (int j = 1; j < names[i].Length; j++)
                            name += names[i][j].ToString();

                        // Set user input
                        if (i > 0)
                            userInput += $" {name}";
                        else
                            userInput += name;
                    }

                    // Check if the user's input was valid
                    for (int i = 0; i < adjVertices.Count; i++)
                    {
                        if (adjVertices[i].Name == userInput)
                        {
                            validInput = true;
                            currentRoom = userInput;
                        }
                    }

                    // Alert user if input was invalid
                    if (!validInput)
                    {
                        Console.WriteLine("\nSorry, that is not an adjacent room.");
                    }
                }
            }

            // Alert the user when they exit the loop
            Console.WriteLine("\nYou have successfully escaped.");

            // Keep the window open
            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
        }
    }
}
