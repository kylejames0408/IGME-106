using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame_Basics
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        // Fields - Default
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        // Fields - Custom
        private bool north;
        private bool east;
        private Button button;
        private SpriteFont arial12;
        private Texture2D courierSixTexture;
        private Texture2D blueChip;
        private Texture2D yellowChip;
        private Rectangle smallerCourierSixSquare;
        private Vector2 courierSixPosition;

        /// <summary>
        /// Constructs the game class.
        /// </summary>
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                // Resize the window
                PreferredBackBufferWidth = 600,  // set this value to the desired width of your window
                PreferredBackBufferHeight = 600   // set this value to the desired height of your window
            };

            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Initialize fields
            north = false;
            east = true;
            courierSixPosition = new Vector2(0, 10);

            // Initialize mouse
            this.IsMouseVisible = true;

            // Initialize the base class
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

            // Load in content
            arial12 = Content.Load<SpriteFont>("arial12");
            courierSixTexture = Content.Load<Texture2D>("Courier Six");
            blueChip = Content.Load<Texture2D>("Blue Poker Chip");
            yellowChip = Content.Load<Texture2D>("Yellow Poker Chip");

            // Initialize button
            button = new Button(blueChip, yellowChip, new Rectangle(500, 0, 100, 100));

            // Perform calculations to make smaller image
            int smallerWidth = courierSixTexture.Width / 2;
            int smallerHeight = courierSixTexture.Height / 2;

            // Initialize rectangle
            smallerCourierSixSquare = new Rectangle((graphics.PreferredBackBufferWidth - smallerWidth) / 2, (graphics.PreferredBackBufferHeight - smallerWidth) / 2, smallerWidth, smallerHeight);
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

            // Get current direction and move image in that direction
            if (north)
                courierSixPosition.Y--;
            else
                courierSixPosition.Y++;
            
            if (east)
                courierSixPosition.X++;
            else
                courierSixPosition.X--;

            // Change direction on collision with walls
            if (courierSixPosition.X < 0)
            {
                courierSixPosition.X = 0;
                east = true;
            }
            if (courierSixPosition.X + courierSixTexture.Width >= graphics.PreferredBackBufferWidth)
            {
                courierSixPosition.X = graphics.PreferredBackBufferWidth - courierSixTexture.Width;
                east = false;
            }
            if (courierSixPosition.Y < 0)
            {
                courierSixPosition.Y = 0;
                north = false;
            }
            if (courierSixPosition.Y + courierSixTexture.Height >= graphics.PreferredBackBufferHeight)
            {
                courierSixPosition.Y = graphics.PreferredBackBufferHeight - courierSixTexture.Height;
                north = true;
            }

            // Process input for smaller image
            ProcessInput();
            
            // Update the base game
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Begin drawing game
            spriteBatch.Begin();

            // Draw the images
            spriteBatch.Draw(courierSixTexture, courierSixPosition, Color.White);
            spriteBatch.Draw(courierSixTexture, smallerCourierSixSquare, Color.White);

            // Draw text
            spriteBatch.DrawString(arial12, "Kyle James", Vector2.Zero, Color.White);
            spriteBatch.DrawString(arial12, $"({smallerCourierSixSquare.X}, {smallerCourierSixSquare.Y})", new Vector2(0, 12), Color.White);

            // Draw the button
            button.Draw(spriteBatch);

            // End drawing them game
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void ProcessInput()
        {
            // Get the keyboard state
            KeyboardState keyboardState = Keyboard.GetState();

            // Move image if WASD keys are down
            if (keyboardState.IsKeyDown(Keys.W))
                smallerCourierSixSquare.Y--;
            if (keyboardState.IsKeyDown(Keys.A))
                smallerCourierSixSquare.X--;
            if (keyboardState.IsKeyDown(Keys.S))
                smallerCourierSixSquare.Y++;
            if (keyboardState.IsKeyDown(Keys.D))
                smallerCourierSixSquare.X++;
        }
    }
}
