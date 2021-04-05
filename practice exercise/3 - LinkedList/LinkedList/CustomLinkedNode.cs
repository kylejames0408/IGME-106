using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class CustomLinkedNode<T>
    {
        // Fields
        private T data;
        private CustomLinkedNode<T> next;

        // Properties
        /// <summary>
        /// Gets and sets the data in a node.
        /// </summary>
        public T Data { get { return data; } set { data = value; } }

        /// <summary>
        /// Gets and sets the next node value.
        /// </summary>
        public CustomLinkedNode<T> Next { get { return next; } set { next = value; } }

        // Constructors
        /// <summary>
        /// Constructs a custom linked node.
        /// </summary>
        /// <param name="data">The data to store.</param>
        /// <param name="next">The next node to link to.</param>
        public CustomLinkedNode(T data, CustomLinkedNode<T> next = null)
        {
            // Initialize fields
            this.data = data;
            this.next = next;
        }
    }
}
