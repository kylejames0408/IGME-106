using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Project space for the first MonoGame game.
/// </summary>
namespace FirstMonoGameGame
{
    /// <summary>
    /// This is the Player class for the game.
    /// </summary>
    class Player : GameObject
    {
        // Fields
        private int levelScore;
        private int totalScore;

        // Properties
        /// <summary>
        /// Gets and sets the score of the current level.
        /// </summary>
        public int LevelScore { get { return levelScore; } set { levelScore = value; } }
        
        /// <summary>
        /// Gets and sets the score of the total game.
        /// </summary>
        public int TotalScore { get { return totalScore; } set { totalScore = value; } }
    
        // Constructors
        /// <summary>
        /// Constructs a Player GameObject.
        /// </summary>
        /// <param name="texture">The texture of the Player GameObject.</param>
        /// <param name="position">The position of the Player GameObject.</param>
        public Player(Texture2D texture, Rectangle position) : base(texture, position)
        {
            // Initialize fields
            levelScore = 0;
            totalScore = 0;
        }
    }
}
