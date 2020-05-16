namespace Mundus.Service.Tiles.Crafting 
{
    using System.Linq;
    using Mundus.Data;
    using Mundus.Data.Tiles.Mobs;
    using Mundus.Data.Tiles.Presets;
    using Mundus.Service.Tiles.Items;
    using Mundus.Service.Tiles.Mobs;

    public static class CraftingController 
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

            Data.Windows.WI.SelWin.PrintInventory();
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
        /// Returns all recipes that can be executed with the current items in the player inventory (Inventory.Items)
        /// </summary>
        public static CraftingRecipe[] GetAvalableRecipes() 
        {
            return DataBaseContexts.CTContext.GetAvalableRecipes();
        }
    }
}