using Mundus.Service.Tiles.Items;
using System;
using System.Linq;

namespace Mundus.Service {
    public class Inventory {
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
        public ItemTile GetItemTile(string place, int index) {
            ItemTile toReturn = null;

            switch (place.ToLower()) {
                case "hotbar": toReturn = this.Hotbar[index]; break;
                case "items": toReturn = this.Items[index]; break;
                case "accessories": toReturn = this.Accessories[index]; break;
                case "gear": toReturn = this.Gear[index]; break;
            }
            return toReturn;
        }

        /// <summary>
        /// Deletes an ItemTile depending on specified place ("hotbar", "items", "accessories" or "gear")
        /// and specified index
        /// </summary>
        public void DeleteItemTile(string place, int index) {
            switch (place.ToLower()) {
                case "hotbar": this.Hotbar[index] = null; break;
                case "items": this.Items[index] = null; break;
                case "accessories": this.Accessories[index] = null; break;
                case "gear": this.Gear[index] = null; break;
            }
        }

        /// <summary>
        /// Returns an ItemTile depending on specified place ("hotbar", "items", "accessories" or "gear")
        /// and specified index in player's inventory
        /// </summary>
        public static ItemTile GetPlayerItem(string place, int index) {
            return Data.Superlayers.Mobs.MI.Player.Inventory.GetItemTile(place, index);
        }
    }
}
