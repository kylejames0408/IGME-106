using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSearching
{
    class Program
    {
        static void Main(string[] args)
        {
            // Fields
            Graph graph;

            // Initialize fields
            graph = new Graph();

            // Depth First Searches
            Console.Write("Starting at C: ");
            graph.DepthFirst("C");
            Console.Write("\nStarting at E: ");
            graph.DepthFirst("E");
            Console.Write("\nStarting at A: ");
            graph.DepthFirst("A");

            // Keep the window open
            Console.WriteLine("\n\nPress any key to continue . . .");
            Console.ReadKey();
        }
    }
}
