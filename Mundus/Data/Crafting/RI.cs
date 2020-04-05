using System;
using System.Collections.Generic;
using Mundus.Data.Tiles;
using Mundus.Service.Crafting;
using Mundus.Service.Tiles.ItemPresets;
using Mundus.Service.Tiles.Items;

namespace Mundus.Data.Crafting {
    public static class RI { //short for Recipe Instances
        public static List<CraftingRecipe> AllRecipies { get; private set; }

        public static CraftingRecipe StonePickAxe { get; private set; }

        public static void CreateInstances() {
            AllRecipies = new List<CraftingRecipe>();

            StonePickAxe = new CraftingRecipe(ToolPresets.GetAStonePickaxe(), 2, MaterialPresets.GetALandRock(), 2, MaterialPresets.GetAStick());
            AllRecipies.Add(StonePickAxe);
        }
    }
}
