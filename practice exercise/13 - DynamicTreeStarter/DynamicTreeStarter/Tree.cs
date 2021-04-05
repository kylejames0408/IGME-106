using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DynamicTreeStarter
{
	/// <summary>
	/// Represents a tree-centric data structure
	/// that can have data dynamically inserted, 
	/// and can be drawn as a literal "tree" on the screen
	/// </summary>
	class Tree : DrawableTree
	{
		// Already has an inherited root node field called "root"

		/// <summary>
		/// Creates a tree that can be drawn
		/// </summary>
		/// <param name="sb">The sprite batch used to draw</param>
		/// <param name="treeColor">The color of this tree</param>
		public Tree(SpriteBatch sb, Color treeColor)
			: base(sb, treeColor)
		{ }

		/// <summary>
		/// Public facing Insert method
		/// </summary>
		/// <param name="data">The data to insert</param>
		public void Insert(int data)
		{
			// Check if root node, if not, create one
			if (root == null)
				root = new TreeNode(data);

			// Otherwise, call private method to insert data
			else
				Insert(data, root);
		}

		/// <summary>
		/// Private recursive insert method
		/// </summary>
		/// <param name="data">The data to insert</param>
		/// <param name="node">The node to attempt to insert into</param>
		private void Insert(int data, TreeNode node)
		{
			// Check direction
			if (data < node.Data)
			{
				// Check if there is a child to the lft
				if (node.Left != null)
					Insert(data, node.Left);
				// If not, create one
				else
					node.Left = new TreeNode(data);
			}
			else
			{
				// Check if there is a child to the rigth
				if (node.Right != null)
					Insert(data, node.Right);
				// If not, create one
				else
					node.Right = new TreeNode(data);
			}
		}
	}
}
