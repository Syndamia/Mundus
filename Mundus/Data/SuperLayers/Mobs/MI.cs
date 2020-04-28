using Mundus.Data.SuperLayers;
using Mundus.Service.Mobs.LandMobs;
using Mundus.Service.Tiles.ItemPresets;

namespace Mundus.Data.Superlayers.Mobs {
    public static class MI { //stands for Land Mob Instances
        public static Player Player { get; private set; }

        public static void CreateInstances(int inventorySize) {
            Player = new Player("player", 20, LI.Land, inventorySize);
        }

        public static void CreateInventories(int screenInvSize) {
            Player.Inventory.SetNewSizes(screenInvSize);
            Player.Inventory.AppendToHotbar(ToolPresets.GetAWoodenAxe());
            Player.Inventory.AppendToHotbar(ToolPresets.GetAWoodenPickaxe());
        }
    }
}
