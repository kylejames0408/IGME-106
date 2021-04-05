using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Project space for the first MonoGame game.
/// </summary>
namespace FirstMonoGameGame
{
    /// <summary>
    /// This is the Enemy class for the game.
    /// </summary>
    class Enemy : GameObject
    {
        // Constructors
        /// <summary>
        /// Constructs an Enemy GameObject.
        /// </summary>
        /// <param name="texture">The texture of the Enemy GameObject.</param>
        /// <param name="position">The position of the Enemy GameObject.</param>
        public Enemy(Texture2D texture, Rectangle position) : base(texture, position)
        {
        }

        // Methods
        /// <summary>
        /// Check if the Enemy is colliding with another GameObject.
        /// </summary>
        /// <param name="check">The GameObject to check.</param>
        /// <returns>A boolean signifying whether or not the GameObject is intersecting with this Enemy.</returns>
        public bool CheckCollision(GameObject check)
        {
            // If it intersects, return true, else false
            return this.Position.Intersects(check.Position);
        }
    }
}
