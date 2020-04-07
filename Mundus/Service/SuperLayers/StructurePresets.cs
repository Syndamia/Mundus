using Mundus.Data.Tiles;
using Mundus.Service.Tiles.ItemPresets;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.SuperLayers {
    public static class StructurePresets {
        public static Structure GetALBoulder() {
            return new Structure("L_boulder", 7, ToolTypes.Pickaxe, 1, false, MaterialPresets.GetALandRock());
        }

        public static Structure GetALTree() {
            return new Structure("L_tree", 5, ToolTypes.Axe, 1, false, MaterialPresets.GetAStick());
        }

        public static Structure GetAURock() {
            return new Structure("U_rock", 10, ToolTypes.Pickaxe, 2);
        }
    }
}
