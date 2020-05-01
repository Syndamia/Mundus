using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.Windows;

namespace Mundus.Service.Tiles.Items {
    public static class SwitchItems {
        private static ItemTile[] origin = null;
        private static int oIndex = -1;

        /// <summary>
        /// Sets the item that will be moved (switched)
        /// </summary>
        /// <param name="originName">Name of the inventory location of the item ("hotbar", "items", "accessories" or "gear")</param>
        /// <param name="originIndex">Index of the inventory location of the item</param>
        public static void SetOrigin(string originName, int originIndex) {
            // This method overload only extracts the inventory location as an array
            ItemTile[] newOrigin = null;

            switch (originName.ToLower()) {
                case "hotbar": newOrigin = MI.Player.Inventory.Hotbar; break;
                case "items": newOrigin = MI.Player.Inventory.Items; break;
                case "accessories": newOrigin = MI.Player.Inventory.Accessories; break;
                case "gear": newOrigin = MI.Player.Inventory.Gear; break;
            }
            SetOrigin(newOrigin, originIndex);
        }

        private static void SetOrigin(ItemTile[] newOrigin, int originIndex) {
            origin = newOrigin;
            oIndex = originIndex;
            WI.SelWin.PrintSelectedItemInfo(newOrigin[originIndex]);
        }

        /// <summary>
        /// Tries to switch the location of the originally selected item (origin) with the currently selected item 
        /// </summary>
        /// <param name="destination">Name of the inventory location of the currently selected item ("hotbar", "items", "accessories" or "gear")</param>
        /// <param name="destinationIndex">Index of the inventory location of the currently selected item</param>
        public static void ReplaceItems(string destination, int destinationIndex) {
            ItemTile[] destinationLocation = null;

            switch (destination.ToLower()) {
                case "hotbar": destinationLocation = MI.Player.Inventory.Hotbar; break;
                case "items": destinationLocation = MI.Player.Inventory.Items; break;
                case "accessories": destinationLocation = MI.Player.Inventory.Accessories; break;
                case "gear": destinationLocation = MI.Player.Inventory.Gear; break;
            }

            ItemTile toTransfer = origin[oIndex];

            if (toTransfer != null) {
                if (toTransfer == destinationLocation[destinationIndex]) {
                    if (toTransfer.GetType() == typeof(Material) &&
                        PlayerTryEat((Material)toTransfer)) {
                        origin[oIndex] = null;
                    }
                }
                // Certain item types can only be placed inside certain inventory places.
                else if (((toTransfer.GetType() == typeof(Tool) || toTransfer.GetType() == typeof(GroundTile)) && (destination == "hotbar" || destination == "items")) ||
                    ((toTransfer.GetType() == typeof(Material) || toTransfer.GetType() == typeof(Structure)) && (destination == "hotbar" || destination == "items")) ||
                    (toTransfer.GetType() == typeof(Gear) && (destination == "hotbar" || destination == "items" || destination == "accessories" || destination == "gear"))) {

                    origin[oIndex] = destinationLocation[destinationIndex];
                    destinationLocation[destinationIndex] = toTransfer;
                }
            }

            origin = null;
            oIndex = -1;
        }

        public static bool HasOrigin() {
            return origin != null && oIndex != -1;
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
