using System.Linq;
using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Mobs.LandMobs {
    public class Player : MobTile {
        /// <summary>
        /// Note: player has an rndMovementQualifier of -1 and drops first item in the hotbar
        /// </summary>
        public Player(string stock_id, int health, ISuperLayer currentSuperLayer, int inventorySize)
               : base(stock_id, health, currentSuperLayer, inventorySize, null, -1) 
        {
            this.DroppedUponDeath = (Material)this.Inventory.Hotbar[0];
        }
    }
}
