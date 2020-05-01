using System;
namespace Mundus.Data {
    public static class Difficulty {
        public const int Peaceful = -10;
        public const int Easy = -5;
        public const int Normal = 10;
        public const int Hard = 40;
        public const int Insane = 80;

        public static int SelDifficulty { get; set; }

        /// <summary>
        /// Returns selected difficulty divided by a number. Used to change energy drain values.
        /// </summary>
        public static double ValueModifier() {
            return SelDifficulty / 80.0;
        }
    }
}
