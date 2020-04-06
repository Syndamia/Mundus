using System.Collections.Generic;
using Mundus.Service.Crafting;
using Mundus.Service.Tiles.ItemPresets;

namespace Mundus.Data.Crafting {
    public static class RI { //short for Recipe Instances
        public static List<CraftingRecipe> AllRecipies { get; private set; }

        public static CraftingRecipe WoodenShovel { get; private set; }
        public static CraftingRecipe WoodenPickaxe { get; private set; }
        public static CraftingRecipe WoodenAxe { get; private set; }

        public static CraftingRecipe StoneShovel { get; private set; }
        public static CraftingRecipe StonePickAxe { get; private set; }
        public static CraftingRecipe StoneAxe { get; private set; }

        public static void CreateInstances() {
            WoodenShovel = new CraftingRecipe(ToolPresets.GetAWoodenShovel(), 5, MaterialPresets.GetAStick());
            WoodenPickaxe = new CraftingRecipe(ToolPresets.GetAWoodenPickaxe(), 4, MaterialPresets.GetAStick());
            WoodenAxe = new CraftingRecipe(ToolPresets.GetAWoodenAxe(), 3, MaterialPresets.GetAStick());

            StoneShovel = new CraftingRecipe(ToolPresets.GetAStoneShovel(), 4, MaterialPresets.GetALandRock(), 2, MaterialPresets.GetAStick());
            StonePickAxe = new CraftingRecipe(ToolPresets.GetAStonePickaxe(), 4, MaterialPresets.GetALandRock(), 2, MaterialPresets.GetAStick());
            StoneAxe = new CraftingRecipe(ToolPresets.GetAStoneAxe(), 3, MaterialPresets.GetALandRock(), 2, MaterialPresets.GetAStick());

            AllRecipies = new List<CraftingRecipe> { 
                WoodenShovel, WoodenPickaxe, WoodenAxe, 
                StoneShovel, StonePickAxe, StoneAxe
            };
        }
    }
}
