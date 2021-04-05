using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentTreeTraversal
{
    class TalentTreeNode
    {
        // Fields
        private string ability;
        private bool learned;
        private TalentTreeNode leftChildNode;
        private TalentTreeNode rightChildNode;

        // Properties
        /// <summary>
        /// Gets and sets the Left Child Node of the Talent Tree Node.
        /// </summary>
        public TalentTreeNode LeftChildNode { get { return leftChildNode; } set { leftChildNode = value; } }

        /// <summary>
        /// Gets and sets the Right Child Node of the Talent Tree Node.
        /// </summary>
        public TalentTreeNode RightChildNode { get { return rightChildNode; } set { rightChildNode = value; } }

        // Constructors
        /// <summary>
        /// Constructs a Talent Tree Node.
        /// </summary>
        /// <param name="ability">The name of the ability.</param>
        /// <param name="learned">Whether or not the player has learned the ability.</param>
        public TalentTreeNode(string ability, bool learned)
        {
            // Initialize fields
            this.ability = ability;
            this.learned = learned;
            leftChildNode = null;
            rightChildNode = null;
        }

        // Methods
        /// <summary>
        /// Prints all of the abilities in the tree using in order traversal.
        /// </summary>
        public void ListAllAbilities()
        {
            // Recursively call the method on the left node if it exists
            if (leftChildNode != null)
                leftChildNode.ListAllAbilities();

            // Print this ability
            Console.WriteLine(ability);

            // Recursively call the method on the right node if it exists
            if (rightChildNode != null)
                rightChildNode.ListAllAbilities();
        }

        /// <summary>
        /// Prints out the abilities that the player knows.
        /// </summary>
        public void ListKnownAbilities()
        {
            // Check if this ability is learned
            if (learned)
            {
                // If learned, print the ability
                Console.WriteLine(ability);

                // Recursively call the method on the left node if it exists
                if (leftChildNode != null)
                    leftChildNode.ListKnownAbilities();

                // Recursively call the method on the right node if it exists
                if (rightChildNode != null)
                    rightChildNode.ListKnownAbilities();
            }
        }

        /// <summary>
        /// Prints the abilities that the player could learn next.
        /// </summary>
        public void ListPossibleAbilities()
        {
            // If the ability is learned, check it's children
            if (learned)
            {
                // Recursively call the method on the left node if it exists
                if (leftChildNode != null)
                    leftChildNode.ListPossibleAbilities();

                // Recursively call the method on the right node if it exists
                if (rightChildNode != null)
                    rightChildNode.ListPossibleAbilities();
            }
            else
            {
                Console.WriteLine(ability);
            }
        }
    }
}
