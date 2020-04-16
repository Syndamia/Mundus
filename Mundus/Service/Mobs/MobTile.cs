using System;
using Gtk;
using Mundus.Data.SuperLayers;
using Mundus.Service.Mobs;
using Mundus.Service.Mobs.Controllers;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Tiles {
    public class MobTile : ITile {
        public string stock_id { get; private set; }
        public Image Texture { get; private set; }

        public ISuperLayer CurrSuperLayer { get; set; }
        public int YPos { get; set; }
        public int XPos { get; set; }
        public int Health { get; set; }
        public Material DroppedUponDeath { get; private set; }

        /// <summary>
        /// Specifies how big the chance of a mob moving (randomly) is. lower value means higher chance for movement.
        /// </summary>
        /// <value>The random movement limiter.</value>
        public int RndMovementRate { get; private set; }

        public MobTile(string stock_id, int health, ISuperLayer currentSuperLayer, int rndMovementQualifier = 3, Material droppedUponDeath = null) {
            this.stock_id = stock_id;
            this.Texture = new Image(stock_id, IconSize.Dnd);
            this.Health = health;
            this.CurrSuperLayer = currentSuperLayer;
            this.RndMovementRate = rndMovementQualifier;
            this.DroppedUponDeath = droppedUponDeath;
        }
    }
}
