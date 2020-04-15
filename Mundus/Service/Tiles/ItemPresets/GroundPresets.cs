using System;
using Mundus.Service.Tiles.Items;
using Mundus.Service.Tiles.ItemPresets;

namespace Mundus.Service.Tiles.ItemPresets {
    public static class GroundPresets {
        public static GroundTile GetASSky() {
            return new GroundTile("S_sky", -1, false);
        }

        /// <summary>
        /// Returns a new instance of the grass ground tile
        /// </summary>
        /// <returns>New instance of the grass ground tile</returns>
        public static GroundTile GetALGrass() {
            return new GroundTile("L_grass", 1);
        }

        public static GroundTile GetAURoche() {
            return new GroundTile("U_roche", 10);
        }
    }
}
