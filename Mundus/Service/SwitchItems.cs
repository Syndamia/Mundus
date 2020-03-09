using Mundus.Data.Superlayers.Mobs;
using Mundus.Service.Tiles;

namespace Mundus.Service {
    public static class SwitchItems {
        private static ItemTile[] origin = null;
        private static int oIndex = -1;

        public static void SetOrigin(string originName, int originIndex) {
            ItemTile[] newOrigin = null;

            switch (originName.ToLower()) {
                case "hotbar": newOrigin = LMI.Player.Inventory.Hotbar; break;
                case "items": newOrigin = LMI.Player.Inventory.Items; break;
                case "accessories": newOrigin = LMI.Player.Inventory.Accessories; break;
                case "gear": newOrigin = LMI.Player.Inventory.Gear; break;
            }
            SetOrigin(newOrigin, originIndex);
        }

        public static void SetOrigin(ItemTile[] newOrigin, int originIndex) {
            origin = newOrigin;
            oIndex = originIndex;
        }

        public static void ReplaceItems(string destnation, int destinationIndex) {
            ItemTile[] destinationLocation = null;

            switch (destnation.ToLower()) {
                case "hotbar": destinationLocation = LMI.Player.Inventory.Hotbar; break;
                case "items": destinationLocation = LMI.Player.Inventory.Items; break;
                case "accessories": destinationLocation = LMI.Player.Inventory.Accessories; break;
                case "gear": destinationLocation = LMI.Player.Inventory.Gear; break;
            }
            ReplaceItems(destinationLocation, destinationIndex);
        }

        public static void ReplaceItems(ItemTile[] destination, int destinationIndex) {
            var toTransfer = origin[oIndex];
            origin[oIndex] = destination[destinationIndex];
            destination[destinationIndex] = toTransfer;

            origin = null;
            oIndex = -1;
        }

        public static bool HasOrigin() {
            return origin != null && oIndex != -1;
        }
    }
}
