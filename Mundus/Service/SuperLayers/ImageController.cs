using Gtk;
using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.SuperLayers;

namespace Mundus.Service.SuperLayers {
    public static class ImageController {
        //Set the image to be either the ground layer tile, "blank" icon, item layer tile, mob layer tile or don't set it to anything 
        //Note: first the ground and the blank icons are printed, then over them are printed the item tiles and over them are mob tiles
        public static Image GetScreenImage(int row, int col, int layer) {
            ISuperLayer superLayer = LMI.Player.CurrSuperLayer;
            Image img = null;

            //Layer 0 is GroundLayer, 1 is ItemLayer and 2 is Moblayer
            if (layer == 0) {
                if (superLayer.GetGroundLayerTile( row, col ) == null) {
                    img = new Image( "blank", IconSize.Dnd );
                }
                else {
                    img = new Image( superLayer.GetGroundLayerTile( row, col ).stock_id, IconSize.Dnd );
                }
            }
            else if (layer == 1 &&
                     superLayer.GetStructureLayerTile( row, col ) != null) {
                img = new Image( superLayer.GetStructureLayerTile( row, col ).stock_id, IconSize.Dnd );
            }
            else if (layer == 2 &&
                     superLayer.GetMobLayerTile( row, col ) != null) {
                img = new Image( superLayer.GetMobLayerTile( row, col ).stock_id, IconSize.Dnd );
            }
            return img;
        }

        //Return a tile if it exists, otherwise return the "blank" icon
        public static Image GetGroundImage(int row, int col) {
            ISuperLayer superLayer = LMI.Player.CurrSuperLayer;
            Image img = new Image("blank", IconSize.Dnd);

            if (row >= 0 && col >= 0 && col < MapSizes.CurrSize && row < MapSizes.CurrSize &&
                superLayer.GetGroundLayerTile( row, col ) != null) {
                img = superLayer.GetGroundLayerTile( row, col ).Texture;
            }
            return img;
        }

        //Return a tile if it exists, otherwise return the "blank" icon
        public static Image GetItemImage(int row, int col) {
            ISuperLayer superLayer = LMI.Player.CurrSuperLayer;
            Image img = new Image( "blank", IconSize.Dnd );

            if (row >= 0 && col >= 0 && col < MapSizes.CurrSize && row < MapSizes.CurrSize &&
                superLayer.GetStructureLayerTile( row, col ) != null) {
                img = superLayer.GetStructureLayerTile( row, col ).Texture;
            }
            return img;
        }

        public static Image GetHotbarImage(int index) {
            Image img = new Image("blank", IconSize.Dnd);

            if (index < LMI.Player.Inventory.Hotbar.Length) {
                if (LMI.Player.Inventory.Hotbar[index] != null) {
                    img = LMI.Player.Inventory.Hotbar[index].Texture;
                }
            }
            return img;
        }

        public static Image GetInventoryItemImage(int index) {
            Image img = new Image("blank", IconSize.Dnd);
            if (index < LMI.Player.Inventory.Items.Length) {
                if (LMI.Player.Inventory.Items[index] != null) {
                    img = LMI.Player.Inventory.Items[index].Texture;
                }
            }
            return img;
        }

        public static Image GetAccessoryImage(int index) {
            Image img = new Image("blank_gear", IconSize.Dnd);
            if (index < LMI.Player.Inventory.Accessories.Length) {
                if (LMI.Player.Inventory.Accessories[index] != null) {
                    img = LMI.Player.Inventory.Accessories[index].Texture;
                }
            }
            return img;
        }

        public static Image GetGearImage(int index) {
            Image img = new Image("blank_gear", IconSize.Dnd);
            if (index < LMI.Player.Inventory.Gear.Length) {
                if (LMI.Player.Inventory.Gear[index] != null) {
                    img = LMI.Player.Inventory.Gear[index].Texture;
                }
            }
            return img;
        }
    }
}
