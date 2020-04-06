using System;
using Mundus.Data.Tiles;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Tiles.ItemPresets {
    public static class ToolPresets {
        public static Tool GetAWoodenPickaxe() {
            return new Tool("wooden_pickaxe", ToolTypes.Pickaxe, 1);
        }

        public static Tool GetAWoodenAxe() {
            return new Tool("wooden_axe", ToolTypes.Axe, 1);
        }

        public static Tool GetAStonePickaxe() {
            return new Tool("stone_pickaxe", ToolTypes.Pickaxe, 2);
        }

        public static Tool GetAStoneAxe() {
            return new Tool("stone_axe", ToolTypes.Axe, 2);
        }
    }
}
