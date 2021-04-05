using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSearching
{
    class Graph
    {
        // Fields
        private int[,] adjacencyMatrix;
        private Dictionary<string, Vertex> verticesDictionary;
        private List<Vertex> verticesList;
        private bool[] visited;


        // Constructors
        /// <summary>
        /// Constructs a Graph object.
        /// </summary>
        public Graph()
        {
            // Initialize fields
            verticesDictionary = new Dictionary<string, Vertex>(7);
            verticesList = new List<Vertex>(7);
            visited = new bool[7];

            // Create vertices
            Vertex a = new Vertex("A");
            Vertex b = new Vertex("B");
            Vertex c = new Vertex("C");
            Vertex d = new Vertex("D");
            Vertex e = new Vertex("E");
            Vertex f = new Vertex("F");
            Vertex g = new Vertex("G");

            // Add vertices to Dictionary
            verticesDictionary.Add(a.Name, a);
            verticesDictionary.Add(b.Name, b);
            verticesDictionary.Add(c.Name, c);
            verticesDictionary.Add(d.Name, d);
            verticesDictionary.Add(e.Name, e);
            verticesDictionary.Add(f.Name, f);
            verticesDictionary.Add(g.Name, g);

            // Add vertices to List
            verticesList.Add(a);
            verticesList.Add(b);
            verticesList.Add(c);
            verticesList.Add(d);
            verticesList.Add(e);
            verticesList.Add(f);
            verticesList.Add(g);

            // Set edges
            adjacencyMatrix = new int[7, 7]
            {
                { 0, 1, 0, 1, 0, 1, 0 },
                { 1, 0, 1, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 0, 0 },
                { 1, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0, 1, 0 },
            };

            // Set visited array
            Reset();
        }

        // Methods
        /// <summary>
        /// Resets visited information to false.
        /// </summary>
        private void Reset()
        {
            // Reset visited information
            for (int i = 0; i < visited.Length; i++)
                visited[i] = false;
        }

        /// <summary>
        /// Finds an adjacent unvisited Vertex.
        /// </summary>
        /// <param name="name">The name of the Vertex to check for adjacent vertices.</param>
        /// <returns>An adjacent Vertex to the Vertex that was passed in.</returns>
        private Vertex GetAdjacentUnvisited(string name)
        {
            // Check if the specified name is a valid Vertex
            if (!verticesDictionary.ContainsKey(name))
                return null;

            // Temporary fields
            int nameIndex;

            // Initialize fields
            nameIndex = 0;

            // Find location of Vertex
            for (int i  = 1; i < verticesList.Count; i++)
            {
                if (verticesList[i].Name == name)
                    nameIndex = i;

            }

            // Loop through adjacency matrix
            for (int i = 0; i < visited.Length; i++)
            {
                // If the item is adjacent and unvisited, return it
                if (adjacencyMatrix[nameIndex, i] == 1 && visited[i] == false)
                    return verticesList[i];
            }

            // If none of the previous conditions are met, there are no vertices to vist
            return null;
        }

        /// <summary>
        /// Searches the Graph and prints out vertices in depth-first order.
        /// </summary>
        /// <param name="name">The name of a Vertex.</param>
        public void DepthFirst(string name)
        {
            // Check if the specified name is a valid Vertex
            if (!verticesDictionary.ContainsKey(name))
                Console.WriteLine("Error: Invalid name passed into the DepthFirst method.");

            // Temporary fields
            Stack<Vertex> vertices;

            // Initialize fields
            vertices = new Stack<Vertex>();

            // Reset all vertices
            Reset();

            // Print out the current Vertex's name
            Console.Write(name);

            // Add the current Vertex to the stack
            vertices.Push(verticesDictionary[name]);

            // Mark the Vertex as visited
            for (int i = 0; i < verticesList.Count; i++)
                if (verticesList[i] == verticesDictionary[name])
                    visited[i] = true;

            // Continue to loop while there is something on the stack
            while (vertices.Count != 0)
            {
                // Temporary fields
                Vertex vertex;

                // Initialize fields
                vertex = GetAdjacentUnvisited(vertices.Peek().Name);

                // Get an adjacent Vertex and add it to the stack
                if (vertex != null)
                {
                    // Print out the Vertex's name
                    Console.Write($", {vertex.Name}");

                    // Add the Vertex to the stack
                    vertices.Push(vertex);

                    // Mark the Vertex as visited
                    for (int i = 0; i < verticesList.Count; i++)
                        if (verticesList[i] == vertex)
                            visited[i] = true;
                }
                else
                {
                    // No adjacent Vertex, remove this one
                    vertices.Pop();
                }
            }
        }
    }
}
