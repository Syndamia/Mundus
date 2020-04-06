using System;
using System.Collections.Generic;
using System.Linq;
using Mundus.Data.Crafting;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Crafting {
    public static class CraftingController {
        private static Dictionary<ItemTile, int> avalableItems;

        /// <summary>
        /// Gets all different items and their quantaties in the inventory. Stores that in memory.
        /// </summary>
        public static void FindAvalableItems() {
            avalableItems = LMI.Player.Inventory.Items.Where(x => x != null)
                       //Can't use distinct on non primative types, beause they also hold their memory location info.
                       //This is my way of getting only the "unique" item tiles.
                       .Select(x => x.stock_id).Distinct().Select(x => LMI.Player.Inventory.Items.Where(y => y != null).First(y => y.stock_id == x))
                       //For each "unique" item tile (key), get how many there are of it in the player inventory (value)
                       .Select(x => new KeyValuePair<ItemTile, int>(x, LMI.Player.Inventory.Items.Where(y => y != null).Count(i => i.stock_id == x.stock_id)))
                       .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        public static CraftingRecipe[] GetAvalableRecipies() {
            List<CraftingRecipe> recipes = new List<CraftingRecipe>();

            foreach (var recipe in RI.AllRecipies) {
                if (recipe.HasEnoughItems(avalableItems)) {
                    recipes.Add(recipe);
                }
            }

            return recipes.ToArray();
        }

        /// <summary>
        /// Removes items, used for crafting and adds the result item to the inventory
        /// </summary>
        /// <param name="itemRecipe">CraftingRecipie of the item that will be crafted</param>
        public static void CraftItem(CraftingRecipe itemRecipe) {
            foreach (var itemAndCount in itemRecipe.GetRequiredItemsAndCounts()) {
                for(int i = 0, removedItems = 0; i < LMI.Player.Inventory.Items.Length && removedItems < itemAndCount.Value; i++) {
                    if (LMI.Player.Inventory.Items[i] != null) {
                        if (LMI.Player.Inventory.Items[i].stock_id == itemAndCount.Key.stock_id) {
                            LMI.Player.Inventory.Items[i] = null;
                            removedItems++;
                        }
                    }
                }
            }
            ItemTile tmp = null;

            if (itemRecipe.ResultItem.GetType() == typeof(Material)) {
                tmp = new Material((Material)itemRecipe.ResultItem);
            }
            if (itemRecipe.ResultItem.GetType() == typeof(Tool)) {
                tmp = new Tool((Tool)itemRecipe.ResultItem);
            }
            if (itemRecipe.ResultItem.GetType() == typeof(Gear)) {
                tmp = new Gear((Gear)itemRecipe.ResultItem);
            }
            if (itemRecipe.ResultItem.GetType() == typeof(Structure)) {
                tmp = new Structure((Structure)itemRecipe.ResultItem);
            }
            LMI.Player.Inventory.AppendToItems(tmp);

            Data.Windows.WI.SelWin.PrintInventory();
        }
    }
}