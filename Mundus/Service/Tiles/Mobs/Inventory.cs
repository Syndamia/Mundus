﻿using Mundus.Service.Tiles.Items;
using Mundus.Service.Tiles.Items.Types;
using System;
using System.Linq;

namespace Mundus.Service.Tiles.Mobs {
    public class Inventory {
        public enum InventoryPlace {
            Hotbar,
            Items,
            Accessories,
            Gear
        }

        /// <summary>
        /// Has a size of "Screen and Inventory" and can hold Tools, Materials, Structures and Gear
        /// </summary>
        public ItemTile[] Hotbar { get; set; }
        /// <summary>
        /// Has a size of the "Screen and Inventory" squared and can hold Tools, Materials, Structures and Gear
        /// </summary>
        public ItemTile[] Items { get; set; }
        /// <summary>
        /// Has a size of double the "Screen and Inventory" and can only hold Gear
        /// </summary>
        public Gear[] Accessories { get; set; }
        /// <summary>
        /// Has a size of "Screen and Inventory" and can only hold Gear
        /// </summary>
        public Gear[] Gear { get; set; }

        public Inventory(int screenInvSize) {
            this.SetSizes(screenInvSize);
        }

        public void SetSizes(int screenInvSize) {
            this.Hotbar = new ItemTile[screenInvSize];
            this.Items = new ItemTile[screenInvSize * screenInvSize];
            this.Accessories = new Gear[screenInvSize * 2];
            this.Gear = new Gear[screenInvSize];
        }

        public void AppendToHotbar(ItemTile itemTile) {
            this.AddToHotbar(itemTile, Array.IndexOf(this.Hotbar, this.Hotbar.First(x => x == null)));
        }

        public void AddToHotbar(ItemTile itemTile, int index) {
            this.Hotbar[index] = itemTile;
        }

        public void DeleteFromHotbar(int index) {
            this.Hotbar[index] = null;
        }

        public void AppendToItems(ItemTile itemTile) {
            this.AddToItems(itemTile, Array.IndexOf(this.Items, this.Items.First(x => x == null)));
        }

        public void AddToItems(ItemTile itemTile, int index) {
            this.Items[index] = itemTile;
        }

        public void DeleteFromItems(int index) {
            this.Items[index] = null;
        }

        public void EquipAccessory(Gear accessory, int index) {
            this.Accessories[index] = accessory;
        }

        public void AppendAccessories(Gear accessory) {
            this.EquipAccessory(accessory, Array.IndexOf(this.Accessories, this.Accessories.First(x => x == null)));
        }

        public void DeleteAccessory(int index) {
            this.Accessories[index] = null;
        }

        public void EquipGear(Gear gear, int index) {
            this.Gear[index] = gear;
        }

        public void AppendGear(Gear gear) {
            this.EquipGear(gear, Array.IndexOf(this.Gear, this.Gear.First(x => x == null)));
        }

        public void DeleteGear(int index) {
            this.Gear[index] = null;
        }

        /// <summary>
        /// Returns an ItemTile depending on specified place ("hotbar", "items", "accessories" or "gear")
        /// and specified index
        /// </summary>
        public ItemTile GetItemTile(InventoryPlace place, int index) {
            ItemTile toReturn = null;

            switch (place) {
                case InventoryPlace.Hotbar: toReturn = this.Hotbar[index]; break;
                case InventoryPlace.Items: toReturn = this.Items[index]; break;
                case InventoryPlace.Accessories: toReturn = this.Accessories[index]; break;
                case InventoryPlace.Gear: toReturn = this.Gear[index]; break;
            }
            return toReturn;
        }

        /// <summary>
        /// Deletes an ItemTile depending on specified place ("hotbar", "items", "accessories" or "gear")
        /// and specified index
        /// </summary>
        public static void DeletePlayerItemTileFromItemSelection() {
            Data.Superlayers.Mobs.MI.Player.Inventory.DeleteItem(ItemController.SelItemPlace, ItemController.SelItemIndex);
        }

        /// <summary>
        /// Returns an ItemTile depending on specified place ("hotbar", "items", "accessories" or "gear")
        /// and specified index in player's inventory
        /// </summary>
        public static ItemTile GetPlayerItemFromItemSelection() {
            return Data.Superlayers.Mobs.MI.Player.Inventory.GetItemTile(ItemController.SelItemPlace, ItemController.SelItemIndex);
        }

        public void DeleteItem(InventoryPlace place, int index) {
            switch (place) {
                case InventoryPlace.Hotbar: this.Hotbar[index] = null; break;
                case InventoryPlace.Items: this.Items[index] = null; break;
                case InventoryPlace.Accessories: this.Accessories[index] = null; break;
                case InventoryPlace.Gear: this.Gear[index] = null; break;
            }
        }
    }
}
