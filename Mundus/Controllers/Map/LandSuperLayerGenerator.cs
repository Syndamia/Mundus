using System;
using Mundus.Models;
using Mundus.Models.Tiles;
using Mundus.Models.SuperLayers;
using Mundus.Models.Mobs.Land_Mobs;

namespace Mundus.Controllers.Map {
    public static class LandSuperLayerGenerator {
        private static Random rnd;

        public static void GenerateAllLayers(int size) {
            LI.Land.SetMobLayer(GenerateMobLayer(size));
            LI.Land.SetGroundLayer(GenerateGroundLayer(size));
            LI.Land.SetItemLayer(GenerateItemLayer(size));
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

        private static ItemTile[,] GenerateItemLayer(int size) {
            ItemTile[,] tiles = new ItemTile[size, size];

            for (int col = 0; col < size; col++) {
                for (int row = 0; row < size; row++) {
                    if (rnd.Next( 0, 5 ) == 1) {
                        tiles[col, row] = new ItemTile("boulder");
                    }
                }
            }
            return tiles;
        }
    }
}
