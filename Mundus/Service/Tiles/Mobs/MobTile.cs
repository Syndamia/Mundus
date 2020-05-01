using Gtk;
using Mundus.Data;
using Mundus.Data.SuperLayers;
using Mundus.Data.Windows;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Tiles.Mobs {
    public class MobTile : ITile {
        public string stock_id { get; private set; }
        public Image Texture { get; private set; }

        public ISuperLayer CurrSuperLayer { get; set; }
        public int YPos { get; set; }
        public int XPos { get; set; }
        public int Health { get; private set; }
        public int Defense { get; set; }
        public Material DroppedUponDeath { get; protected set; }
        public Inventory Inventory { get; set; }

        /// <summary>
        /// Specifies how big the chance of a mob moving (randomly) is. Lower the value, higher the chance for movement.
        /// Note: negative values (or 0) means the mob won't move randomly
        /// </summary>
        public int RndMovementRate { get; protected set; }

        public MobTile(string stock_id, int health, int defence, ISuperLayer currentSuperLayer, int inventorySize = 5, Material droppedUponDeath = null, int rndMovementQualifier = 3) {
            this.stock_id = stock_id;
            this.Texture = new Image(stock_id, IconSize.Dnd);
            this.Health = health;
            this.Defense = defence;
            this.CurrSuperLayer = currentSuperLayer;
            this.RndMovementRate = rndMovementQualifier;
            this.DroppedUponDeath = droppedUponDeath;
            this.Inventory = new Inventory(inventorySize);
        }

        /// <summary>
        /// Removes health from mob
        /// </summary>
        /// <returns>Whether the mob can still be damaged</returns>
        public bool TakeDamage(int damagePoints) {
            this.Health -= damagePoints;
            return this.Health > 0;
        }

        /// <summary>
        /// Heals the mobtile (unless/until it has full health (4 * inventorySize))
        /// </summary>
        /// <param name="healthPoints">Health points to heal with</param>
        public void Heal(int healthPoints) {
            this.Health += healthPoints;

            if (this.Health > WI.SelWin.Size * 4) {
                this.Health = WI.SelWin.Size * 4;
            }
        }
    }
}