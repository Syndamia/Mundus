using Mundus.Service.Mobs.LandMobs;

namespace Mundus.Data.Superlayers.Mobs {
    public static class LMI { //stands for Land Mob Instances
        public static Player Player { get; private set; }

        public static void CreateInstances(int inventorySize) {
            Player = new Player("player", inventorySize);
        }

        public static void CreateInventories(int screenInvSize) {
            Player.Inventory.SetNewSizes(screenInvSize);
        }
    }
}
