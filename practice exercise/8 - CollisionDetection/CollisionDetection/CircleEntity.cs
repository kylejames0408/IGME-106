using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CollisionDetection
{
    /// <summary>
    /// Enumeration to track different states of the game.
    /// </summary>
    enum GameState { Square, Circle };

    /// <summary>
    /// Represents a game object which is shaped like a circle.
    /// </summary>
    class CircleEntity
    {
        // Fields
        private readonly Texture2D texture;
        private Rectangle rectangle;
        private readonly int radius;

        // Properties
        /// <summary>
        /// Gets and sets the X position of the circle.
        /// </summary>
        public int X { get { return rectangle.X + radius; } set { rectangle.X = value - radius; } }
        
        /// <summary>
        /// Gets and sets the Y position of the circle.
        /// </summary>
        public int Y { get { return rectangle.Y + radius; } set { rectangle.Y = value - radius; } }
    
        /// <summary>
        /// Gets the radius of the circle.
        /// </summary>
        public int Radius { get { return radius; } }

        // Constructors
        /// <summary>
        /// Constructs a CircleEntity game object.
        /// </summary>
        /// <param name="x">The x position of the CircleEntity.</param>
        /// <param name="y">The y position of the CircleEntity.</param>
        /// <param name="radius">The radius of the CircleEntity.</param>
        /// <param name="texture">The texture of the CircleEntity.</param>
        public CircleEntity(int x, int y, int radius, Texture2D texture)
        {
            // Initialize fields
            rectangle = new Rectangle(x - radius, y - radius, radius * 2, radius * 2);
            this.texture = texture;
            this.radius = radius;
        }

        // Methods
        /// <summary>
        /// Checks if this CircleEntity is colliding with the other CircleEntity.
        /// </summary>
        /// <param name="other">The other CircleEntity to check this CircleEntity against.</param>
        /// <returns>Return true if this CircleEntity is colliding with the other CircleEntity, and false otherwise.</returns>
        public bool Intersects(CircleEntity other)
        {
            // Return true if it collides, else false
            return (Math.Pow((double)(other.X - X), 2) + Math.Pow((double)(other.Y - Y), 2)) < Math.Pow(radius + other.radius, 2);
        }

        /// <summary>
        /// Draw the CircleEntity with the specified color tint.
        /// </summary>
        /// <param name="sb">CircleBatch object.</param>
        /// <param name="tint">The color to draw the CircleEntity as.</param>
        public void Draw(SpriteBatch sb, Color tint)
        {
            // Draw the CircleEntity
            sb.Draw(texture, rectangle, tint);
        }
    }
}
