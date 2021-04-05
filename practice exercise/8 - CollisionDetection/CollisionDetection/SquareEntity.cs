using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CollisionDetection
{
    /// <summary>
    /// Represents a game object which is shaped like a square (or rectangle).
    /// </summary>
    class SquareEntity
    {
        // Fields
        private readonly Texture2D texture;
        private Rectangle rectangle;

        // Properties
        /// <summary>
        /// Gets and sets the X position of the rectangle.
        /// </summary>
        public int X { get { return rectangle.X; } set { rectangle.X = value; } }

        /// <summary>
        /// Gets and sets the Y position of the rectangle.
        /// </summary>
        public int Y { get { return rectangle.Y; } set { rectangle.Y = value; } }

        // Constructors
        /// <summary>
        /// Constructs a SquareEntity game object.
        /// </summary>
        /// <param name="x">The x position of the SquareEntity.</param>
        /// <param name="y">The y position of the SquareEntity.</param>
        /// <param name="width">The width of the SquareEntity.</param>
        /// <param name="height">The height of the SquareEntity.</param>
        /// <param name="texture">The texture of the SquareEntity.</param>
        public SquareEntity(int x, int y, int width, int height, Texture2D texture)
        {
            // Initialize fields
            this.texture = texture;
            rectangle = new Rectangle(x, y, width, height);
        }

        // Methods
        /// <summary>
        /// Checks if this SquareEntity is colliding with the other SquareEntity.
        /// </summary>
        /// <param name="other">The other SquareEntity to check this SquareEntity against.</param>
        /// <returns>Return true if this SquareEntity is colliding with the other SquareEntity, and false otherwise.</returns>
        public bool Intersects(SquareEntity other)
        {
            // If the SquareEntities collide, return true, else false
            return rectangle.Intersects(other.rectangle);
        }

        /// <summary>
        /// Draw the SquareEntity with the specified color tint.
        /// </summary>
        /// <param name="sb">SpriteBatch object.</param>
        /// <param name="tint">The color to draw the SquareEntity as.</param>
        public void Draw(SpriteBatch sb, Color tint)
        {
            // Draw the SquareEntity
            sb.Draw(texture, rectangle, tint);
        }
    }
}
