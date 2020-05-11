using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles.Items.Presets;

namespace Mundus.Service.Tiles.Mobs.LandMobs {
    public static class LandMobsPresets {
        /// <summary>
        /// Returns a new instance of the cow mob tile
        /// </summary>
        public static MobTile GetACow() {
            return new MobTile("L_cow", 10, 1, DataBaseContexts.LContext, 1, MaterialPresets.GetALandBeefSteak());
        }

        public static MobTile GetASheep() {
            return new MobTile("L_sheep", 8, 1, DataBaseContexts.LContext, 1, MaterialPresets.GetALandMuttonSteak());
        }

        public static MobTile GetFromStock(string stock_id) {
            switch(stock_id) {
                case "L_cow": return GetACow();
                case "L_sheep": return GetASheep();
                case "player": return MI.Player;
                default: return null;
            }
        }
    }
}
