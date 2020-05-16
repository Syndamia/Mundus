namespace Mundus.Service.Tiles.Items 
{
    using Mundus.Data.Tiles.Mobs;
    using Mundus.Data.Windows;
    using Mundus.Service.Tiles.Items.Types;
    using static Mundus.Service.Tiles.Mobs.Inventory;

    /// <summary>
    /// Contains the item that the player has selected and switches it's location
    /// </summary>
    public static class ItemController 
    {
        private static ItemTile[] selItemLocation;

        /// <summary>
        /// Gets the index of the selected item in the selected item location
        /// </summary>
        public static int SelItemIndex { get; private set; }

        /// <summary>
        /// Gets the inventory place in which the selected item is stored
        /// </summary>
        public static InventoryPlace SelItemPlace { get; private set; }

        /// <summary>
        /// Sets the item that will be moved (switched)
        /// </summary>
        public static void SelectItem(InventoryPlace place, int index) 
        {
            selItemLocation = GetPlayerInventoryArray(place);

            SelItemPlace = place;
            SelItemIndex = index;

            WI.SelWin.PrintSelectedItemInfo(selItemLocation[SelItemIndex]);
        }

        /// <summary>
        /// Tries to switch the location of the selected item with the given one
        /// If a material is moved to it's current location (double clicked), and 
        /// it can restore energy, it restores the player's energy
        /// </summary>
        public static void SwitchItems(InventoryPlace destination, int index) 
        {
            ItemTile[] destinationLocation = GetPlayerInventoryArray(destination);
            ItemTile toTransfer = selItemLocation[SelItemIndex];

            if (toTransfer != null) 
            {
                // Consumable materials can be consumed by double clicking on them (transfering them to their current location)
                if (toTransfer == destinationLocation[index]) 
                {
                    if (toTransfer.GetType() == typeof(Material) && PlayerDidEat((Material)toTransfer)) 
                    {
                        selItemLocation[SelItemIndex] = null;
                    }
                }
                else if (ItemCanGoThere(toTransfer, destination)) 
                {
                    selItemLocation[SelItemIndex] = destinationLocation[index];
                    destinationLocation[index] = toTransfer;
                }
            }

            ResetSelection();
        }

        /// <summary>
        /// Sets the selected item place and index to invalid values
        /// </summary>
        public static void ResetSelection() 
        {
            selItemLocation = null;

            SelItemIndex = -1;
            SelItemPlace = 0;
        }

        /// <summary>
        /// Returns whether an item has been selected
        /// </summary>
        public static bool HasSelectedItem() 
        {
            return selItemLocation != null && SelItemIndex > -1;
        }

        /// <summary>
        /// Returns an ItemTile array, corresponding to a given place inside the player's inventory
        /// </summary>
        private static ItemTile[] GetPlayerInventoryArray(InventoryPlace place) 
        {
            switch (place) 
            {
                case InventoryPlace.Hotbar: return MI.Player.Inventory.Hotbar;
                case InventoryPlace.Items: return MI.Player.Inventory.Items;
                case InventoryPlace.Accessories: return MI.Player.Inventory.Accessories;
                case InventoryPlace.Gear: return MI.Player.Inventory.Gear;
                default: throw new System.ArgumentException($"Destination of itemtile must be either \"hotbar\", \"items\", \"accessories\" or \"gear\", not {place}");
            }
        }

        /// <summary>
        /// Checks if the given ItemTile can be inside the given destination
        /// </summary>
        private static bool ItemCanGoThere(ItemTile toTransfer, InventoryPlace place) 
        {
            switch (place) 
            {
                case InventoryPlace.Hotbar: return toTransfer.GetType() != typeof(GroundTile);
                case InventoryPlace.Items: return true;
                case InventoryPlace.Accessories: return toTransfer.GetType() == typeof(Gear);
                case InventoryPlace.Gear: return toTransfer.GetType() == typeof(Gear);
                default: throw new System.ArgumentException($"Destination of itemtile {toTransfer.stock_id} must be either \"hotbar\", \"items\", \"accessories\" or \"gear\", not {place}");
            }
        }

        /// <summary>
        /// If the given material can restore energy, it restores that player's energy and returns true
        /// </summary>
        private static bool PlayerDidEat(Material material) 
        {
            if (material.EnergyRestorePoints > 0) 
            {
                MI.Player.RestoreEnergy(material.EnergyRestorePoints);

                return true;
            }

            return false;
        }
    }
}
