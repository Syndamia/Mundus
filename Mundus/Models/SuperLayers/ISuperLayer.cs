using System;
using System.Collections.Generic;
using Mundus.Models.Tiles;
using Gtk;

namespace Mundus.Models.SuperLayers {
    public interface ISuperLayer {
        MobTile GetMobLayerTile(int yPpos, int xPos);
        ItemTile GetItemLayerTile(int yPos, int xPos);
        GroundTile GetGroundLayerTile(int yPos, int xPos);

        void SetMobLayer(MobTile[,] mobTiles);
        void SetMobAtPosition(MobTile tile, int yPos, int xPos);
        void RemoveMobFromPosition(int yPos, int xPos);

        void SetItemLayer(ItemTile[,] itemTiles);
        void SetItemAtPosition(ItemTile tile, int yPos, int xPos);
        void RemoveItemFromPosition(int yPos, int xPos);

        void SetGroundLayer(GroundTile[,] groundTiles);
        void SetGroundAtPosition(GroundTile tile, int yPos, int xPos);
        void RemoveGroundFromPosition(int yPos, int xPos);
    }
}
