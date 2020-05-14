namespace Mundus.Service.SuperLayers 
{
    using Gtk;
    using Mundus.Data;
    using Mundus.Data.Superlayers.Mobs;
    using Mundus.Data.SuperLayers;
    using Mundus.Service.Tiles.Items.Types;
    using static Mundus.Service.Tiles.Mobs.Inventory;

    public static class ImageController 
    {
        private static ISuperLayerContext superLayer = MI.Player.CurrSuperLayer;

        public enum Layer 
        {
            Ground,
            Structure,
            Mob
        }

        /// <summary>
        /// Returns the image of the selected layer in the superlayer
        /// If there is no item/mob at the position, returns null
        /// </summary>
        public static Image GetPlayerScreenImage(int y, int x, Layer layer)
         {
            Image img = null;

            if (layer == Layer.Ground) 
            {
                img = new Image(GetPlayerGroundStockID(y, x), IconSize.Dnd);
            }
            else if (layer == Layer.Structure && superLayer.GetStructureLayerStock(y, x) != null) 
            {
                img = new Image(GetPlayerStructureStockID(y, x), IconSize.Dnd );
            }
            else if (layer == Layer.Mob && superLayer.GetMobLayerStock(y, x) != null) 
            {
                img = new Image(superLayer.GetMobLayerStock(y, x), IconSize.Dnd);
            }
            return img;
        }

        /// <summary>
        /// Returns the stock_id at the given position in player's superlayer
        /// If there is no stock_id, returns "L_hole"
        /// </summary>
        private static string GetPlayerGroundStockID(int y, int x) 
        {
            if (InsideBoundaries(y, x) && superLayer.GetGroundLayerStock(y, x) != null) 
            {
                return superLayer.GetGroundLayerStock(y, x);
            }

            return "L_hole";
        }

        /// <summary>
        /// Returns the stock_id on the given position of the structure layer the player is currently in
        /// Note: null values get the "blank" image ; GetScreenImage skips if the value is null
        /// </summary>
        private static string GetPlayerStructureStockID(int y, int x) 
        {
            if (InsideBoundaries(y, x) && superLayer.GetStructureLayerStock(y, x) != null) 
            {
                return superLayer.GetStructureLayerStock(y, x);
            }
            return "blank";
        }

        /// <summary>
        /// Checks if the position is inside the map
        /// </summary>
        private static bool InsideBoundaries(int y, int x) 
        {
            return y >= 0 && x >= 0 && x < (int)Values.CurrMapSize && y < (int)Values.CurrMapSize;
        }

        /// <summary>
        /// Returns the Image on the given inventory place of the player at the given index
        /// If there isn't one, returns a "blank" image
        /// </summary>
        public static Image GetPlayerInventoryImage(InventoryPlace place, int index) 
        {
            string stock_id = "blank";

            if (MI.Player.Inventory.GetItemTile(place, index) != null) 
            {
                // Structures have two icons, one when they are placed and one when they are in the inventory
                // All other item types have only one icon.
                if (MI.Player.Inventory.GetItemTile(place, index).GetType() == typeof(Structure)) 
                {
                    stock_id = ((Structure)MI.Player.Inventory.GetItemTile(place, index)).inventory_stock_id;
                }
                else 
                {
                    stock_id = MI.Player.Inventory.GetItemTile(place, index).stock_id;
                }
            }
            // Accessories and gear menus have a different blank icon
            else if (place == InventoryPlace.Accessories || place == InventoryPlace.Gear)
            {
                stock_id = "blank_gear";
            }

            return new Image(stock_id, IconSize.Dnd);
        }
    }
}
