﻿using Mundus.Data.SuperLayers;
using Mundus.Service.Mobs.LandMobs;
using Mundus.Service.Tiles.ItemPresets;

namespace Mundus.Data.Superlayers.Mobs {
    public static class MI { //stands for Mob Instances
        public static Player Player { get; private set; }

        /// <summary>
        /// Creates the instances of the universally accessed mobs.
        /// Note: player has a health of 4 * inventorySize
        /// </summary>
        public static void CreateInstances(int inventorySize) {
            Player = new Player("player", 4 * inventorySize, LI.Land, inventorySize);
            Player.Inventory.AppendToHotbar(ToolPresets.GetAWoodenAxe());
            Player.Inventory.AppendToHotbar(ToolPresets.GetAWoodenPickaxe());
        }
    }
}
