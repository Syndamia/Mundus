using System;
using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles;
using Mundus.Service.Tiles.ItemPresets;

namespace Mundus.Service.Mobs.LandMobs {
    public static class LandMobsPresets {
        /// <summary>
        /// Returns a new instance of the cow mob tile
        /// </summary>
        public static MobTile GetACow() {
            return new MobTile("L_cow", 10, 1, LI.Land, 1, MaterialPresets.GetAGrass());
        }
    }
}
