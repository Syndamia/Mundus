using System.Collections.Generic;
using Mundus.Service.Tiles.Crafting;
using Mundus.Service.Tiles.Items.Presets;

namespace Mundus.Data.Crafting {
    public static class RI { //short for Recipe Instances
        public static List<CraftingRecipe> AllRecipies { get; private set; }

        public static CraftingRecipe WoodenShovel { get; private set; }
        public static CraftingRecipe WoodenPickaxe { get; private set; }
        public static CraftingRecipe WoodenAxe { get; private set; }
        public static CraftingRecipe WoodenLongsword { get; private set; }

        public static CraftingRecipe RockShovel { get; private set; }
        public static CraftingRecipe RockPickaxe { get; private set; }
        public static CraftingRecipe RockAxe { get; private set; }
        public static CraftingRecipe RockLongsword { get; private set; }

        public static CraftingRecipe WoodenLadder { get; private set; }

        public static void CreateInstances() {
            WoodenShovel = new CraftingRecipe(ToolPresets.GetAWoodenShovel(), 5, MaterialPresets.GetAStick());
            WoodenPickaxe = new CraftingRecipe(ToolPresets.GetAWoodenPickaxe(), 4, MaterialPresets.GetAStick());
            WoodenAxe = new CraftingRecipe(ToolPresets.GetAWoodenAxe(), 3, MaterialPresets.GetAStick());
            WoodenLongsword = new CraftingRecipe(ToolPresets.GetAWoodenLongsword(), 4, MaterialPresets.GetAStick());

            RockShovel = new CraftingRecipe(ToolPresets.GetARockShovel(), 4, MaterialPresets.GetALandRock(), 2, MaterialPresets.GetAStick());
            RockPickaxe = new CraftingRecipe(ToolPresets.GetARockPickaxe(), 4, MaterialPresets.GetALandRock(), 2, MaterialPresets.GetAStick());
            RockAxe = new CraftingRecipe(ToolPresets.GetARockAxe(), 3, MaterialPresets.GetALandRock(), 2, MaterialPresets.GetAStick());
            RockLongsword = new CraftingRecipe(ToolPresets.GetARockLongsword(), 5, MaterialPresets.GetALandRock(), 2, MaterialPresets.GetAStick());

            WoodenLadder = new CraftingRecipe(StructurePresets.GetAWoodenLadder(), 6, MaterialPresets.GetAStick());

            AllRecipies = new List<CraftingRecipe> { 
                WoodenShovel, WoodenPickaxe, WoodenAxe, WoodenLongsword,
                RockShovel, RockPickaxe, RockAxe, RockLongsword,
                WoodenLadder
            };
        }
    }
}
