using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Recursion
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        // MonoGame Generated Fields
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Fields
        private Texture2D bethesdaLogo;
        private SpriteFont impact24;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        // Monogame Generated Methods
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load content
            bethesdaLogo = Content.Load<Texture2D>("Bethesda Logo");
            impact24 = Content.Load<SpriteFont>("impact24");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Begin drawing
            spriteBatch.Begin();

            // Draw recursive image and draw # of recursions
            spriteBatch.DrawString(impact24,
                DrawRecursiveThing(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, Color.White).ToString(),
                new Vector2(0, GraphicsDevice.Viewport.Height - 32),
                Color.Black);

            // Stop drawing
            spriteBatch.End();

            base.Draw(gameTime);
        }

        // Methods
        /// <summary>
        /// Draws an image recursively and tracks number of recursions.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <param name="width">The width of the image.</param>
        /// <param name="height">The height of the image.</param>
        /// <param name="color">The color of the tint.</param>
        /// <returns>The number of recursions.</returns>
        private int DrawRecursiveThing(int x, int y, int width, int height, Color color)
        {
            spriteBatch.Draw(bethesdaLogo, new Rectangle(x, y, width, height), color);

            // If it hits base case, stop recursion
            if (width < 20 || height < 20)
                return 1;

            // Draw proper colors
            if (color == Color.White)
            {
                // Recursively call drawing with specified color
                return DrawRecursiveThing(x, y, width / 2, height / 2, Color.PaleGreen)
                    + DrawRecursiveThing(x + (width / 2), y + (height / 2), width / 2, height / 2, Color.PaleGreen)
                    + 1;
            }
            else
            {
                // Recursively call drawing with specified color
                return DrawRecursiveThing(x, y, width / 2, height / 2, Color.White)
                    + DrawRecursiveThing(x + (width / 2), y + (height / 2), width / 2, height / 2, Color.White)
                    + 1;
            }
        }
    }
}
