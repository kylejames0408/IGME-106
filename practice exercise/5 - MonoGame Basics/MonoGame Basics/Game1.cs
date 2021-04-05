using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame_Basics
{
    /// <summary>
    /// Used to track direction that the image follows.
    /// </summary>
    enum CardinalDirections { NW, SW, SE, NE }

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        // Fields - Default
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        // Fields - Custom
        private CardinalDirections previousDirection;
        private CardinalDirections direction;
        private Rectangle smallerCourierSixSquare;
        private Texture2D courierSixTexture;
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
            courierSixPosition = new Vector2(0, 10);
            previousDirection = CardinalDirections.SE;

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

            // Load in the Courier Six image
            courierSixTexture = Content.Load<Texture2D>("Courier Six");

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

            // Set previous direction to current direction in-case change necessary
            previousDirection = direction;

            // Get current direction and move image in that direction
            if (direction == CardinalDirections.NE)
            {
                courierSixPosition.X++;
                courierSixPosition.Y--;
            }
            else if (direction == CardinalDirections.SE)
            {
                courierSixPosition.X++;
                courierSixPosition.Y++;
            }
            else if (direction == CardinalDirections.SW)
            {
                courierSixPosition.X--;
                courierSixPosition.Y++;
            }
            else
            {
                courierSixPosition.X--;
                courierSixPosition.Y--;
            }

            // Check if it hits the corner (like the DVD sign in The Office)
            if (courierSixPosition.X < 0 && courierSixPosition.Y < 0)
            {
                courierSixPosition.X = 0;
                courierSixPosition.Y = 0;
                direction = CardinalDirections.SE;
                return;
            }
            if (courierSixPosition.X + courierSixTexture.Width >= graphics.PreferredBackBufferWidth && courierSixPosition.Y + courierSixTexture.Height >= graphics.PreferredBackBufferHeight)
            {
                courierSixPosition.X = graphics.PreferredBackBufferWidth - courierSixTexture.Width;
                courierSixPosition.Y = graphics.PreferredBackBufferHeight - courierSixTexture.Height;
                direction = CardinalDirections.NW;
                return;
            }
            if (courierSixPosition.X + courierSixTexture.Width >= graphics.PreferredBackBufferWidth && courierSixPosition.Y < 0)
            {
                courierSixPosition.X = graphics.PreferredBackBufferWidth - courierSixTexture.Width;
                courierSixPosition.Y = 0;
                direction = CardinalDirections.SW;
                return;
            }
            if (courierSixPosition.X < 0 && courierSixPosition.Y + courierSixTexture.Height >= graphics.PreferredBackBufferHeight)
            {
                courierSixPosition.X = 0;
                courierSixPosition.Y = graphics.PreferredBackBufferHeight - courierSixTexture.Height;
                direction = CardinalDirections.NE;
                return;
            }

            // Change direction on collision with walls
            if (courierSixPosition.X < 0)
            {
                courierSixPosition.X = 0;
                if (previousDirection == CardinalDirections.NW)
                {
                    direction = CardinalDirections.NE;
                }
                else
                {
                    direction = CardinalDirections.SE;
                }
            }
            if (courierSixPosition.X + courierSixTexture.Width >= graphics.PreferredBackBufferWidth)
            {
                courierSixPosition.X = graphics.PreferredBackBufferWidth - courierSixTexture.Width;
                if (previousDirection == CardinalDirections.NE)
                {
                    direction = CardinalDirections.NW;
                }
                else
                {
                    direction = CardinalDirections.SW;
                }
            }
            if (courierSixPosition.Y < 0)
            {
                courierSixPosition.Y = 0;
                if (previousDirection == CardinalDirections.NE)
                {
                    direction = CardinalDirections.SE;
                }
                else
                {
                    direction = CardinalDirections.SW;
                }
            }
            if (courierSixPosition.Y + courierSixTexture.Height >= graphics.PreferredBackBufferHeight)
            {
                courierSixPosition.Y = graphics.PreferredBackBufferHeight - courierSixTexture.Height;
                if (previousDirection == CardinalDirections.SE)
                {
                    direction = CardinalDirections.NE;
                }
                else
                {
                    direction = CardinalDirections.NW;
                }
            }
            
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

            // End drawing them game
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
