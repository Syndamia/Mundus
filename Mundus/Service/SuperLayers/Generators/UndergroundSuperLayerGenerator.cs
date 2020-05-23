namespace Mundus.Service.SuperLayers.Generators 
{
    using System;
    using Mundus.Data;
    using Mundus.Data.SuperLayers;
    using Mundus.Service.Tiles.Items.Presets;
    using static Mundus.Data.Values;

    /// <summary>
    /// Generates all tiles in the Underground superlayer
    /// </summary>
    public static class UndergroundSuperLayerGenerator 
    {
        /// <summary>
        /// Variable that is used for random generation
        /// </summary>
        private static Random rnd;

        /// <summary>
        /// Underground context, it is used to add generated tiles to the database
        /// </summary>
        private static UndergroundContext context = DataBaseContexts.UContext;

        /// <summary>
        /// Generates ground, structure and mob layers for Underground superlayer
        /// </summary>
        /// <param name="mapSize">Size of ingame world/map</param>
        public static void GenerateAllLayers(MapSize mapSize) 
        {
            rnd = new Random();
            int size = (int)mapSize;

            GenerateMobLayer(size);
            GenerateGroundLayer(size);
            GenerateStructureLayer(size);
        }

        private static void GenerateMobLayer(int size) 
        {
            for (int col = 0; col < size; col++) 
            {
                for (int row = 0; row < size; row++) 
                {
                    context.AddMobAtPosition(null, -1, row, col);
                }
            }

            context.SaveChanges();
        }

        private static void GenerateGroundLayer(int size) 
        {
            for (int col = 0; col < size; col++) 
            {
                for (int row = 0; row < size; row++) 
                {
                    context.AddGroundAtPosition(GroundPresets.GetURoche().stock_id, row, col);
                }
            }

            context.SaveChanges();
        }

        private static void GenerateStructureLayer(int size) 
        {
            for (int col = 0; col < size; col++) 
            {
                for (int row = 0; row < size; row++) 
                {
                    if (context.GetGroundLayerStock(row, col) != null) 
                    {
                        if (rnd.Next(0, 10) == 1) 
                        {
                            context.AddStructureAtPosition(null, -1, row, col);
                        }
                        else 
                        {
                            context.AddStructureAtPosition(StructurePresets.GetURock().stock_id, StructurePresets.GetURock().Health, row, col);
                        }
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
