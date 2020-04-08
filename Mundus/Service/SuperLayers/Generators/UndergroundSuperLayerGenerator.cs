using System;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles;
using Mundus.Service.Tiles.ItemPresets;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.SuperLayers.Generators {
    public static class UndergroundSuperLayerGenerator {
        private static Random rnd;

        public static void GenerateAllLayers(int size) {
            LI.Underground.SetMobLayer(GenerateMobLayer(size));
            LI.Underground.SetGroundLayer(GenerateGroundLayer(size));
            LI.Underground.SetStructureLayer(GenerateStructureLayer(size));
        }

        private static MobTile[,] GenerateMobLayer(int size) {
            MobTile[,] tiles = new MobTile[size, size];

            for (int col = 0; col < size; col++) {
                for (int row = 0; row < size; row++) {

                }
            }
            return tiles;
        }

        private static GroundTile[,] GenerateGroundLayer(int size) {
            rnd = new Random();
            GroundTile[,] tiles = new GroundTile[size, size];

            for (int col = 0; col < size; col++) {
                for (int row = 0; row < size; row++) {
                    tiles[col, row] = GroundPresets.GetAURoche();
                }
            }
            return tiles;
        }

        private static Structure[,] GenerateStructureLayer(int size) {
            Structure[,] tiles = new Structure[size, size];

            for (int col = 0; col < size; col++) {
                for (int row = 0; row < size; row++) {
                    if (LI.Land.GetGroundLayerTile(col, row) != null) {
                        tiles[col, row] = StructurePresets.GetAURock();
                        if (rnd.Next(0, 10) == 1) {
                            tiles[col, row] = null;
                        }
                    }
                }
            }
            return tiles;
        }
    }
}
