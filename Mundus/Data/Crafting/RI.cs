using System;
using System.Collections.Generic;
using Mundus.Data.Tiles;
using Mundus.Service.Crafting;
using Mundus.Service.Tiles.ItemPresets;
using Mundus.Service.Tiles.Items;

namespace Mundus.Data.Crafting {
    public static class RI { //short for Recipe Instances
        public static List<CraftingRecipe> AllRecipies { get; private set; }

        public static CraftingRecipe WoodenPickaxe { get; private set; }
        public static CraftingRecipe WoodenAxe { get; private set; }

        public static CraftingRecipe StonePickAxe { get; private set; }
        public static CraftingRecipe StoneAxe { get; private set; }

        public static void CreateInstances() {
            WoodenPickaxe = new CraftingRecipe(ToolPresets.GetAWoodenPickaxe(), 4, MaterialPresets.GetAStick());
            WoodenAxe = new CraftingRecipe(ToolPresets.GetAWoodenAxe(), 3, MaterialPresets.GetAStick());

            StonePickAxe = new CraftingRecipe(ToolPresets.GetAStonePickaxe(), 4, MaterialPresets.GetALandRock(), 2, MaterialPresets.GetAStick());
            StoneAxe = new CraftingRecipe(ToolPresets.GetAStoneAxe(), 3, MaterialPresets.GetALandRock(), 2, MaterialPresets.GetAStick());

            AllRecipies = new List<CraftingRecipe> { 
                WoodenPickaxe, WoodenAxe, StonePickAxe, StoneAxe
            };
        }
    }
}
