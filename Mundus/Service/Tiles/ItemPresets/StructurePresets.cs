using System;
using Mundus.Data.Tiles;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Tiles.ItemPresets {
    public static class StructurePresets {
        public static Structure GetALBoulder() {
            return new Structure("L_boulder", "L_boulder_inventory", 7, ToolTypes.Pickaxe, 1, false, false, MaterialPresets.GetALandRock());
        }

        public static Structure GetALTree() {
            return new Structure("L_tree", "L_tree_inventory", 5, ToolTypes.Axe, 1, false, false, MaterialPresets.GetAStick());
        }

        public static Structure GetAURock() {
            return new Structure("U_rock", "U_rock", 10, ToolTypes.Pickaxe, 2);
        }

        public static Structure GetAWoodenLadder() {
            return new Structure("L_wooden_ladder", "L_wooden_ladder_inventory", 1, ToolTypes.Axe, 1, true, true);
        }
    }
}
