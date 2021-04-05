using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FSMAnimationStarter
{
	/// <summary>
	/// Enumeration to track different states in Mario's animation.
	/// </summary>
	enum MarioState { FaceLeft, WalkLeft, FaceRight, WalkRight };

	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		// Mario texture stuff
		private Texture2D marioTexture;
		private Vector2 marioPosition;

		// Sprite sheet fields
		private int numSpritesInSheet;
		private int widthOfSingleSprite;

		// Animation-related fields
		private double fps;
		private double secondsPerFrame;
		private double timeCounter;
		private int currentFrame;

		// Finite State Machine Fields
		private MarioState marioState;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
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
			// Initialize Mario state
			marioState = MarioState.FaceLeft;

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

			// Load the mario texture and setup other related vars
			marioTexture = Content.Load<Texture2D>("MarioSpriteSheet");

			numSpritesInSheet = 4; // Hard-code this value
			widthOfSingleSprite = marioTexture.Width / numSpritesInSheet;

			marioPosition = new Vector2(200, 200);

			// Initialize animation data
			fps = 10;
			secondsPerFrame = 1.0 / fps;
			currentFrame = 1;
			timeCounter = 0;


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

			// *** Check and update FINITE STATE MACHINE

			// Get keyboard state
			KeyboardState keyboardState = Keyboard.GetState();

			switch(marioState)
			{
				case MarioState.FaceLeft:
					// If holding left, walk left
					if (keyboardState.IsKeyDown(Keys.Left))
						marioState = MarioState.WalkLeft;

					// If right, set to face right
					if (keyboardState.IsKeyDown(Keys.Right))
						marioState = MarioState.FaceRight;
					break;

				case MarioState.FaceRight:
					// If holding right, walk right
					if (keyboardState.IsKeyDown(Keys.Right))
						marioState = MarioState.WalkRight;

					// If left, set to face left
					if (keyboardState.IsKeyDown(Keys.Left))
						marioState = MarioState.FaceLeft;
					break;

				case MarioState.WalkLeft:
					// Move to the left
					marioPosition.X--;

					// If key is released, stop moving and look left
					if (keyboardState.IsKeyUp(Keys.Left))
						marioState = MarioState.FaceLeft;
					break;

				case MarioState.WalkRight:
					// Move to the right
					marioPosition.X++;

					// If the key is released, stop moving and look right
					if (keyboardState.IsKeyUp(Keys.Right))
						marioState = MarioState.FaceRight;
					break;
			}

			UpdateAnimation(gameTime);
			base.Update(gameTime);
		}

		private void UpdateAnimation(GameTime gt)
		{
			// Add to the time counter (need TOTAL SECONDS here)
			timeCounter += gt.ElapsedGameTime.TotalSeconds;

			// Has enough time gone by to swap frames?
			if (timeCounter >= secondsPerFrame)
			{
				// Update the frame
				currentFrame++;
				if (currentFrame > 3)
					currentFrame = 1;

				// Remove one "frame" worth of time
				timeCounter -= secondsPerFrame;
			}

		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			spriteBatch.Begin();

			// *** Put code to CHECK the FSM and draw mario here
			switch (marioState)
			{
				case MarioState.FaceLeft:
					DrawMarioStanding(SpriteEffects.FlipHorizontally);
					break;

				case MarioState.FaceRight:
					DrawMarioStanding(SpriteEffects.None);
					break;

				case MarioState.WalkLeft:
					DrawMarioWalking(SpriteEffects.FlipHorizontally);
					break;

				case MarioState.WalkRight:
					DrawMarioWalking(SpriteEffects.None);
					break;
			}

			spriteBatch.End();

			base.Draw(gameTime);
		}

		private void DrawMarioWalking(SpriteEffects flip)
		{
			spriteBatch.Draw(
				marioTexture,
				marioPosition,
				new Rectangle(
					currentFrame * widthOfSingleSprite, 
					0, 
					widthOfSingleSprite, 
					marioTexture.Height),
				Color.White,    // Color
				0.0f,           // Rotation
				Vector2.Zero,   // Origin
				Vector2.One,    // Scale
				flip,           // Flip
				0               // Layer depth
				);
		}

		private void DrawMarioStanding(SpriteEffects flip)
		{
			spriteBatch.Draw(
				marioTexture, 
				marioPosition, 
				new Rectangle(0, 0, widthOfSingleSprite, marioTexture.Height),
				Color.White,	// Color
				0.0f,			// Rotation
				Vector2.Zero,	// Origin
				Vector2.One,	// Scale
				flip,			// Flip
				0				// Layer depth
				);
		}
	}
}
