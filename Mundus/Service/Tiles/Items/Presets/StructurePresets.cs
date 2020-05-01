using Mundus.Data.Tiles;

namespace Mundus.Service.Tiles.Items.Presets {
    public static class StructurePresets {
        /// <summary>
        /// Returns a new instance of the land boulder structure
        /// </summary>
        public static Structure GetALBoulder() {
            return new Structure("L_boulder", "L_boulder_inventory", 7, ToolTypes.Pickaxe, 1, false, false, MaterialPresets.GetALandRock());
        }

        /// <summary>
        /// Returns a new instance of the land tree structure
        /// </summary>
        public static Structure GetALTree() {
            return new Structure("L_tree", "L_tree_inventory", 5, ToolTypes.Axe, 1, false, false, MaterialPresets.GetALandStick());
        }

        /// <summary>
        /// Returns a new instance of the underground rock structure
        /// </summary>
        public static Structure GetAURock() {
            return new Structure("U_rock", "U_rock", 10, ToolTypes.Pickaxe, 2, false, false, MaterialPresets.GetAStone());
        }

        public static Structure GetAWoodenLadder() {
            return new Structure("L_wooden_ladder", "L_wooden_ladder_inventory", 1, ToolTypes.Axe, 1, true, true);
        }
    }
}
