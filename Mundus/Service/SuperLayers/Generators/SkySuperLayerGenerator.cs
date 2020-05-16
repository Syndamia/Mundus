namespace Mundus.Service.SuperLayers.Generators 
{
    using System;
    using Mundus.Data;
    using Mundus.Data.SuperLayers;
    using Mundus.Data.Tiles.Presets;
    using static Mundus.Data.Values;

    /// <summary>
    /// Generates all tiles in the Sky superlayer
    /// </summary>
    public static class SkySuperLayerGenerator 
    {
        /// <summary>
        /// Variable that is used for random generation
        /// </summary>
        private static Random rnd;

        /// <summary>
        /// Sky context, it is used to add generated tiles to the database
        /// </summary>
        private static SkyContext context = DataBaseContexts.SContext;

        /// <summary>
        /// Generates ground, structure and mob layers for Sky superlayer
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
                    context.AddGroundAtPosition(GroundPresets.GetSSky().stock_id, row, col);
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
                    context.AddStructureAtPosition(null, -1, row, col);
                }
            }

            context.SaveChanges();
        }
    }
}
