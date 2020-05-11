using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mundus.Data.SuperLayers.DBTables {
    [Table("UMobLayer", Schema = "Mundus")]
    public class UMPlacedTile : PlacedTile {
        public int Health { get; set; }

        public UMPlacedTile(string stock_id, int health, int yPos, int xPos) : base(stock_id, yPos, xPos) {
            this.Health = health;
        }
    }
}
