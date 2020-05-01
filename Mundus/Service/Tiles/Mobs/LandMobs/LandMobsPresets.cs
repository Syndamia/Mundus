﻿using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles.Items.Presets;

namespace Mundus.Service.Tiles.Mobs.LandMobs {
    public static class LandMobsPresets {
        /// <summary>
        /// Returns a new instance of the cow mob tile
        /// </summary>
        public static MobTile GetACow() {
            return new MobTile("L_cow", 10, 1, LI.Land, 1, MaterialPresets.GetALandBeefSteak());
        }

        public static MobTile GetASheep() {
            return new MobTile("L_sheep", 8, 1, LI.Land, 1, MaterialPresets.GetALandMuttonSteak());
        }
    }
}
