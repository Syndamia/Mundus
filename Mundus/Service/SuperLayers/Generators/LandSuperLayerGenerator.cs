namespace Mundus.Service.SuperLayers.Generators 
{
    using System;
    using Mundus.Data;
    using Mundus.Data.SuperLayers;
    using Mundus.Service.Tiles.Items.Presets;
    using Mundus.Service.Tiles.Mobs;
    using Mundus.Service.Tiles.Mobs.LandMobs;
    using static Mundus.Data.Values;

    /// <summary>
    /// Generates all tiles in the Land superlayer
    /// </summary>
    public static class LandSuperLayerGenerator 
    {
        /// <summary>
        /// Variable that is used for random generation
        /// </summary>
        private static Random rnd;

        /// <summary>
        /// Land context, it is used to add generated tiles to the database
        /// </summary>
        private static LandContext context = DataBaseContexts.LContext;

        /// <summary>
        /// Generates ground, structure and mob layers for Land superlayer
        /// </summary>
        /// <param name="mapSize">Size of ingame world/map</param>
        public static void GenerateAllLayers(MapSize mapSize) 
        {
            rnd = new Random();
            int size = (int)mapSize;

            GenerateGroundLayer(size);
            GenerateStructureLayer(size);
            GenerateMobLayer(size);
        }

        private static void GenerateGroundLayer(int size) 
        {
            for (int col = 0; col < size; col++) 
            {
                for (int row = 0; row < size; row++) 
                {
                    bool atPlayerSpawnPosition = (col == size / 2) && (row == size / 2);

                    // Holes in the ground should be more common with higher difficulties
                    if (rnd.Next(0, 210 - (int)CurrDifficulty) == 1 && !atPlayerSpawnPosition) 
                    {
                        context.AddGroundAtPosition(null, row, col);
                    }
                    else 
                    {
                        context.AddGroundAtPosition(GroundPresets.GetLGrass().stock_id, row, col);
                    }
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
                    bool atPlayerSpawnPosition = (col == size / 2) && (row == size / 2);

                    if (context.GetGroundLayerStock(row, col) != null && !atPlayerSpawnPosition) 
                    {
                        if (rnd.Next(0, 15 + (int)CurrDifficulty) == 1) 
                        {
                            context.AddStructureAtPosition(StructurePresets.GetLTree().stock_id, StructurePresets.GetLTree().Health, row, col);
                        }
                        else if (rnd.Next(0, 40 + (int)CurrDifficulty) == 1) 
                        {
                            context.AddStructureAtPosition(StructurePresets.GetLBoulder().stock_id, StructurePresets.GetLBoulder().Health, row, col);
                        }
                        else 
                        {
                            context.AddStructureAtPosition(null, -1, row, col);
                        }
                    }
                    else 
                    {
                        context.AddStructureAtPosition(null, -1, row, col);
                    }
                }
            }

            context.SaveChanges();
        }

        private static void GenerateMobLayer(int size) 
        {
            for (int col = 0; col < size; col++) 
            {
                for (int row = 0; row < size; row++) 
                {
                    bool atPlayerSpawnPosition = (col == size / 2) && (row == size / 2);

                    if (context.GetGroundLayerStock(row, col) != null &&
                        context.GetStructureLayerStock(row, col) == null) 
                    {
                        if (atPlayerSpawnPosition) 
                        {
                            MI.Player.YPos = row;
                            MI.Player.XPos = col;
                            context.AddMobAtPosition(MI.Player.stock_id, MI.Player.Health, row, col);
                        }
                        else if (rnd.Next(0, 15 + (int)CurrDifficulty) == 1) 
                        {
                            context.AddMobAtPosition(LandMobsPresets.GetCow().stock_id, LandMobsPresets.GetCow().Health, row, col);
                        }
                        else if (rnd.Next(0, 15 + (int)CurrDifficulty) == 1) 
                        {
                            context.AddMobAtPosition(LandMobsPresets.GetSheep().stock_id, LandMobsPresets.GetSheep().Health, row, col);
                        }
                        else 
                        {
                            context.AddMobAtPosition(null, -1, row, col);
                        }
                    }
                    else 
                    {
                        context.AddMobAtPosition(null, -1, row, col);
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
