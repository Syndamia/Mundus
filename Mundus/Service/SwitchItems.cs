using Mundus.Data.Superlayers.Mobs;
using Mundus.Service.Tiles;
using Mundus.Service.Tiles.Items;

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

        private static void SetOrigin(ItemTile[] newOrigin, int originIndex) {
            origin = newOrigin;
            oIndex = originIndex;
        }

        public static void ReplaceItems(string destination, int destinationIndex) {
            ItemTile[] destinationLocation = null;

            switch (destination.ToLower()) {
                case "hotbar": destinationLocation = LMI.Player.Inventory.Hotbar; break;
                case "items": destinationLocation = LMI.Player.Inventory.Items; break;
                case "accessories": destinationLocation = LMI.Player.Inventory.Accessories; break;
                case "gear": destinationLocation = LMI.Player.Inventory.Gear; break;
            }

            var toTransfer = origin[oIndex];

            if (toTransfer != null) {
                if ((toTransfer.GetType() == typeof(Tool) && (destination == "hotbar" || destination == "items")) ||
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
