using System;
using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles;

namespace Mundus.Service.Mobs.LandMobs {
    public static class LandMobsPresets {
        public static MobTile GetACow() {
            return new MobTile("L_test_icon_mob", 10, LI.Land);
        }
    }
}
