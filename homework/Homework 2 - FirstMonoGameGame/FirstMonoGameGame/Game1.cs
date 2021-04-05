using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/// <summary>
/// Project space for the first MonoGame game.
/// </summary>
namespace FirstMonoGameGame
{
    /// <summary>
    /// Enumeration that represents the three different game states.
    /// </summary>
    public enum GameState { Menu, Game, GameOver }

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        // Auto-Generated Fields
        readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Fields
        private Texture2D playerAppearance;
        private Texture2D collectible;
        private GameState gameState;
        private Player player;
        private List<Collectible> collectibles;
        private int level;
        private double timer;
        private KeyboardState kbState;
        private KeyboardState previousKbState;
        private Random random;
        private SpriteFont impact50;
        private SpriteFont impact25;
        private Texture2D enemy;
        private List<Enemy> enemies;

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
            level = 0;
            timer = 0;
            gameState = GameState.Menu;
            random = new Random();

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
            playerAppearance = Content.Load<Texture2D>("MrHandy");
            collectible = Content.Load<Texture2D>("FusionCell");
            player = new Player(playerAppearance, new Rectangle(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2, playerAppearance.Width, playerAppearance.Height));
            collectibles = new List<Collectible>();
            gameState = GameState.Menu;
            impact50 = Content.Load<SpriteFont>("impact50");
            impact25 = Content.Load<SpriteFont>("impact25");
            enemy = Content.Load<Texture2D>("MoleRat");
            enemies = new List<Enemy>();
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

            // Get keyboard input
            kbState = Keyboard.GetState();

            // Finite State Machine Logic
            switch (gameState)
            {
                case GameState.Menu:
                    // If the user presses "Enter" in the menu, start the game
                    if (SingleKeyPress(Keys.Enter))
                    {
                        gameState = GameState.Game;
                        ResetGame();
                    }

                    break;
                case GameState.Game:
                    // Adjust timer
                    timer -= gameTime.ElapsedGameTime.TotalSeconds;

                    // Move player
                    MovePlayer();
                    ScreenWrap(player);
                    
                    // Move enemies
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        enemies[i].X += 3;
                        ScreenWrap(enemies[i]);
                    }

                    // Check collectible collisions
                    for (int i = 0; i < collectibles.Count; i++)
                    {
                        if (collectibles[i].CheckCollision(player))
                        {
                            collectibles[i].Active = false;
                            player.LevelScore++;
                            player.TotalScore++;
                        }
                    }

                    // Check if all collectibles were collected
                    if (player.LevelScore == collectibles.Count)
                        NextLevel();

                    // Check if Player collides with Enemy
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        if (enemies[i].CheckCollision(player))
                        {
                            gameState = GameState.GameOver;
                        }
                    }

                    // If the timer reaches, or goes below zero, end the game
                    if (timer <= 0)
                        gameState = GameState.GameOver;

                    break;

                case GameState.GameOver:
                    // If the user presses "Enter" when the game ended, go to the menu
                    if (SingleKeyPress(Keys.Enter))
                        gameState = GameState.Menu;

                    break;
            }

            previousKbState = kbState;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Begin SpriteBatch
            spriteBatch.Begin();

            // Check Finite State Machine
            switch (gameState)
            {
                case GameState.Game:
                    // Draw information
                    spriteBatch.DrawString(impact25, $"Level: {level}", Vector2.Zero, Color.White);
                    spriteBatch.DrawString(impact25, $"Score: {player.LevelScore}", new Vector2(0, 25), Color.White);
                    spriteBatch.DrawString(impact25, String.Format("Time: {0:0.00}", timer), new Vector2(0, 50), Color.White);
                    
                    // Draw player
                    player.Draw(spriteBatch);

                    // Draw collectibles
                    for (int i = 0; i < collectibles.Count; i++)
                        collectibles[i].Draw(spriteBatch);

                    // Draw enemies
                    for (int i = 0; i < enemies.Count; i++)
                        enemies[i].Draw(spriteBatch);

                    break;

                case GameState.GameOver:
                    spriteBatch.DrawString(impact50, "Game Over", new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2 - 50), Color.White);
                    spriteBatch.DrawString(impact25, $"Level Reached: {level}", new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2 + 25), Color.White);
                    spriteBatch.DrawString(impact25, $"Score: {player.TotalScore}", new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2 + 50), Color.White);
                    spriteBatch.DrawString(impact25, "Press Enter to Return to Menu", new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2 + 75), Color.White);
                    break;

                case GameState.Menu:
                    spriteBatch.Draw(playerAppearance, new Rectangle(0, 0, GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height), Color.White);
                    spriteBatch.DrawString(impact50, "Mr. Handyman", new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2 - 50), Color.White);
                    spriteBatch.DrawString(impact25, "Press Enter to Start", new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2 + 25), Color.White);
                    break;
            }

            // End SpriteBatch
            spriteBatch.End();

            base.Draw(gameTime);
        }

        // Methods
        /// <summary>
        /// Sets up each level the player encounters.
        /// </summary>
        private void NextLevel()
        {
            // Increment level number
            level++;

            // Reset timer
            timer = 10;

            // Reset LevelScore
            player.LevelScore = 0;

            // Center player
            player.X = GraphicsDevice.Viewport.Width / 2;
            player.Y = GraphicsDevice.Viewport.Height / 2;

            // Clear list of collectibles
            collectibles.Clear();

            // Clear list of enemies
            enemies.Clear();

            // Calculate number of collectibles for level
            int numberOfCollectibles = (level - 1) * 3 + 5;

            // Loop to create collectibles
            for (int i = 0; i < numberOfCollectibles; i++)
            {
                // Create random valid location
                int x = random.Next(GraphicsDevice.Viewport.Width);
                int y = random.Next(GraphicsDevice.Viewport.Height);

                // Calculate validity of x
                if (x + collectible.Width > GraphicsDevice.Viewport.Width)
                    // Move the collectible the difference
                    x -= (x + collectible.Width) - GraphicsDevice.Viewport.Width;

                // Calculate validity of y
                if (y + collectible.Height > GraphicsDevice.Viewport.Height)
                    // Move the collectible the difference
                    y -= (y + collectible.Height) - GraphicsDevice.Viewport.Height;

                collectibles.Add(new Collectible(collectible, new Rectangle(x, y, collectible.Width, collectible.Height)));
            }

            // Loop to create enemies
            for (int i = 0; i < level; i++)
            {
                // Create random valid location
                int x = random.Next(GraphicsDevice.Viewport.Width);
                int y = random.Next(GraphicsDevice.Viewport.Height);

                // Calculate validity of x
                if (x + enemy.Width > GraphicsDevice.Viewport.Width)
                    // Move the collectible the difference
                    x -= (x + enemy.Width) - GraphicsDevice.Viewport.Width;

                // Calculate validity of y
                if (y + enemy.Height > GraphicsDevice.Viewport.Height)
                    // Move the collectible the difference
                    y -= (y + enemy.Height) - GraphicsDevice.Viewport.Height;

                // Calulate validity of y to ensure player can spawn
                if (y + enemy.Height >= (GraphicsDevice.Viewport.Height / 2) && y <= (GraphicsDevice.Viewport.Height / 2) + player.Texture.Height)
                    y -= (y + enemy.Height);

                enemies.Add(new Enemy(enemy, new Rectangle(x, y, enemy.Width, enemy.Height)));
            }
        }

        /// <summary>
        /// Sets up the initial values for the game.
        /// </summary>
        private void ResetGame()
        {
            level = 0;
            player.TotalScore = 0;
            NextLevel();
        }

        /// <summary>
        /// Keeps a GameObject on the screen at all times.
        /// </summary>
        /// <param name="objToWrap">The GameObject to wrap around the screen.</param>
        private void ScreenWrap(GameObject objToWrap)
        {
            // Check if object hits left side
            if (objToWrap.X < 0)
                objToWrap.X = GraphicsDevice.Viewport.Width - objToWrap.Position.Width;

            // Check if object hits right side
            if (objToWrap.X + objToWrap.Position.Width > GraphicsDevice.Viewport.Width)
                objToWrap.X = 0;

            // Check if object hits top
            if (objToWrap.Y < 0)
                objToWrap.Y = GraphicsDevice.Viewport.Height - objToWrap.Position.Height;

            // Check if object hits bottom
            if (objToWrap.Y + objToWrap.Position.Height > GraphicsDevice.Viewport.Height)
                objToWrap.Y = 0;
        }

        /// <summary>
        /// Checks if the specified key is down in current state, but not in previous state.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns>True if this is the first frame that the key was pressed and false otherwise.</returns>
        private bool SingleKeyPress(Keys key)
        {
            // Check is key was recently released, if it was, return false (not looking for release)
            if (kbState.IsKeyDown(key) == false && previousKbState.IsKeyDown(key) == true)
                return false;

            return kbState.IsKeyDown(key) != previousKbState.IsKeyDown(key);
        }

        /// <summary>
        /// Changes player's coordinates upon direction key presses.
        /// </summary>
        private void MovePlayer()
        {
            if (kbState.IsKeyDown(Keys.W))
                player.Y -= 5;

            if (kbState.IsKeyDown(Keys.A))
                player.X -= 5;

            if (kbState.IsKeyDown(Keys.S))
                player.Y += 5;

            if (kbState.IsKeyDown(Keys.D))
                player.X += 5;
        }
    }
}
