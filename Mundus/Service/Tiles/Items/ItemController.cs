using System;
using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.Windows;
using Mundus.Service.Tiles.Items.Types;
using static Mundus.Data.Values;
using static Mundus.Service.Tiles.Mobs.Inventory;

namespace Mundus.Service.Tiles.Items {
    public static class ItemController {
        private static ItemTile[] selItemLocation;
        public static int SelItemIndex { get; private set; }

        public static InventoryPlace SelItemPlace { get; private set; }

        /// <summary>
        /// Sets the item that will be moved (switched)
        /// </summary>
        public static void SelectItem(InventoryPlace place, int index) {
            SelItemPlace = place;
            selItemLocation = GetInventoryArray(place);
            SelItemIndex = index;

            WI.SelWin.PrintSelectedItemInfo(selItemLocation[SelItemIndex]);
        }

        /// <summary>
        /// Tries to switch the location of the originally selected item (origin) with the currently selected item 
        /// </summary>
        public static void SwitchItems(InventoryPlace destination, int index) {
            ItemTile[] destinationLocation = GetInventoryArray(destination);
            ItemTile toTransfer = selItemLocation[SelItemIndex];

            if (toTransfer != null) {
                // Consumable materials can be consumed by double clicking on them (transfering them to their current location)
                if (toTransfer == destinationLocation[index]) {
                    if (toTransfer.GetType() == typeof(Material) &&
                        PlayerTryEat((Material)toTransfer)) {
                        selItemLocation[SelItemIndex] = null;
                    }
                }
                else if (ItemCanGoThere(toTransfer, destination)) {
                    selItemLocation[SelItemIndex] = destinationLocation[index];
                    destinationLocation[index] = toTransfer;
                }
            }

            ResetSelection();
        }

        public static void ResetSelection() {
            selItemLocation = null;
            SelItemIndex = -1;

            SelItemPlace = 0;
        }

        // Certain item types can only be placed inside certain inventory places.
        private static ItemTile[] GetInventoryArray(InventoryPlace place) {
            switch (place) {
                case InventoryPlace.Hotbar: return MI.Player.Inventory.Hotbar;
                case InventoryPlace.Items: return MI.Player.Inventory.Items;
                case InventoryPlace.Accessories: return MI.Player.Inventory.Accessories;
                case InventoryPlace.Gear: return MI.Player.Inventory.Gear;
                default: throw new System.ArgumentException($"Destination of itemtile must be either \"hotbar\", \"items\", \"accessories\" or \"gear\", not {place}");
            }
        }

        private static bool ItemCanGoThere(ItemTile toTransfer, InventoryPlace place) {
            switch (place) {
                case InventoryPlace.Hotbar: return toTransfer.GetType() != typeof(GroundTile);
                case InventoryPlace.Items: return true;
                case InventoryPlace.Accessories: return toTransfer.GetType() == typeof(Gear);
                case InventoryPlace.Gear: return toTransfer.GetType() == typeof(Gear);
                default: throw new System.ArgumentException($"Destination of itemtile {toTransfer.stock_id} must be either \"hotbar\", \"items\", \"accessories\" or \"gear\", not {place}");
            }
        }

        public static bool HasSelectedItem() {
            return selItemLocation != null && SelItemIndex != -1;
        }

        private static bool PlayerTryEat(Material material) {
            if (material.EnergyRestorePoints > 0) {
                MI.Player.RestoreEnergy(material.EnergyRestorePoints);
                return true;
            }
            return false;
        }
    }
}
