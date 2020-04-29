using System;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Tiles.ItemPresets {
    public static class MaterialPresets {
        /// <summary>
        /// Returns a new instance of the land rock material tile
        /// </summary>
        public static Material GetALandRock() {
            return new Material("L_rock");
        }

        /// <summary>
        /// Returns a new instance of the stick material tile
        /// </summary>
        public static Material GetAStick() {
            return new Material("L_stick");
        }

        /// <summary>
        /// (TEMPORARY)
        /// </summary>
        public static Material GetAGrass() {
            return new Material("L_grass");
        }

        /// <summary>
        /// (TEMPORARY)
        /// </summary>
        public static Material GetAStone() {
            return new Material("U_stone");
        }
    }
}
