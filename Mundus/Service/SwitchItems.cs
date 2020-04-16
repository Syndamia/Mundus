using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.Windows;
using Mundus.Service.Tiles;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service {
    public static class SwitchItems {
        private static ItemTile[] origin = null;
        private static int oIndex = -1;

        public static void SetOrigin(string originName, int originIndex) {
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

        public static void ReplaceItems(string destination, int destinationIndex) {
            ItemTile[] destinationLocation = null;

            switch (destination.ToLower()) {
                case "hotbar": destinationLocation = MI.Player.Inventory.Hotbar; break;
                case "items": destinationLocation = MI.Player.Inventory.Items; break;
                case "accessories": destinationLocation = MI.Player.Inventory.Accessories; break;
                case "gear": destinationLocation = MI.Player.Inventory.Gear; break;
            }

            var toTransfer = origin[oIndex];

            if (toTransfer != null) {
                // Certain item types can only be placed inside certain inventory places.
                if (((toTransfer.GetType() == typeof(Tool) || toTransfer.GetType() == typeof(GroundTile)) && (destination == "hotbar" || destination == "items")) ||
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
    }
}
