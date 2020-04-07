using System;
using Mundus.Service.Tiles;
using Mundus.Service.Tiles.ItemPresets;

namespace Mundus.Service.SuperLayers {
    public static class GroundPresets {
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
