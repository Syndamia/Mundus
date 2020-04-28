using Gtk;
using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.SuperLayers {
    public static class ImageController {
        //Set the image to be either the ground layer tile, "blank" icon, item layer tile, mob layer tile or don't set it to anything 
        //Note: first the ground and the blank icons are printed, then over them are printed the item tiles and over them are mob tiles
        public static Image GetScreenImage(int row, int col, int layer) {
            ISuperLayer superLayer = MI.Player.CurrSuperLayer;
            Image img = null;

            //Layer 0 is GroundLayer, 1 is ItemLayer and 2 is Moblayer
            if (layer == 0) 
            {
                img = new Image(GetGroundImage(row, col).Stock, IconSize.Dnd);
            }
            else if (layer == 1 &&
                     superLayer.GetStructureLayerTile( row, col ) != null) 
            {
                img = new Image(GetStructureImage(row, col).Stock, IconSize.Dnd );
            }
            else if (layer == 2 &&
                     superLayer.GetMobLayerTile(row, col) != null) 
            {
                img = new Image(superLayer.GetMobLayerTile(row, col).stock_id, IconSize.Dnd);
            }
            return img;
        }


        public static Image GetGroundImage(int row, int col) {
            ISuperLayer superLayer = MI.Player.CurrSuperLayer;
            Image img = new Image("L_hole", IconSize.Dnd);

            if (row >= 0 && col >= 0 && col < MapSizes.CurrSize && row < MapSizes.CurrSize &&
                superLayer.GetGroundLayerTile(row, col) != null) {
                img = superLayer.GetGroundLayerTile( row, col ).Texture;
            }
            return img;
        }

        public static Image GetStructureImage(int row, int col) {
            ISuperLayer superLayer = MI.Player.CurrSuperLayer;
            Image img = new Image("blank", IconSize.Dnd );

            if (IsInsideBoundaries(row, col) &&
                superLayer.GetStructureLayerTile(row, col) != null) 
            {
                img = superLayer.GetStructureLayerTile(row, col).Texture;
            }
            return img;
        }

        private static bool IsInsideBoundaries(int row, int col) {
            return row >= 0 && col >= 0 && col < MapSizes.CurrSize && row < MapSizes.CurrSize;
        }

        public static Image GetHotbarImage(int index) {
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

        public static Image GetInventoryItemImage(int index) {
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

        public static Image GetAccessoryImage(int index) {
            Image img = new Image("blank_gear", IconSize.Dnd);

            if (index < MI.Player.Inventory.Accessories.Length) {
                if (MI.Player.Inventory.Accessories[index] != null) {
                    img = MI.Player.Inventory.Accessories[index].Texture;
                }
            }
            return img;
        }

        public static Image GetGearImage(int index) {
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
