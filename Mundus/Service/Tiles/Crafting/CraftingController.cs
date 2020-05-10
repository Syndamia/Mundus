using System.Collections.Generic;
using System.Linq;
using Mundus.Data.Crafting;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Service.Tiles.Mobs;
using Mundus.Service.Tiles.Items;
using Mundus.Service.Tiles.Items.Presets;
using Mundus.Data;

namespace Mundus.Service.Tiles.Crafting {
    public static class CraftingController {
        /// <summary>
        /// Returns all recipes that can be executed with the current items in the player inventory (Inventory.Items)
        /// </summary>
        /// <returns>All avalable recipies.</returns>
        public static CraftingRecipe[] GetAvalableRecipes() {
            return DataBaseContext.CTContext.GetAvalableRecipes();
        }

        /// <summary>
        /// Removes items, used for crafting and adds the result item to the inventory
        /// </summary>
        /// <param name="itemRecipe">CraftingRecipie of the item that will be crafted</param>
        public static void CraftItem(CraftingRecipe itemRecipe, MobTile mob) {
            //Removes all items that are used to craft the result item
            var reqItems = itemRecipe.GetAllRequiredItems();
            var reqCounts = itemRecipe.GetAllCounts();
            var inventoryItems = mob.Inventory.Items.Where(i => i != null).ToArray();

            for (int item = 0; item < reqItems.Length; item++) 
            {
                for (int i = 0, removed = 0; i < inventoryItems.Length && removed < reqCounts[item]; i++) 
                {
                    if (inventoryItems[i].stock_id == reqItems[item]) {
                        mob.Inventory.DeleteFromItems(i);
                        removed++;
                    }
                }
            }

            ItemTile tmp = ToolPresets.GetFromStock(itemRecipe.ResultItem);
            if (tmp == null) {
                tmp = StructurePresets.GetFromStock(itemRecipe.ResultItem);
            }
            MI.Player.Inventory.AppendToItems(tmp);

            Data.Windows.WI.SelWin.PrintInventory();
        }

        /// <summary>
        /// Does CraftItem method for the player
        /// </summary>
        /// <param name="itemRecipe">CraftingRecipie of the item that will be crafted</param>
        public static void CraftItemPlayer(CraftingRecipe itemRecipe) {
            CraftItem(itemRecipe, MI.Player);
        }
    }
}