using System;
using System.Collections.Generic;
using Mundus.Models.Tiles;

namespace Mundus.Models.SuperLayers {
    public class Land : ISuperLayer {
        private static MobTile[,] mobLayer;
        private static ItemTile[,] itemLayer;
        private static GroundTile[,] groundLayer;

        public Land() { }

        public MobTile GetMobLayerTile(int yPos, int xPos) {
            return mobLayer[yPos, xPos];
        }
        public ItemTile GetItemLayerTile(int yPos, int xPos) {
            return itemLayer[yPos, xPos];
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

        public void SetItemLayer(ItemTile[,] itemTiles) {
            itemLayer = itemTiles;
        }
        public void SetItemAtPosition(ItemTile tile, int yPos, int xPos) {
            itemLayer[yPos, xPos] = tile;
        }
        public void RemoveItemFromPosition(int yPos, int xPos) {
            itemLayer[yPos, xPos] = null;
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
    }
}
