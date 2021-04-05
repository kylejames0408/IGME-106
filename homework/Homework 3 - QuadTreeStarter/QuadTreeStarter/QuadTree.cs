using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace QuadTreeStarter
{
	class QuadTreeNode
	{
		// The maximum number of objects in a quad
		// before a subdivision occurs
		private const int MAX_OBJECTS_BEFORE_SUBDIVIDE = 3;

		// The game objects held at this level of the tree
		private List<GameObject> _objects;

		// This quad's rectangle area
		private Rectangle _rect;

		// This quad's divisions
		private QuadTreeNode[] _divisions;


		/// <summary>
		/// The divisions of this quad
		/// </summary>
		public QuadTreeNode[] Divisions { get { return _divisions; } }

		/// <summary>
		/// This quad's rectangle
		/// </summary>
		public Rectangle Rectangle { get { return _rect; } }

		/// <summary>
		/// The game objects inside this quad
		/// </summary>
		public List<GameObject> GameObjects { get { return _objects; } }
		

		/// <summary>
		/// Creates a new Quad Tree
		/// </summary>
		/// <param name="x">This quad's x position</param>
		/// <param name="y">This quad's y position</param>
		/// <param name="width">This quad's width</param>
		/// <param name="height">This quad's height</param>
		public QuadTreeNode(int x, int y, int width, int height)
		{
			// Save the rectangle
			_rect = new Rectangle(x, y, width, height);

			// Create the object list
			_objects = new List<GameObject>();

			// No divisions yet
			_divisions = null;
		}
		

		/// <summary>
		/// Adds a game object to the quad.  If the quad has too many
		/// objects in it, and hasn't been divided already, it should
		/// be divided
		/// </summary>
		/// <param name="gameObj">The object to add</param>
		public void AddObject(GameObject gameObj)
		{
			// Check if the GameObject doesn't fit within the quadrant
			if (!_rect.Contains(gameObj.Rectangle))
				return;

			// Check subdivisions
			if (_divisions == null)
			{
				// If there are no divisions, the object fits within this quadrant
				_objects.Add(gameObj);
			}
			else
			{
				// Temporary fields
				bool addedToSub;

				// Initialize temporary fields
				addedToSub = false;

				// Loop through divisions to see which division the object fits in
				for (int i = 0; i < _divisions.Length; i++)
				{
					if (_divisions[i].Rectangle.Contains(gameObj.Rectangle))
					{
						_divisions[i].AddObject(gameObj);
						addedToSub = true;
					}
				}

				// If it was never added to a subdivision, it only fits in this quadrant
				if (!addedToSub)
					_objects.Add(gameObj);
			}

			// Check for need for division
			if (_objects.Count > MAX_OBJECTS_BEFORE_SUBDIVIDE)
				Divide();
		}

		/// <summary>
		/// Divides this quad into 4 smaller quads.  Moves any game objects
		/// that are completely contained within the new smaller quads into
		/// those quads and removes them from this one.
		/// </summary>
		public void Divide()
		{
			// ACTIVITY: Complete this method
			// If the current node has divisions, don't divide
			if (_divisions != null)
				return;

			// Initialize four subdivisions
			_divisions = new QuadTreeNode[4];

			// Create four subdivisions
			_divisions[0] = new QuadTreeNode(_rect.X, _rect.Y, _rect.Width / 2, _rect.Height / 2);
			_divisions[1] = new QuadTreeNode(_rect.X + _rect.Width / 2, _rect.Y, _rect.Width / 2, _rect.Height / 2);
			_divisions[2] = new QuadTreeNode(_rect.X, _rect.Y + _rect.Height / 2, _rect.Width / 2, _rect.Height / 2);
			_divisions[3] = new QuadTreeNode(_rect.X + _rect.Width / 2, _rect.Y + _rect.Height / 2, _rect.Width / 2, _rect.Height / 2);

			// Temporary fields
			List<GameObject> movedObjects;

			// Initialize temporary fields
			movedObjects = new List<GameObject>();

			// Check current objects location in subdivisions
			for (int i = 0; i < _objects.Count; i++)
			{
				for (int j = 0; j < _divisions.Length; j++)
				{
					// If the division contains the object add it to the division
					if (_divisions[j]._rect.Contains(_objects[i].Rectangle))
					{
						_divisions[j].AddObject(_objects[i]);
						movedObjects.Add(_objects[i]);
					}
				}
			}

			// Remove moved objects from current node
			for (int i = 0; i < movedObjects.Count; i++)
				_objects.Remove(movedObjects[i]);
		}

		/// <summary>
		/// Recursively populates a list with all of the rectangles in this
		/// quad and any subdivision quads.  Use the "AddRange" method of
		/// the list class to add the elements from one list to another.
		/// </summary>
		/// <returns>A list of rectangles</returns>
		public List<Rectangle> GetAllRectangles()
		{
			List<Rectangle> rects = new List<Rectangle>();

			// ACTIVITY: Complete this method
			// Add node's rectangle object
			rects.Add(_rect);

			// If there are divisions, add those rectangles
			if (_divisions != null)
			{
				// Add subdivision rectangle objects
				for (int i = 0; i < _divisions.Length; i++)
				{
					rects.AddRange(_divisions[i].GetAllRectangles());
				}
			}

			return rects;
		}

		/// <summary>
		/// A possibly recursive method that returns the
		/// smallest quad that contains the specified rectangle
		/// </summary>
		/// <param name="rect">The rectangle to check</param>
		/// <returns>The smallest quad that contains the rectangle</returns>
		public QuadTreeNode GetContainingQuad(Rectangle rect)
		{
			// ACTIVITY: Complete this method
			// Check if this quadrant contains the rectangle
			if (_rect.Contains(rect))
			{
				// If there are divisions
				if (_divisions != null)
				{
					// Check each division if it contains the object
					for (int i = 0; i < _divisions.Length; i++)
					{
						if (_divisions[i].Rectangle.Contains(rect))
						{
							// Recursively call it until there are no divisions
							return _divisions[i].GetContainingQuad(rect);
						}
					}
				}
				
				// If there are no subdivisions (or doesn't fit in any), this is the smallest quad
				return this;
			}

			// Return null if this quad doesn't completely contain
			// the rectangle that was passed in
			return null;
		}
	}
}
