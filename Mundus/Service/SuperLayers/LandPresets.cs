using Mundus.Data.Tiles;
using Mundus.Service.Tiles.ItemPresets;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.SuperLayers {
    public static class LandPresets {
        public static Structure GetABoulder() {
            return new Structure("boulder", 10, ToolTypes.Pickaxe, 1, false, MaterialPresets.GetALandRock());
        }

        public static Structure GetATree() {
            return new Structure("tree", 5, ToolTypes.Axe, 1, false, MaterialPresets.GetAStick());
        }
    }
}
