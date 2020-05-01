using System;
using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles.Mobs.LandMobs;
using Mundus.Service.Tiles.Mobs;
using Mundus.Service.Tiles.Items.Presets;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.SuperLayers.Generators {
    public static class LandSuperLayerGenerator {
        private static Random rnd;

        public static void GenerateAllLayers(int size) {
            LI.Land.SetGroundLayer(GenerateGroundLayer(size));
            LI.Land.SetStructureLayer(GenerateStructureLayer(size));
            LI.Land.SetMobLayer(GenerateMobLayer(size));
        }

        private static GroundTile[,] GenerateGroundLayer(int size) {
            rnd = new Random();
            GroundTile[,] tiles = new GroundTile[size, size];

            for(int col = 0; col < size; col++) {
                for(int row = 0; row < size; row++) {
                    bool atPlayerSpawnPosition = (col == size / 2) && (row == size / 2);
                    // Holes in the ground should be more common with higher difficulties
                    if (rnd.Next(0, 210 - Difficulty.SelDifficulty) == 1 && !atPlayerSpawnPosition) {
                        tiles[col, row] = null;
                    }
                    else {
                        tiles[col, row] = GroundPresets.GetALGrass();
                    }
                }
            }
            return tiles;
        }

        private static Structure[,] GenerateStructureLayer(int size) {
            Structure[,] tiles = new Structure[size, size];

            for (int col = 0; col < size; col++) {
                for (int row = 0; row < size; row++) {
                    bool atPlayerSpawnPosition = (col == size / 2) && (row == size / 2);

                    if (LI.Land.GetGroundLayerTile(col, row) != null &&
                        !atPlayerSpawnPosition) {
                        if (rnd.Next(0, 40 + Difficulty.SelDifficulty) == 1) {
                            tiles[col, row] = StructurePresets.GetALBoulder();
                        }
                        if (rnd.Next(0, 15 + Difficulty.SelDifficulty) == 1) {
                            tiles[col, row] = StructurePresets.GetALTree();
                        }
                    }
                }
            }
            return tiles;
        }

        private static MobTile[,] GenerateMobLayer(int size) {
            MobTile[,] tiles = new MobTile[size, size];

            for (int col = 0; col < size; col++) {
                for (int row = 0; row < size; row++) {
                    bool atPlayerSpawnPosition = (col == size / 2) && (row == size / 2);

                    if (LI.Land.GetGroundLayerTile(col, row) != null &&
                        LI.Land.GetStructureLayerTile(col, row) == null) {
                        if (atPlayerSpawnPosition) {
                            MI.Player.YPos = col;
                            MI.Player.XPos = row;
                            tiles[col, row] = MI.Player;
                        }
                        else if (rnd.Next(0, 15 + Difficulty.SelDifficulty) == 1) {
                            tiles[col, row] = LandMobsPresets.GetACow();
                            tiles[col, row].YPos = col;
                            tiles[col, row].XPos = row;
                        }
                    }
                }
            }
            return tiles;
        }
    }
}
