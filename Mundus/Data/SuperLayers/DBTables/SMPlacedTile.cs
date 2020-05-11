using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mundus.Data.SuperLayers.DBTables {
    [Table("SMobLayer", Schema = "Mundus")]
    public class SMPlacedTile : PlacedTile {
        public int Health { get; set; }

        public SMPlacedTile(string stock_id, int health, int yPos, int xPos) : base(stock_id, yPos, xPos) {
            this.Health = health;
        }
    }
}
