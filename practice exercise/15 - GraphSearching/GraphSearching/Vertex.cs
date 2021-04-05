using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSearching
{
    class Vertex
    {
        // Fields
        private string name;

        // Properties
        /// <summary>
        /// Gets the name of the Vertex.
        /// </summary>
        public string Name { get { return name; } }

        // Constructors
        /// <summary>
        /// Constructs a Vertex object.
        /// </summary>
        /// <param name="name">The name of the Vertex.</param>
        public Vertex(string name)
        {
            // Initialize fields
            this.name = name;
        }
    }
}
