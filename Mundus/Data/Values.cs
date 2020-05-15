namespace Mundus.Data 
{
    /// <summary>
    /// Stores all needed values
    /// </summary>
    public static class Values 
    {
        public const double TAKEN_ENERGY_FROM_FIGHTING = 0.5;

        public const double TAKEN_ENERGY_FROM_MOVEMENT = 0.1;

        public const double ENERGY_TAKEN_FROM_PLACING_GROUND = 0.4;

        public const double ENERGY_TAKEN_FROM_BUILDING_STRUCTURE = 0.5;

        public const double ENERGY_TAKEN_FROM_DESTROYING = 0.6;

        public enum MapSize
        {
            SMALL = 14,
            MEDIUM = 16,
            LARGE = 12
        }

        public enum Difficulty
        {
            Peaceful = -10,
            Easy = -5,
            Normal = 10,
            Hard = 40,
            Insane = 80
        }

        public enum ToolType
        {
            Shovel,
            Axe,
            Pickaxe,
            Sword
        }

        /// <summary>
        /// Gets or sets the current (selected) map size
        /// </summary>
        public static MapSize CurrMapSize { get; set; }

        /// <summary>
        /// Gets or sets the current (selected) difficulty
        /// </summary>
        public static Difficulty CurrDifficulty { get; set; }

        /// <summary>
        /// Returns selected difficulty divided by a number (80). 
        /// Used to change energy drain values.
        /// </summary>
        public static double DifficultyValueModifier() 
        {
            return (int)CurrDifficulty / 80.0;
        }
    }
}