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
    /// A class that creates nodes to use in the doubly linked lists.
    /// </summary>
    /// <typeparam name="T">The type of data to store in a node.</typeparam>
    class CustomLinkedNode<T>
    {
        // Fields
        private T data;
        private CustomLinkedNode<T> next;
        private CustomLinkedNode<T> previous;

        // Properties
        /// <summary>
        /// Gets and sets the data in a node.
        /// </summary>
        public T Data { get { return data; } set { data = value; } }

        /// <summary>
        /// Gets and sets the next node value.
        /// </summary>
        public CustomLinkedNode<T> Next { get { return next; } set { next = value; } }

        /// <summary>
        /// Gets and sets the node value Previous the current node.
        /// </summary>
        public CustomLinkedNode<T> Previous { get { return previous; } set { previous = value; } }

        // Constructors
        /// <summary>
        /// Constructs a custom linked node.
        /// </summary>
        /// <param name="data">The data to store.</param>
        /// <param name="next">The next node to link to.</param>
        public CustomLinkedNode(T data, CustomLinkedNode<T> previous = null, CustomLinkedNode<T> next = null)
        {
            // Initialize fields
            this.data = data;
            this.previous = previous;
            this.next = next;
        }
    }
}
