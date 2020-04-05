using System;
using Mundus.Data.Tiles;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Tiles.ItemPresets {
    public static class ToolPresets {
        public static Tool GetAStonePickaxe() {
            return new Tool("stone_pickaxe", ToolTypes.Pickaxe, 2);
        }
    }
}
