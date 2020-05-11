using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mundus.Data.SuperLayers.DBTables {
    [Table("UStructureLayer", Schema = "Mundus")]
    public class USPlacedTile : PlacedTile {
        public int Health { get; set; }

        public USPlacedTile(string stock_id, int health, int yPos, int xPos) : base(stock_id, yPos, xPos) {
            this.Health = health;
        }
    }
}
