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

        /// <summary>
        /// Remove data from an index in the list.
        /// </summary>
        /// <param name="index">The index to remove.</param>
        public T Remove(int index)
        {
            // Check specific index cases
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Error: Invalid index specified during removal");
            }
            else if (count == 1)
            {
                // Create placeholder
                CustomLinkedNode<T> element = head;

                // Remove references to only element
                head = null;
                tail = null;
                count = 0;

                // Return removed element
                return element.Data;
            }
            else if (index == 0)
            {
                // Create placeholder
                CustomLinkedNode<T> oldHead = head;

                // Make the second element the new head and decrement the count
                head = head.Next;
                count--;

                // Return the
                return oldHead.Data;
            }
            else if (index == count - 1)
            {
                // Create placeholders
                CustomLinkedNode<T> current = head;
                CustomLinkedNode<T> oldTail = tail;

                // Get to location before current tail
                for (int i = 1; i < count - 2; i++)
                {
                    current = current.Next;
                }

                // Set the new tail and remove old references to it
                tail = current;
                tail.Next = null;

                // Decrement count
                count--;

                // Return the removed tail
                return oldTail.Data;
            }
            else
            {
                // Create placeholders
                CustomLinkedNode<T> current = head;
                CustomLinkedNode<T> positionAfter = head;
                CustomLinkedNode<T> removed = head;

                // Loop through to the location before the index
                for (int i = 1; i < index + 1; i++)
                {
                    // Get the location before the index
                    if (i < index - 1)
                    {
                        current = current.Next;
                    }

                    if (i < index)
                    {
                        removed = removed.Next;
                    }

                    // Get the position after the index
                    positionAfter = positionAfter.Next;
                }

                // Remove reference to index location and link to next location
                current.Next = positionAfter;

                // Decrement count
                count--;

                // Return the removed element
                return removed.Data;
            }
        }
    }
}
