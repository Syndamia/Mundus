namespace Mundus.Service.Tiles.Mobs 
{
    using System;
    using System.Linq;
    using Mundus.Data.Tiles.Mobs;
    using Mundus.Service.Tiles.Items;
    using Mundus.Service.Tiles.Items.Types;

    public class Inventory 
    {
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

        public Inventory(int screenInvSize) 
        {
            this.SetSizes(screenInvSize);
        }

        public enum InventoryPlace 
        {
            Hotbar,
            Items,
            Accessories,
            Gear
        }

        public void AppendToHotbar(ItemTile itemTile) 
        {
            this.AddToHotbar(itemTile, Array.IndexOf(this.Hotbar, this.Hotbar.First(x => x == null)));
        }

        public void AddToHotbar(ItemTile itemTile, int index) 
        {
            this.Hotbar[index] = itemTile;
        }

        public void DeleteFromHotbar(int index) 
        {
            this.Hotbar[index] = null;
        }

        public void AppendToItems(ItemTile itemTile) 
        {
            this.AddToItems(itemTile, Array.IndexOf(this.Items, this.Items.First(x => x == null)));
        }

        public void AddToItems(ItemTile itemTile, int index) 
        {
            this.Items[index] = itemTile;
        }

        public void DeleteFromItems(int index) 
        {
            this.Items[index] = null;
        }

        public void AddToAccessories(Gear accessory, int index) 
        {
            this.Accessories[index] = accessory;
        }

        public void AppendToAccessories(Gear accessory) 
        {
            this.AddToAccessories(accessory, Array.IndexOf(this.Accessories, this.Accessories.First(x => x == null)));
        }

        public void DeleteFromAccessories(int index) 
        {
            this.Accessories[index] = null;
        }

        public void AddToGear(Gear gear, int index) 
        {
            this.Gear[index] = gear;
        }

        public void AppendToGear(Gear gear) 
        {
            this.AddToGear(gear, Array.IndexOf(this.Gear, this.Gear.First(x => x == null)));
        }

        public void DeleteFromGear(int index) 
        {
            this.Gear[index] = null;
        }

        /// <summary>
        /// Returns an ItemTile depending on specified place ("hotbar", "items", "accessories" or "gear")
        /// and specified index
        /// </summary>
        public ItemTile GetItemTile(InventoryPlace place, int index) 
        {
            ItemTile toReturn = null;

            switch (place) 
            {
                case InventoryPlace.Hotbar: toReturn = this.Hotbar[index]; break;
                case InventoryPlace.Items: toReturn = this.Items[index]; break;
                case InventoryPlace.Accessories: toReturn = this.Accessories[index]; break;
                case InventoryPlace.Gear: toReturn = this.Gear[index]; break;
            }

            return toReturn;
        }

        public void DeleteItem(InventoryPlace place, int index) 
        {
            switch (place) 
            {
                case InventoryPlace.Hotbar: this.Hotbar[index] = null; break;
                case InventoryPlace.Items: this.Items[index] = null; break;
                case InventoryPlace.Accessories: this.Accessories[index] = null; break;
                case InventoryPlace.Gear: this.Gear[index] = null; break;
            }
        }

        /// <summary>
        /// Deletes an ItemTile depending on specified place ("hotbar", "items", "accessories" or "gear")
        /// and specified index
        /// </summary>
        public static void DeletePlayerItemTileFromItemSelection() 
        {
            MI.Player.Inventory.DeleteItem(ItemController.SelItemPlace, ItemController.SelItemIndex);
        }

        /// <summary>
        /// Returns an ItemTile depending on specified place ("hotbar", "items", "accessories" or "gear")
        /// and specified index in player's inventory
        /// </summary>
        public static ItemTile GetPlayerItemFromItemSelection() 
        {
            return MI.Player.Inventory.GetItemTile(ItemController.SelItemPlace, ItemController.SelItemIndex);
        }

        private void SetSizes(int screenInvSize) 
        {
            this.Hotbar = new ItemTile[screenInvSize];
            this.Items = new ItemTile[screenInvSize * screenInvSize];
            this.Accessories = new Gear[screenInvSize * 2];
            this.Gear = new Gear[screenInvSize];
        }
    }
}