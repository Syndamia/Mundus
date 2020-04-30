using Mundus.Data.Tiles;

namespace Mundus.Service.Tiles.Items.Presets {
    public static class ToolPresets {
        public static Tool GetAWoodenPickaxe() {
            return new Tool("wooden_pickaxe", ToolTypes.Pickaxe, 1);
        }

        public static Tool GetAWoodenAxe() {
            return new Tool("wooden_axe", ToolTypes.Axe, 1);
        }

        public static Tool GetAWoodenShovel() {
            return new Tool("wooden_shovel", ToolTypes.Shovel, 1);
        }

        public static Tool GetAWoodenLongsword() {
            return new Tool("wooden_longsword", ToolTypes.Sword, 2);
        }

        public static Tool GetARockPickaxe() {
            return new Tool("rock_pickaxe", ToolTypes.Pickaxe, 2);
        }

        public static Tool GetARockAxe() {
            return new Tool("rock_axe", ToolTypes.Axe, 2);
        }

        public static Tool GetARockShovel() {
            return new Tool("rock_shovel", ToolTypes.Shovel, 2);
        }

        public static Tool GetARockLongsword() {
            return new Tool("rock_longsword", ToolTypes.Sword, 4);
        }
    }
}
