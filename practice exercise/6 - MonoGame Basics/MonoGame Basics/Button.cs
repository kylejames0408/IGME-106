using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame_Basics
{
    /// <summary>
    /// This is a button for your interface.
    /// </summary>
    class Button
    {
        // Fields
        private Rectangle rectangle;
        private readonly Texture2D buttonFace;
        private readonly Texture2D buttonHover;

        // Constructors
        /// <summary>
        /// Constructs a basic button with hover functionality.
        /// </summary>
        /// <param name="buttonFace">The default display of the button.</param>
        /// <param name="buttonHover">The image to display on the button when hovered over.</param>
        /// <param name="rectangle">The rectangle to draw the image in.</param>
        public Button(Texture2D buttonFace, Texture2D buttonHover, Rectangle rectangle)
        {
            // Initialize fields
            this.buttonFace = buttonFace;
            this.buttonHover = buttonHover;
            this.rectangle = rectangle;
        }

        // Methods
        /// <summary>
        /// Determines if mouse is over button and displays proper face.
        /// </summary>
        /// <param name="sb">The SpriteBatch object.</param>
        public void Draw(SpriteBatch sb)
        {
            // Check location of mouse and display correct face
            if (Mouse.GetState().X >= rectangle.X && Mouse.GetState().X <= rectangle.X + rectangle.Width
                &&
                Mouse.GetState().Y >= rectangle.Y && Mouse.GetState().Y <= rectangle.Y + rectangle.Height)
            {
                sb.Draw(buttonHover, rectangle, Color.White);
            }
            else
                sb.Draw(buttonFace, rectangle, Color.White);
        }
    }
}
