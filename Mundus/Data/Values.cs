using System;
namespace Mundus.Data {
    public static class Values {

        public static MapSize CurrMapSize { get; set; }
        public enum MapSize {
            SMALL = 14,
            MEDIUM = 16,
            LARGE = 12
        }

        public static Difficulty CurrDifficulty { get; set; }
        public enum Difficulty {
            Peaceful = -10,
            Easy = -5,
            Normal = 10,
            Hard = 40,
            Insane = 80
        }
        /// <summary>
        /// Returns selected difficulty divided by a number. Used to change energy drain values.
        /// </summary>
        public static double DifficultyValueModifier() {
            return (int)CurrDifficulty / 80.0;
        }

        public enum ToolType {
            Shovel,
            Axe,
            Pickaxe,
            Sword
        }
    }
}
