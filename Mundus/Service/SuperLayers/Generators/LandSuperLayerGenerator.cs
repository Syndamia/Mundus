using System;
using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.SuperLayers;
using Mundus.Service.Mobs.LandMobs;
using Mundus.Service.Tiles;
using Mundus.Service.Tiles.ItemPresets;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.SuperLayers.Generators {
    public static class LandSuperLayerGenerator {
        private static Random rnd;

        public static void GenerateAllLayers(int size) {
            LI.Land.SetGroundLayer(GenerateGroundLayer(size));
            LI.Land.SetStructureLayer(GenerateStructureLayer(size));
            LI.Land.SetMobLayer(GenerateMobLayer(size));
        }

        private static MobTile[,] GenerateMobLayer(int size) {
            MobTile[,] tiles = new MobTile[size, size];

            for (int y = 0; y < size; y++) {
                for (int x = 0; x < size; x++) {
                    if (LI.Land.GetGroundLayerTile(y, x) != null &&
                        LI.Land.GetStructureLayerTile(y, x) == null) 
                    {
                        if (y == size / 2 && x == size / 2) {
                            MI.Player.YPos = x;
                            MI.Player.XPos = y;
                            tiles[y, x] = MI.Player;
                        }
                        else if (rnd.Next(0, 20 + Difficulty.SelDifficulty) == 1) {
                            tiles[y, x] = LandMobsPresets.GetACow();
                            tiles[y, x].YPos = y;
                            tiles[y, x].XPos = x;
                        }
                    }
                }
            }
            return tiles;
        }

        private static GroundTile[,] GenerateGroundLayer(int size) {
            rnd = new Random();
            GroundTile[,] tiles = new GroundTile[size, size];

            for(int col = 0; col < size; col++) {
                for(int row = 0; row < size; row++) {
                    // Holes in the ground should be more common with higher difficulties
                    if (rnd.Next(0, 210 - Difficulty.SelDifficulty) == 1) {
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
                    if (LI.Land.GetGroundLayerTile(col, row) != null) {
                        if (rnd.Next(0, 40 + Difficulty.SelDifficulty) == 1) {
                            tiles[col, row] = StructurePresets.GetALBoulder();
                        }
                        if (rnd.Next(0, 10 + Difficulty.SelDifficulty) == 1) {
                            tiles[col, row] = StructurePresets.GetALTree();
                        }
                    }
                }
            }
            return tiles;
        }
    }
}
