using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles;

namespace Mundus.Service.Mobs.LandMobs {
    public class Player : IMob {
        public MobTile Tile { get; private set; }
        public ISuperLayer CurrSuperLayer { get; set; }
        public int YPos { get; set; }
        public int XPos { get; set; }
        public Inventory Inventory { get; set; }

        public Player(string stock_id, int inventorySize) : this(new MobTile(stock_id), inventorySize) 
        { }

        public Player(MobTile tile, int inventorySize) {
            this.Tile = tile;
            this.Inventory = new Inventory(inventorySize);
        }
    }
}
