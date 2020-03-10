using System;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.SuperLayers;
using Mundus.Data.Tiles;
using Mundus.Service.Tiles;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.SuperLayers {
    public static class LandSuperLayerGenerator {
        private static Random rnd;

        public static void GenerateAllLayers(int size) {
            LI.Land.SetMobLayer(GenerateMobLayer(size));
            LI.Land.SetGroundLayer(GenerateGroundLayer(size));
            LI.Land.SetStructureLayer(GenerateStructureLayer(size));
        }

        private static MobTile[,] GenerateMobLayer(int size) {
            MobTile[,] tiles = new MobTile[size, size];

            for (int col = 0; col < size; col++) {
                for (int row = 0; row < size; row++) {
                    if (col == size / 2 && row == size / 2) {
                        LMI.Player.YPos = row;
                        LMI.Player.XPos = col;
                        LMI.Player.CurrSuperLayer = LI.Land;
                        tiles[col, row] = LMI.Player.Tile;
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
                    tiles[col, row] = new GroundTile("grass");
                }
            }
            return tiles;
        }

        private static Structure[,] GenerateStructureLayer(int size) {
            Structure[,] tiles = new Structure[size, size];

            for (int col = 0; col < size; col++) {
                for (int row = 0; row < size; row++) {
                    if (rnd.Next( 0, 50 ) == 1) {
                        tiles[col, row] = new Structure("boulder", ToolTypes.Pickaxe, 1);
                    }
                }
            }
            return tiles;
        }
    }
}
