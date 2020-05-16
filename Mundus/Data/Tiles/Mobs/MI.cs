namespace Mundus.Data.Tiles.Mobs
{
    using Mundus.Data.Tiles.Presets;
    using Mundus.Service.Tiles.Mobs.LandMobs;

    /// <summary>
    /// Used to store universally accessed mob instances (player)
    /// </summary>
    public static class MI 
    {
        /// <summary>
        /// Gets the mob that is used by the person who plays the game
        /// </summary>
        public static Player Player { get; private set; }

        /// <summary>
        /// Creates the instances of the universally accessed mobs.
        /// Note: player has a health of 4 * inventorySize and gets a wooden axe and a wooden pickaxe
        /// </summary>
        public static void CreateInstances() 
        {
            Player = new Player("player", 5, DataBaseContexts.LContext);
            Player.Inventory.AppendToHotbar(ToolPresets.GetAWoodenAxe());
            Player.Inventory.AppendToHotbar(ToolPresets.GetAWoodenPickaxe());
        }
    }
}
