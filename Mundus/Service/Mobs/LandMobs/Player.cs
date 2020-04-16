using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Mobs.LandMobs {
    public class Player : MobTile {
        public Inventory Inventory { get; set; }

        public Player(string stock_id, int health, int inventorySize, ISuperLayer currentSuperLayer) : base(stock_id, health, currentSuperLayer) 
        {
            this.Inventory = new Inventory(inventorySize);
        }
    }
}
