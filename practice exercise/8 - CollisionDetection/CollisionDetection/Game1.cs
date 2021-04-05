using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CollisionDetection
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        // Auto-generated Fields
        readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Fields
        private Texture2D circle;
        private Texture2D square;
        private SquareEntity squarePlayer;
        private Random random;
        private List<SquareEntity> squareEntities;
        private CircleEntity circlePlayer;
        private List<CircleEntity> circleEntities;
        private GameState gameState;
        private SpriteFont arial12;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        // Auto-generated Methods
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Initialize fields
            random = new Random();
            squareEntities = new List<SquareEntity>(10);
            circleEntities = new List<CircleEntity>(10);
            gameState = GameState.Square;

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
            circle = Content.Load<Texture2D>("circle");
            square = Content.Load<Texture2D>("square");
            arial12 = Content.Load<SpriteFont>("arial12");

            // Create SquareEntities
            squarePlayer = new SquareEntity(50, 50, 50, 50, square);

            for (int i = 0; i < 10; i++)
            {
                squareEntities.Add(
                    new SquareEntity(
                        random.Next(GraphicsDevice.Viewport.Width),
                        random.Next(GraphicsDevice.Viewport.Height),
                        random.Next(5, 51),
                        random.Next(5, 51),
                        square));
            }

            // Create CircleEntities
            circlePlayer = new CircleEntity(50, 50, 25, circle);

            for (int i = 0; i < 10; i++)
            {
                circleEntities.Add(
                    new CircleEntity(
                        random.Next(GraphicsDevice.Viewport.Width),
                        random.Next(GraphicsDevice.Viewport.Width),
                        random.Next(5, 51),
                        circle));
            }
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

            // Get keyboard state
            KeyboardState keyboardState = Keyboard.GetState();

            switch(gameState)
            {
                case GameState.Square:
                    // If 2 is pressed, change gamemode
                    if (keyboardState.IsKeyDown(Keys.NumPad2))
                        gameState = GameState.Circle;

                    // Process squarePlayer movement
                    if (keyboardState.IsKeyDown(Keys.W))
                        squarePlayer.Y -= 5;
                    if (keyboardState.IsKeyDown(Keys.A))
                        squarePlayer.X -= 5;
                    if (keyboardState.IsKeyDown(Keys.S))
                        squarePlayer.Y += 5;
                    if (keyboardState.IsKeyDown(Keys.D))
                        squarePlayer.X += 5;
                    break;

                case GameState.Circle:
                    // If 1 is pressed, change gamemode
                    if (keyboardState.IsKeyDown(Keys.NumPad1))
                        gameState = GameState.Square;

                    // Process circlePlayer movement
                    if (keyboardState.IsKeyDown(Keys.W))
                        circlePlayer.Y -= 5;
                    if (keyboardState.IsKeyDown(Keys.A))
                        circlePlayer.X -= 5;
                    if (keyboardState.IsKeyDown(Keys.S))
                        circlePlayer.Y += 5;
                    if (keyboardState.IsKeyDown(Keys.D))
                        circlePlayer.X += 5;
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Start SpriteBatch
            spriteBatch.Begin();

            switch(gameState)
            {
                case GameState.Square:
                    // Draw squarePlayer
                    squarePlayer.Draw(spriteBatch, Color.Blue);

                    // Check intersection and draw squareEntities
                    for (int i = 0; i < squareEntities.Count; i++)
                    {
                        if (squarePlayer.Intersects(squareEntities[i]))
                        {
                            squarePlayer.Draw(spriteBatch, Color.Red);
                            squareEntities[i].Draw(spriteBatch, Color.Red);
                        }
                        else
                        {
                            squareEntities[i].Draw(spriteBatch, Color.White);
                        }
                    }

                    // Write SpriteFont indicator
                    spriteBatch.DrawString(arial12, "Intersects", new Vector2(0, GraphicsDevice.Viewport.Height - 20), Color.White);
                    break;

                case GameState.Circle:
                    // Draw circlePlayer
                    circlePlayer.Draw(spriteBatch, Color.Blue);

                    // Check intersection and draw circleEntities
                    for (int i = 0; i < circleEntities.Count; i++)
                    {
                        if (circlePlayer.Intersects(circleEntities[i]))
                        {
                            circlePlayer.Draw(spriteBatch, Color.Red);
                            circleEntities[i].Draw(spriteBatch, Color.Red);
                        }
                        else
                        {
                            circleEntities[i].Draw(spriteBatch, Color.White);
                        }
                    }

                    // Write SpriteFont indicator
                    spriteBatch.DrawString(arial12, "Circle-Circle", new Vector2(0, GraphicsDevice.Viewport.Height - 20), Color.White);
                    break;
            }

            // End SpriteBatch
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
