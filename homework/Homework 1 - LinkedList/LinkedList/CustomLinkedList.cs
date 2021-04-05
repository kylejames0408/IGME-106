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
    /// A class that organizes doubly linked lists.
    /// </summary>
    /// <typeparam name="T">The type of data that the list will store.</typeparam>
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
            set
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

                current.Data = value;
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
                // Set the reference of the node previous to this one to the old tail
                node.Previous = tail;

                // Make this node the new tail, and update the old tail
                tail.Next = node;
                tail = node;
                count++;
            }
        }

        /// <summary>
        /// Remove data from an index in the list.
        /// </summary>
        /// <param name="index">The index to remove.</param>
        public T RemoveAt(int index)
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

                // Make the new head not reference anything prior to it
                head.Previous = null;

                // Return the
                return oldHead.Data;
            }
            else if (index == count - 1)
            {
                // Create placeholders
                CustomLinkedNode<T> current = head;
                CustomLinkedNode<T> oldTail = tail;

                // Set the new tail and remove old references to it
                tail = tail.Previous;
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
                CustomLinkedNode<T> removed;

                // Loop through to the location previous to the index
                for (int i = 1; i < index; i++)
                {
                    // Get the location previous to the index
                    if (i < index - 1)
                    {
                        current = current.Next;
                    }
                }

                // Remove reference to index location and link to next location
                removed = current.Next;
                current.Next = current.Next.Next;
                current.Previous = removed.Previous;

                // Decrement count
                count--;

                // Return the removed element
                return removed.Data;
            }
        }

        /// <summary>
        /// Inserts node into the list at a specific index.
        /// </summary>
        /// <param name="item">The item to insert.</param>
        /// <param name="index">The index to insert the item at.</param>
        public void Insert(T item, int index)
        {
            // Check if insertion is at a valid point
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException("Error: Invalid index specified during insertion");
            }

            // Create the node
            CustomLinkedNode<T> node = new CustomLinkedNode<T>(item);

            // Check cases and place node in list
            if (count == 0 || index == count)
            {
                Add(item);
            }
            else if (index == 0)
            {
                // Make new node head
                node.Next = head;
                head.Previous = node;
                head = node;
                count++;
            }
            else
            {
                // Create placeholders
                CustomLinkedNode<T> current = head;

                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                // Set the prior node "next" to new node
                current.Previous.Next = node;

                // Set new nodes properties
                node.Previous = current.Previous;
                node.Next = current;

                // Set current node's previous to new node
                current.Previous = node;

                // Increment count
                count++;
            }
        }

        /// <summary>
        /// Resets the list to an empty state.
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        /// <summary>
        /// Prints the list in reverse.
        /// </summary>
        public void PrintReverse()
        {
            // Create placeholders
            CustomLinkedNode<T> current = tail;

            // Print tail
            Console.WriteLine(current.Data);

            // Loop through and print remainder of the list in reverse
            for (int i = count - 1; i > 0; i--)
            {
                current = current.Previous;
                Console.WriteLine(current.Data);
            }
        }
    }
}
