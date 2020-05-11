using System;
using System.ComponentModel.DataAnnotations.Schema;
using Mundus.Data.Windows;

namespace Mundus.Data.SuperLayers.DBTables {
    [Table("LMobLayer", Schema = "Mundus")]
    public class LMPlacedTile : PlacedTile {
        public int Health { get; set; }

        public LMPlacedTile(string stock_id, int health, int yPos, int xPos) : base(stock_id, yPos, xPos) {
            this.Health = health;
        }
    }
}
