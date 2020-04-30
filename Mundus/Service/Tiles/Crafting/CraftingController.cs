using System.Collections.Generic;
using System.Linq;
using Mundus.Data.Crafting;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Service.Tiles.Mobs;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Tiles.Crafting {
    public static class CraftingController {
        private static Dictionary<ItemTile, int> avalableItems;

        /// <summary>
        /// Returns all recipes that can be executed with the current items in the player inventory (Inventory.Items)
        /// </summary>
        /// <returns>All avalable recipies.</returns>
        public static CraftingRecipe[] GetAvalableRecipes() {
            FindAvalableItems();

            List<CraftingRecipe> recipes = new List<CraftingRecipe>();

            foreach (var recipe in RI.AllRecipies) {
                if (recipe.HasEnoughItems(avalableItems)) {
                    recipes.Add(recipe);
                }
            }

            return recipes.ToArray();
        }

        // Sets avalableItems to all items in the player inventory (Inventory.Items)
        private static void FindAvalableItems() {
            avalableItems = MI.Player.Inventory.Items.Where(x => x != null)
                       //Can't use distinct on non primative types, beause they also hold their memory location info (I think).
                       //This is my way of getting only the "unique" item tiles.
                       .Select(x => x.stock_id).Distinct().Select(x => MI.Player.Inventory.Items.Where(y => y != null).First(y => y.stock_id == x))
                       //For each "unique" item tile (key), get how many there are of it in the player inventory (value)
                       .Select(x => new KeyValuePair<ItemTile, int>(x, MI.Player.Inventory.Items.Where(y => y != null).Count(i => i.stock_id == x.stock_id)))
                       .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        /// <summary>
        /// Removes items, used for crafting and adds the result item to the inventory
        /// </summary>
        /// <param name="itemRecipe">CraftingRecipie of the item that will be crafted</param>
        public static void CraftItem(CraftingRecipe itemRecipe, MobTile mob) {
            // Removes all items that are used to craft the result item
            foreach (var itemAndCount in itemRecipe.GetRequiredItemsAndCounts()) {
                for(int i = 0, removedItems = 0; i < mob.Inventory.Items.Length && removedItems < itemAndCount.Value; i++) {
                    if (MI.Player.Inventory.Items[i] != null) {
                        if (MI.Player.Inventory.Items[i].stock_id == itemAndCount.Key.stock_id) {
                            MI.Player.Inventory.Items[i] = null;
                            removedItems++;
                        }
                    }
                }
            }
            ItemTile tmp = null;

            // Adds the result item to the inventory (in the correct data type)
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