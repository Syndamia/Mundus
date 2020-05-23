namespace Mundus.Service.Tiles 
{
    using System.Linq;
    using Mundus.Data;
    using Mundus.Data.Crafting;
    using Mundus.Service.Tiles.Items;
    using Mundus.Service.Tiles.Items.Presets;
    using Mundus.Service.Tiles.Mobs;
    using Mundus.Service.Windows;

    public static class RecipeController 
    {
        /// <summary>
        /// Removes items and adds the result item to the inventory
        /// </summary>
        public static void CraftItem(CraftingRecipe itemRecipe, MobTile mob) 
        {
            // Removes all items that are used to craft the result item
            var reqItems = itemRecipe.GetAllRequiredItems();
            var reqCounts = itemRecipe.GetAllCounts();

            var allInventoryItems = mob.Inventory.Items.Where(i => i != null).ToArray();

            for (int item = 0; item < reqItems.Length; item++) 
            {
                for (int i = 0, removed = 0; i < allInventoryItems.Length && removed < reqCounts[item]; i++) 
                {
                    if (allInventoryItems[i].stock_id == reqItems[item]) 
                    {
                        mob.Inventory.DeleteFromItems(i);
                        removed++;
                    }
                }
            }

            ItemTile result = ToolPresets.GetFromStock(itemRecipe.ResultItem);

            if (result == null) 
            {
                result = StructurePresets.GetFromStock(itemRecipe.ResultItem);
            }

            MI.Player.Inventory.AppendToItems(result);

            WI.SelWin.PrintInventory();
        }

        /// <summary>
        /// Does CraftItem method for the player
        /// </summary>
        /// <param name="itemRecipe">CraftingRecipie of the item that will be crafted</param>
        public static void CraftItemPlayer(CraftingRecipe itemRecipe) 
        {
            CraftItem(itemRecipe, MI.Player);
        }

        /// <summary>
        /// Checks if the given array of items has enough of every requried item
        /// </summary>
        /// <returns><c>true</c>If has enough<c>false</c>otherwise</returns>
        public static bool HasEnoughItems(CraftingRecipe recipe, ItemTile[] items) {
            bool hasEnough = false;

            if (items.Any(item => item != null)) {
                var allItemStocks = items.Where(x => x != null).Select(x => x.stock_id).ToArray();

                hasEnough = allItemStocks.Contains(recipe.ReqItem1) &&
                            allItemStocks.Count(i => i == recipe.ReqItem1) >= recipe.Count1;

                if (recipe.ReqItem2 != null && hasEnough) {
                    hasEnough = allItemStocks.Contains(recipe.ReqItem2) &&
                                allItemStocks.Count(i => i == recipe.ReqItem2) >= recipe.Count2;
                }
                if (recipe.ReqItem3 != null && hasEnough) {
                    hasEnough = allItemStocks.Contains(recipe.ReqItem3) &&
                                allItemStocks.Count(i => i == recipe.ReqItem3) >= recipe.Count3;
                }
                if (recipe.ReqItem4 != null && hasEnough) {
                    hasEnough = allItemStocks.Contains(recipe.ReqItem4) &&
                                allItemStocks.Count(i => i == recipe.ReqItem4) >= recipe.Count4;
                }
                if (recipe.ReqItem5 != null && hasEnough) {
                    hasEnough = allItemStocks.Contains(recipe.ReqItem5) &&
                                allItemStocks.Count(i => i == recipe.ReqItem5) >= recipe.Count5;
                }
            }

            return hasEnough;
        }

        /// <summary>
        /// Returns an array with all the recipes that can be crafted with the items the player has
        /// </summary>
        public static CraftingRecipe[] GetAvalableRecipes() 
        {
            var recipes = DataBaseContexts.CTContext.CraftingRecipes.ToArray();
            return recipes.Where(cr => HasEnoughItems(cr, MI.Player.Inventory.Items)).ToArray();
        }



        /// <summary>
        /// Truncates CraftingRecipes table and adds the crafting recipes (and saves changes)
        /// </summary>
        public static void AddAllRecipes() {
            DataBaseContexts.CTContext.TruncateTable();
            var craftingRecipes = DataBaseContexts.CTContext.CraftingRecipes;

            craftingRecipes.Add(new CraftingRecipe(ToolPresets.GetAWoodenShovel().stock_id, 5, MaterialPresets.GetALandStick().stock_id));
            craftingRecipes.Add(new CraftingRecipe(ToolPresets.GetAWoodenPickaxe().stock_id, 4, MaterialPresets.GetALandStick().stock_id));
            craftingRecipes.Add(new CraftingRecipe(ToolPresets.GetAWoodenAxe().stock_id, 3, MaterialPresets.GetALandStick().stock_id));
            craftingRecipes.Add(new CraftingRecipe(ToolPresets.GetAWoodenLongsword().stock_id, 4, MaterialPresets.GetALandStick().stock_id));

            craftingRecipes.Add(new CraftingRecipe(ToolPresets.GetARockShovel().stock_id, 4, MaterialPresets.GetALandRock().stock_id, 2, MaterialPresets.GetALandStick().stock_id));
            craftingRecipes.Add(new CraftingRecipe(ToolPresets.GetARockPickaxe().stock_id, 4, MaterialPresets.GetALandRock().stock_id, 2, MaterialPresets.GetALandStick().stock_id));
            craftingRecipes.Add(new CraftingRecipe(ToolPresets.GetARockAxe().stock_id, 3, MaterialPresets.GetALandRock().stock_id, 2, MaterialPresets.GetALandStick().stock_id));
            craftingRecipes.Add(new CraftingRecipe(ToolPresets.GetARockLongsword().stock_id, 5, MaterialPresets.GetALandRock().stock_id, 2, MaterialPresets.GetALandStick().stock_id));

            craftingRecipes.Add(new CraftingRecipe(StructurePresets.GetAWoodenLadder().inventory_stock_id, 6, MaterialPresets.GetALandStick().stock_id));

            DataBaseContexts.CTContext.SaveChanges();
        }
    }
}