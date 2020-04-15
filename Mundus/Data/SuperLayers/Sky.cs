using System;
using Mundus.Service.Tiles;
using Mundus.Service.Tiles.Items;

namespace Mundus.Data.SuperLayers {
    public class Sky : ISuperLayer {
        private static MobTile[,] mobLayer;
        private static Structure[,] structureLayer;
        private static GroundTile[,] groundLayer;

        public Sky() { }

        public MobTile GetMobLayerTile(int yPos, int xPos) {
            return mobLayer[yPos, xPos];
        }
        public Structure GetStructureLayerTile(int yPos, int xPos) {
            return structureLayer[yPos, xPos];
        }
        public GroundTile GetGroundLayerTile(int yPos, int xPos) {
            return groundLayer[yPos, xPos];
        }

        public void SetMobLayer(MobTile[,] mobTiles) {
            mobLayer = mobTiles;
        }
        public void SetMobAtPosition(MobTile tile, int yPos, int xPos) {
            mobLayer[yPos, xPos] = tile;
        }
        public void RemoveMobFromPosition(int yPos, int xPos) {
            mobLayer[yPos, xPos] = null;
        }

        public void SetStructureLayer(Structure[,] itemTiles) {
            structureLayer = itemTiles;
        }
        public void SetStructureAtPosition(Structure tile, int yPos, int xPos) {
            structureLayer[yPos, xPos] = tile;
        }
        public void RemoveStructureFromPosition(int yPos, int xPos) {
            structureLayer[yPos, xPos] = null;
        }

        public void SetGroundLayer(GroundTile[,] groundTiles) {
            groundLayer = groundTiles;
        }
        public void SetGroundAtPosition(GroundTile tile, int yPos, int xPos) {
            groundLayer[yPos, xPos] = tile;
        }
        public void RemoveGroundFromPosition(int yPos, int xPos) {
            groundLayer[yPos, xPos] = null;
        }

        public override string ToString() {
            return "Sky";
        }
    }
}
