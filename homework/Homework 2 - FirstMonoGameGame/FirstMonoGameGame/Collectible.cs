using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Project space for the first MonoGame game.
/// </summary>
namespace FirstMonoGameGame
{
    /// <summary>
    /// This is the Collectible item class for the game.
    /// </summary>
    class Collectible : GameObject
    {
        // Fields
        private bool active;

        // Properties
        /// <summary>
        /// Gets and sets whether the item is active.
        /// </summary>
        public bool Active { get { return active; } set { active = value; } }

        // Constructors
        /// <summary>
        /// Constructs a Collectible GameObject.
        /// </summary>
        /// <param name="texture">The texture of the Collectible GameObject.</param>
        /// <param name="position">The position of the Collectible GameObject.</param>
        public Collectible(Texture2D texture, Rectangle position) : base(texture, position)
        {
            // Initialize fields
            active = true;
        }

        // Methods
        /// <summary>
        /// Check if the Collectible is colliding with another GameObject.
        /// </summary>
        /// <param name="check">The GameObject to check.</param>
        /// <returns>A boolean signifying whether or not the GameObject is intersecting with this Collectible.</returns>
        public bool CheckCollision(GameObject check)
        {
            // If the collectible is inactive it cannot intersect
            if (!active)
                return false;

            // If it intersects, return true, else false
            return this.Position.Intersects(check.Position);
        }

        /// <summary>
        /// Draws the Collectible if it is active.
        /// </summary>
        /// <param name="sb">The SpriteBatch object to perform drawing.</param>
        public override void Draw(SpriteBatch sb)
        {
            // Draw the Collectible if it's active
            if (active)
                base.Draw(sb);
        }
    }
}
