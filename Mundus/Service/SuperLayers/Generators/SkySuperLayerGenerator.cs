using System;
using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles.Mobs;
using Mundus.Service.Tiles.Items.Presets;
using Mundus.Service.Tiles.Items;
using Mundus.Data;
using static Mundus.Data.Values;

namespace Mundus.Service.SuperLayers.Generators {
    public static class SkySuperLayerGenerator {
        private static Random rnd;
        private static SkyContext context = DataBaseContexts.SContext;

        public static void GenerateAllLayers(MapSize mapSize) {
            rnd = new Random();
            int size = (int)mapSize;

            GenerateMobLayer(size);
            GenerateGroundLayer(size);
            GenerateStructureLayer(size);
        }

        private static void GenerateMobLayer(int size) {
            for (int col = 0; col < size; col++) {
                for (int row = 0; row < size; row++) {
                    context.AddMobAtPosition(null, -1, row, col);
                }
            }
            context.SaveChanges();
        }

        private static void GenerateGroundLayer(int size) {
            for (int col = 0; col < size; col++) {
                for (int row = 0; row < size; row++) {
                    context.AddGroundAtPosition(GroundPresets.GetSSky().stock_id, row, col);
                }
            }
            context.SaveChanges();
        }

        private static void GenerateStructureLayer(int size) {
            for (int col = 0; col < size; col++) {
                for (int row = 0; row < size; row++) {
                    context.AddStructureAtPosition(null, -1, row, col);
                }
            }
            context.SaveChanges();
        }
    }
}
