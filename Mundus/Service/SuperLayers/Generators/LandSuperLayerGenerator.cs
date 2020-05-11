using System;
using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles.Mobs.LandMobs;
using Mundus.Service.Tiles.Mobs;
using Mundus.Service.Tiles.Items.Presets;
using Mundus.Service.Tiles.Items;
using static Mundus.Data.Values;

namespace Mundus.Service.SuperLayers.Generators {
    public static class LandSuperLayerGenerator {
        private static Random rnd;
        private static LandContext context = DataBaseContexts.LContext;

        public static void GenerateAllLayers(MapSize mapSize) {
            rnd = new Random();
            int size = (int)mapSize;

            GenerateGroundLayer(size);
            GenerateStructureLayer(size);
            GenerateMobLayer(size);
        }

        private static void GenerateGroundLayer(int size) {
            for(int col = 0; col < size; col++) {
                for(int row = 0; row < size; row++) {
                    bool atPlayerSpawnPosition = (col == size / 2) && (row == size / 2);
                    // Holes in the ground should be more common with higher difficulties
                    if (rnd.Next(0, 210 - (int)CurrDifficulty) == 1 && !atPlayerSpawnPosition) {
                        context.AddGroundAtPosition(null, row, col);
                    }
                    else {
                        context.AddGroundAtPosition(GroundPresets.GetALGrass().stock_id, row, col);
                    }
                }
            }
            context.SaveChanges();
        }

        private static void GenerateStructureLayer(int size) {
            for (int col = 0; col < size; col++) {
                for (int row = 0; row < size; row++) {
                    bool atPlayerSpawnPosition = (col == size / 2) && (row == size / 2);

                    if (context.GetGroundLayerStock(row, col) != null &&
                        !atPlayerSpawnPosition) {
                        if (rnd.Next(0, 15 + (int)CurrDifficulty) == 1) {
                            context.AddStructureAtPosition(StructurePresets.GetALTree().stock_id, row, col);
                        }
                        else if (rnd.Next(0, 40 + (int)CurrDifficulty) == 1) {
                            context.AddStructureAtPosition(StructurePresets.GetALBoulder().stock_id, row, col);
                        }
                        else {
                            context.AddStructureAtPosition(null, row, col);
                        }
                    }
                    else {
                        context.AddStructureAtPosition(null, row, col);
                    }
                }
            }
            context.SaveChanges();
        }

        private static void GenerateMobLayer(int size) {
            for (int col = 0; col < size; col++) {
                for (int row = 0; row < size; row++) {
                    bool atPlayerSpawnPosition = (col == size / 2) && (row == size / 2);

                    if (context.GetGroundLayerStock(row, col) != null &&
                        context.GetStructureLayerStock(row, col) == null) {
                        if (atPlayerSpawnPosition) {
                            MI.Player.YPos = row;
                            MI.Player.XPos = col;
                            context.AddMobAtPosition(MI.Player.stock_id, row, col);
                        }
                        else if (rnd.Next(0, 15 + (int)CurrDifficulty) == 1) {
                            context.AddMobAtPosition(LandMobsPresets.GetACow().stock_id, row, col);
                        }
                        else if (rnd.Next(0, 15 + (int)CurrDifficulty) == 1) {
                            context.AddMobAtPosition(LandMobsPresets.GetASheep().stock_id, row, col);
                        }
                        else {
                            context.AddMobAtPosition(null, row, col);
                        }
                    }
                    else {
                        context.AddMobAtPosition(null, row, col);
                    }
                }
            }
            context.SaveChanges();
        }
    }
}
