using Mundus.Service.Tiles.Items;
using System;
using System.Linq;

namespace Mundus.Service {
    public class Inventory {
        public ItemTile[] Hotbar { get; set; }
        public ItemTile[] Items { get; set; }
        public Gear[] Accessories { get; set; }
        public Gear[] Gear { get; set; }

        public Inventory(int screenInvSize) {
            this.SetNewSizes(screenInvSize);
        }

        public void SetNewSizes(int screenInvSize) {
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

        public ItemTile GetTile(string place, int index) {
            ItemTile toReturn = null;

            switch (place.ToLower()) {
                case "hotbar": toReturn = this.Hotbar[index]; break;
                case "items": toReturn = this.Items[index]; break;
                case "accessories": toReturn = this.Accessories[index]; break;
                case "gear": toReturn = this.Gear[index]; break;
            }
            return toReturn;
        }

        public static ItemTile GetPlayerItem(string place, int index) {
            return Data.Superlayers.Mobs.LMI.Player.Inventory.GetTile(place, index);
        }
    }
}
