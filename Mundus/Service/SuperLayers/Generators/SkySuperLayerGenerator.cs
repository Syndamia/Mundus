using System;
using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles.Mobs;
using Mundus.Service.Tiles.Items.Presets;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.SuperLayers.Generators {
    public static class SkySuperLayerGenerator {
        private static Random rnd;

        public static void GenerateAllLayers(int size) {
            rnd = new Random();

            LI.Sky.SetMobLayer(GenerateMobLayer(size));
            LI.Sky.SetGroundLayer(GenerateGroundLayer(size));
            LI.Sky.SetStructureLayer(GenerateStructureLayer(size));
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
            GroundTile[,] tiles = new GroundTile[size, size];

            for (int col = 0; col < size; col++) {
                for (int row = 0; row < size; row++) {
                    tiles[col, row] = GroundPresets.GetASSky();
                }
            }
            return tiles;
        }

        private static Structure[,] GenerateStructureLayer(int size) {
            Structure[,] tiles = new Structure[size, size];

            for (int col = 0; col < size; col++) {
                for (int row = 0; row < size; row++) {
                }
            }
            return tiles;
        }
    }
}
