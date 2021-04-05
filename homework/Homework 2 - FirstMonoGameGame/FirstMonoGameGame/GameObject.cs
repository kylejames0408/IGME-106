using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Project space for the first MonoGame game.
/// </summary>
namespace FirstMonoGameGame
{
    /// <summary>
    /// This is the main object parent class for the game.
    /// </summary>
    class GameObject
    {
        // Fields
        private Texture2D texture;
        private Rectangle position;

        // Properties
        /// <summary>
        /// Gets and sets the texture of the GameObject.
        /// </summary>
        public Texture2D Texture { get { return texture; } set { texture = value; } }

        /// <summary>
        /// Gets and sets positions and constraints of the GameObject.
        /// </summary>
        public Rectangle Position { get { return position; } set { position = value; } }

        /// <summary>
        /// Gets and sets the X position of the GameObject's position.
        /// </summary>
        public int X { get { return position.X; } set { position.X = value; } }

        /// <summary>
        /// Gets and sets the Y position of the GameObject's position.
        /// </summary>
        public int Y { get { return position.Y; } set { position.Y = value; } }

        // Constructors
        /// <summary>
        /// Constructs a basic GameObject.
        /// </summary>
        /// <param name="texture">The texture of the GameObject.</param>
        /// <param name="position">The position of the GameObject.</param>
        public GameObject(Texture2D texture, Rectangle position)
        {
            // Initialize fields
            this.texture = texture;
            this.position = position;
        }

        // Methods
        /// <summary>
        /// Override-able Draw method that draws the GameObject.
        /// </summary>
        /// <param name="sb">The SpriteBatch object to perform drawing.</param>
        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, Color.White);
        }
    }
}
