using System;
using System.Collections.Generic;
using System.Linq;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Crafting {
    public static class CraftingController {
        private static Dictionary<ItemTile, int> avalable;

        public static void FindAvalableItems() {
            avalable = LMI.Player.Inventory.Items.Where(x => x != null)
                       //Can't use distinct on non primative types, beause they also hold their memory location info.
                       //This is my way of getting only the "unique" item tiles.
                       .Select(x => x.stock_id).Distinct().Select(x => LMI.Player.Inventory.Items.First(y => y.stock_id == x)) 
                       .Select(x => new KeyValuePair<ItemTile, int>(x, LMI.Player.Inventory.Items.Where(y => y != null).Count(i => i.stock_id == x.stock_id)))
                       .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
}