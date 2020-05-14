using Mundus.Service.Tiles.Items.Types;
using static Mundus.Data.Values;

namespace Mundus.Service.Tiles.Items.Presets {
    public static class StructurePresets {
        private static Structure lBoulder = new Structure("L_boulder", "L_boulder_inventory", 7, ToolType.Pickaxe, 1, false, false, MaterialPresets.GetALandRock());
        private static Structure lTree = new Structure("L_tree", "L_tree_inventory", 5, ToolType.Axe, 1, false, false, MaterialPresets.GetALandStick());
        private static Structure uRock = new Structure("U_rock", "U_rock", 10, ToolType.Pickaxe, 2, false, false, MaterialPresets.GetAStone());

        public static Structure GetLBoulder() {
            return lBoulder;
        }

        public static Structure GetLTree() {
            return lTree;
        }

        public static Structure GetURock() {
            return uRock;
        }

        public static Structure GetAWoodenLadder() {
            return new Structure("L_wooden_ladder", "L_wooden_ladder_inventory", 1, ToolType.Axe, 1, true, true);
        }

        public static Structure GetFromStock(string stock_id)  {
            switch(stock_id) {
                case "L_boulder": return GetLBoulder();
                case "L_tree": return GetLTree();
                case "U_rock": return GetURock();
                case "L_wooden_ladder_inventory":
                case "L_wooden_ladder": return GetAWoodenLadder();
                default: return null;
            }
        }
    }
}
