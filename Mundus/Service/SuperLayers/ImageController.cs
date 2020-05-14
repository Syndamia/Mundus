using Gtk;
using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles.Items;
using Mundus.Service.Tiles.Items.Types;
using static Mundus.Data.Values;

namespace Mundus.Service.SuperLayers {
    public static class ImageController {

        /// <summary>
        /// Returns the image of the selected layer in the superlayer
        /// Note: Layer 0 is GroundLayer, 1 is ItemLayer and 2 is Moblayer
        /// Note: null structure tiles and null mob tiles are skipped (returns null)
        /// </summary>
        public static Image GetScreenImage(int row, int col, int layer) {
            ISuperLayerContext superLayer = MI.Player.CurrSuperLayer;
            Image img = null;

            //Layer 0 is GroundLayer, 1 is ItemLayer and 2 is Moblayer
            if (layer == 0) 
            {
                img = new Image(GetPlayerGroundImage(row, col).Stock, IconSize.Dnd);
            }
            else if (layer == 1 && superLayer.GetStructureLayerStock( row, col ) != null) 
            {
                img = new Image(GetPlayerStructureImage(row, col).Stock, IconSize.Dnd );
            }
            else if (layer == 2 && superLayer.GetMobLayerStock(row, col) != null) 
            {
                img = new Image(superLayer.GetMobLayerStock(row, col), IconSize.Dnd);
            }
            return img;
        }

        /// <summary>
        /// Returns the Image on the given position of the ground layer the player is currently in
        /// Note: null values (holes) get the "L_hole" image
        /// </summary>
        public static Image GetPlayerGroundImage(int row, int col) {
            ISuperLayerContext superLayer = MI.Player.CurrSuperLayer;
            Image img = new Image("L_hole", IconSize.Dnd);

            if (row >= 0 && col >= 0 && col < (int)Values.CurrMapSize && row < (int)Values.CurrMapSize &&
                superLayer.GetGroundLayerStock(row, col) != null) {
                img = new Image(superLayer.GetGroundLayerStock(row, col), IconSize.Dnd);
            }
            return img;
        }

        /// <summary>
        /// Returns the Image on the given position of the structure layer the player is currently in
        /// Note: null values get the "blank" image ; GetScreenImage skips if the value is null
        /// </summary>
        public static Image GetPlayerStructureImage(int row, int col) {
            ISuperLayerContext superLayer = MI.Player.CurrSuperLayer;
            Image img = new Image("blank", IconSize.Dnd );

            if (IsInsideBoundaries(row, col) &&
                superLayer.GetStructureLayerStock(row, col) != null) 
            {
                img = new Image(superLayer.GetStructureLayerStock(row, col), IconSize.Dnd);
            }
            return img;
        }

        // Checks if the position is inside the map
        private static bool IsInsideBoundaries(int row, int col) {
            return row >= 0 && col >= 0 && col < (int)Values.CurrMapSize && row < (int)Values.CurrMapSize;
        }

        /// <summary>
        /// Returns the Image on the given position of the player's hotbar (Incentory.Hotbar)
        /// Note: null values get the "blank" image
        /// </summary>
        public static Image GetPlayerHotbarImage(int index) {
            Image img = new Image("blank", IconSize.Dnd);

            if (index < MI.Player.Inventory.Hotbar.Length) {
                if (MI.Player.Inventory.Hotbar[index] != null) {
                    // Structures have two icons, one when they are placed and one as an inventory item.
                    // All other item types have only one icon (texture).
                    if (MI.Player.Inventory.Hotbar[index].GetType() == typeof(Structure)) {
                        Structure tmp = (Structure)MI.Player.Inventory.Hotbar[index];
                        img = new Image(tmp.inventory_stock_id, IconSize.Dnd);
                    }
                    else {
                        img = MI.Player.Inventory.Hotbar[index].Texture;
                    }
                }
            }
            return img;
        }

        /// <summary>
        /// Returns the Image on the given position of the player's items inventory (Inventory.Items)
        /// Note: null values get the "blank" image
        /// </summary>
        public static Image GetPlayerInventoryItemImage(int index) {
            Image img = new Image("blank", IconSize.Dnd);

            if (index < MI.Player.Inventory.Items.Length) {
                if (MI.Player.Inventory.Items[index] != null) {
                    // Structures have two icons, one when they are placed and one as an inventory item.
                    // All other item types have only one icon (texture).
                    if (MI.Player.Inventory.Items[index].GetType() == typeof(Structure)) {
                        Structure tmp = (Structure)MI.Player.Inventory.Items[index];
                        img = new Image(tmp.inventory_stock_id, IconSize.Dnd);
                    }
                    else {
                        img = MI.Player.Inventory.Items[index].Texture;
                    }
                }
            }
            return img;
        }

        /// <summary>
        /// Returns the Image on the given position of the player's accessories (Inventory.Accessories)
        /// Note: null values get the "blank" image
        /// </summary>
        public static Image GetPlayerAccessoryImage(int index) {
            Image img = new Image("blank_gear", IconSize.Dnd);

            if (index < MI.Player.Inventory.Accessories.Length) {
                if (MI.Player.Inventory.Accessories[index] != null) {
                    img = MI.Player.Inventory.Accessories[index].Texture;
                }
            }
            return img;
        }

        /// <summary>
        /// Returns the Image on the given position of the player's gear (Inventory.Gear)
        /// Note: null values get the "blank" image
        /// </summary>
        public static Image GetPlayerGearImage(int index) {
            Image img = new Image("blank_gear", IconSize.Dnd);

            if (index < MI.Player.Inventory.Gear.Length) {
                if (MI.Player.Inventory.Gear[index] != null) {
                    img = MI.Player.Inventory.Gear[index].Texture;
                }
            }
            return img;
        }
    }
}
