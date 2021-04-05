using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBasics
{
    class Graph
    {
        // Fields
        private List<Vertex> vertices;
        private Dictionary<string, List<Vertex>> adjList;

        // Constructors
        /// <summary>
        /// Constructs a Graph.
        /// </summary>
        public Graph()
        {
            // Initialize fields
            vertices = new List<Vertex>();
            adjList = new Dictionary<string, List<Vertex>>();

            // Create each Vertex
            Vertex drawingRoom = new Vertex("Drawing Room", "In this room, you can draw stuff.");
            Vertex billiardsRoom = new Vertex("Billiards Room", "We got a pool table!");
            Vertex gameRoom = new Vertex("Game Room", "A whole room dedicated to just games!");
            Vertex libraryRoom = new Vertex("Library", "An entire room full of books.");
            Vertex exitRoom = new Vertex("Exit", "You can leave. But with pool, drawing, games and books - why would you want to?");

            // Fill List of vertices
            vertices.Add(drawingRoom);
            vertices.Add(billiardsRoom);
            vertices.Add(gameRoom);
            vertices.Add(libraryRoom);
            vertices.Add(exitRoom);

            // Add adjacency Dictionary for each Vertex
            adjList["Drawing Room"] = new List<Vertex>();
            adjList["Billiards Room"] = new List<Vertex>();
            adjList["Game Room"] = new List<Vertex>();
            adjList["Library"] = new List<Vertex>();
            adjList["Exit"] = new List<Vertex>();

            // Add edges for each Vertex
            adjList["Drawing Room"].Add(billiardsRoom);
            adjList["Drawing Room"].Add(gameRoom);
            adjList["Drawing Room"].Add(libraryRoom);
            adjList["Billiards Room"].Add(drawingRoom);
            adjList["Game Room"].Add(drawingRoom);
            adjList["Game Room"].Add(libraryRoom);
            adjList["Library"].Add(drawingRoom);
            adjList["Library"].Add(gameRoom);
            adjList["Library"].Add(exitRoom);
            adjList["Exit"].Add(libraryRoom);
        }

        // Methods
        /// <summary>
        /// A helper method that gets adjacent vertices to the provided Vertex.
        /// </summary>
        /// <param name="room">The Vertex to check for adjacent vertices.</param>
        /// <returns>Adjacent vertices, or null if the Vertex does not exist.</returns>
        public List<Vertex> GetAdjacentList(string room)
        {
            // Check if adjacency Dictionary contains the room key
            if (adjList.ContainsKey(room))
                return adjList[room];
            else
                return null;
        }

        /// <summary>
        /// Determines if two vertices are connected.
        /// </summary>
        /// <param name="room1">The first Vertex name.</param>
        /// <param name="room2">The second Vertex name.</param>
        /// <returns>True if the two vertices are connected, false otherwise.</returns>
        public bool IsConnected(string room1, string room2)
        {
            // Check if both vertices exist
            if (adjList.ContainsKey(room1) && adjList.ContainsKey(room2))
            {
                // Iterate through the adjacency Dictionary
                for (int i = 0; i < adjList[room1].Count; i++)
                {
                    // Return if the two rooms connect
                    return (adjList[room1][i].Name == room2);
                }
            }

            // If a Vertex doesn't exist, return false
            return false;
        }

        /// <summary>
        /// Prints each Vertex name and description.
        /// </summary>
        public void ListAllVertices()
        {
            // Iterate through each room
            for (int i = 0; i < vertices.Count; i++)
                Console.WriteLine($"{vertices[i]}");
        }
    }
}
