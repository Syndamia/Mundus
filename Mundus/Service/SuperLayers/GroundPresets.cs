using System;
using Mundus.Service.Tiles;
using Mundus.Service.Tiles.ItemPresets;

namespace Mundus.Service.SuperLayers {
    public static class GroundPresets {
        /// <summary>
        /// Returns a new instance of the grass ground tile
        /// </summary>
        /// <returns>New instance of the grass ground tile</returns>
        public static GroundTile GetAGrass() {
            return new GroundTile("grass", 1, MaterialPresets.GetALandRock());
        }
    }
}
