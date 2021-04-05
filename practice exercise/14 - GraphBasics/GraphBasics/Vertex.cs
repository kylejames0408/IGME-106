using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBasics
{
    class Vertex
    {
        // Fields
        private string name;
        private string description;

        // Properties
        /// <summary>
        /// Gets the name of the Vertex.
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// Gets the description of the Vertex.
        /// </summary>
        public string Description { get { return description; } }

        // Constructors
        /// <summary>
        /// Constructs a Vertex.
        /// </summary>
        /// <param name="name">The name of the Vertex.</param>
        /// <param name="description">The description of the Vertex.</param>
        public Vertex(string name, string description)
        {
            // Initialize fields
            this.name = name;
            this.description = description;
        }

        // Methods
        /// <summary>
        /// Formats the Vertex name and description.
        /// </summary>
        /// <returns>Formatted Vertex name and description.</returns>
        public override string ToString()
        {
            // Return the formatted Vertex name and description
            return $"{name.ToUpper()}: {description}";
        }
    }
}
