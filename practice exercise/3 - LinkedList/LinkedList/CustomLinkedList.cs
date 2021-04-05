using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class CustomLinkedList<T>
    {
        // Fields
        private int count;
        private CustomLinkedNode<T> head;
        private CustomLinkedNode<T> tail;

        // Properties
        public T this[int index]
        {
            get
            {
                // Error check for invalid index
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Error: The list does not contain data at that index.");
                }

                // Create a current location to track data
                CustomLinkedNode<T> current = head;

                // Loop through data until reaching desired index
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                return current.Data;
            }
        }

        /// <summary>
        /// Gets the number of items in the linked list.
        /// </summary>
        public int Count { get { return count; } }

        // Constructors
        /// <summary>
        /// Constructs a custom linked list.
        /// </summary>
        public CustomLinkedList()
        {
            // Initialize fields
            count = 0;
            head = null;
            tail = null;
        }

        // Methods
        /// <summary>
        /// Add data to the end of the list.
        /// </summary>
        /// <param name="data">The data to add.</param>
        public void Add(T data)
        {
            // Create the node
            CustomLinkedNode<T> node = new CustomLinkedNode<T>(data);

            // If it's the first node, make it the head and tail
            if (count == 0)
            {
                head = node;
                tail = node;
                count++;
            }
            else
            {
                tail.Next = node;
                tail = node;
                count++;
            }
        }
    }
}
