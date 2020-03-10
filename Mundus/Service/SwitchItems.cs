using Mundus.Data.Superlayers.Mobs;
using Mundus.Service.Tiles;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service {
    public static class SwitchItems {
        private static string originType = null;
        private static ItemTile[] origin = null;
        private static int oIndex = -1;

        public static void SetOrigin(string originName, int originIndex) {
            ItemTile[] newOrigin = null;

            switch (originName.ToLower()) {
                case "hand": newOrigin = new ItemTile[] { LMI.Player.Inventory.Hand }; break;
                case "hotbar": newOrigin = LMI.Player.Inventory.Hotbar; break;
                case "items": newOrigin = LMI.Player.Inventory.Items; break;
                case "accessories": newOrigin = LMI.Player.Inventory.Accessories; break;
                case "gear": newOrigin = LMI.Player.Inventory.Gear; break;
            }
            SetOrigin(originName, newOrigin, originIndex);
        }

        private static void SetOrigin(string newOriginType, ItemTile[] newOrigin, int originIndex) {
            originType = newOriginType;
            origin = newOrigin;
            oIndex = originIndex;
        }

        public static void ReplaceItems(string destination, int destinationIndex) {
            if (destination == originType) {
                ItemTile[] destinationLocation = null;

                switch (destination.ToLower()) {
                    case "hand": destinationLocation = new ItemTile[] { LMI.Player.Inventory.Hand }; break;
                    case "hotbar": destinationLocation = LMI.Player.Inventory.Hotbar; break;
                    case "items": destinationLocation = LMI.Player.Inventory.Items; break;
                    case "accessories": destinationLocation = LMI.Player.Inventory.Accessories; break;
                    case "gear": destinationLocation = LMI.Player.Inventory.Gear; break;
                }
                ReplaceItems(destinationLocation, destinationIndex);
            }
            else {
                Reset();
            }
        }

        public static void ReplaceItems(ItemTile[] destination, int destinationIndex) {
            if (origin[0].GetType() == destination[0].GetType()) {
                var toTransfer = origin[oIndex];
                origin[oIndex] = destination[destinationIndex];
                destination[destinationIndex] = toTransfer;
            }

            Reset();
        }

        private static void Reset() {
            originType = null;
            origin = null;
            oIndex = -1;
        }

        public static bool HasOrigin() {
            return origin != null && oIndex != -1;
        }
    }
}
