using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Mobs.LandMobs {
    public class Player : MobTile {
        public Player(string stock_id, int health, ISuperLayer currentSuperLayer, int inventorySize)
               : base(stock_id, health, currentSuperLayer, inventorySize, -1, null) 
        {
            base.DroppedUponDeath = (Material)Inventory.Hotbar[0];
        }
    }
}
