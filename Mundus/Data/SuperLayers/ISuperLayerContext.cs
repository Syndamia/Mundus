using System;
namespace Mundus.Data.SuperLayers {
    public interface ISuperLayerContext {
        string GetMobLayerStock(int yPos, int xPos);
        string GetStructureLayerStock(int yPos, int xPos);
        string GetGroundLayerStock(int yPos, int xPos);

        void AddMobAtPosition(string stock_id, int yPos, int xPos);
        void SetMobAtPosition(string stock_id, int yPos, int xPos);
        void RemoveMobFromPosition(int yPos, int xPos);

        void AddStructureAtPosition(string stock_id, int yPos, int xPos);
        void SetStructureAtPosition(string stock_id, int yPos, int xPos);
        void RemoveStructureFromPosition(int yPos, int xPos);

        void AddGroundAtPosition(string stock_id, int yPos, int xPos);
        void SetGroundAtPosition(string stock_id, int yPos, int xPos);
        void RemoveGroundFromPosition(int yPos, int xPos);
    }
}
