using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles;

namespace Mundus.Service.Mobs.LandMobs {
    public class Player : IMob {
        public MobTile Tile { get; private set; }
        public ISuperLayer CurrSuperLayer { get; set; }
        public int YPos { get; set; }
        public int XPos { get; set; }
        public Inventory Inventory { get; set; }
        public int Health { get; set; }

        public Player(string stock_id, int health, int inventorySize) : this(new MobTile(stock_id), health, inventorySize) 
        { }

        public Player(MobTile tile, int health, int inventorySize) {
            this.Tile = tile;
            this.Inventory = new Inventory(inventorySize);
            this.Health = health;
        }

        public ISuperLayer GetLayerUndearneathCurr() {
            if (CurrSuperLayer == LI.Land) {
                return LI.Underground;
            }
            return null;
        }

        public ISuperLayer GetLayerOnTopOfCurr() {
            if (CurrSuperLayer == LI.Underground) {
                return LI.Land;
            }
            return null;
        }
    }
}
