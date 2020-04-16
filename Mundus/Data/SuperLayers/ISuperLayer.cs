using Mundus.Service.Tiles;
using Mundus.Service.Tiles.Items;

namespace Mundus.Data.SuperLayers {
    public interface ISuperLayer {
        MobTile GetMobLayerTile(int yPos, int xPos);
        Structure GetStructureLayerTile(int yPos, int xPos);
        GroundTile GetGroundLayerTile(int yPos, int xPos);

        void SetMobLayer(MobTile[,] mobTiles);
        void SetMobAtPosition(MobTile tile, int yPos, int xPos);
        void RemoveMobFromPosition(int yPos, int xPos);

        void SetStructureLayer(Structure[,] itemTiles);
        void SetStructureAtPosition(Structure tile, int yPos, int xPos);
        void RemoveStructureFromPosition(int yPos, int xPos);

        void SetGroundLayer(GroundTile[,] groundTiles);
        void SetGroundAtPosition(GroundTile tile, int yPos, int xPos);
        void RemoveGroundFromPosition(int yPos, int xPos);
    }
}
