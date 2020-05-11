using System;
namespace Mundus.Data.SuperLayers {
    public interface ISuperLayerContext {
        string GetMobLayerStock(int yPos, int xPos);
        string GetStructureLayerStock(int yPos, int xPos);
        string GetGroundLayerStock(int yPos, int xPos);

        void AddMobAtPosition(string stock_id, int health, int yPos, int xPos);
        void SetMobAtPosition(string stock_id, int health, int yPos, int xPos);
        void RemoveMobFromPosition(int yPos, int xPos);
        bool TakeDamageMobAtPosition(int yPos, int xPos, int damage);

        void AddStructureAtPosition(string stock_id, int health, int yPos, int xPos);
        void SetStructureAtPosition(string stock_id, int health, int yPos, int xPos);
        void RemoveStructureFromPosition(int yPos, int xPos);
        bool TakeDamageStructureAtPosition(int yPos, int xPos, int damage);

        void AddGroundAtPosition(string stock_id, int yPos, int xPos);
        void SetGroundAtPosition(string stock_id, int yPos, int xPos);
        void RemoveGroundFromPosition(int yPos, int xPos);
    }
}
