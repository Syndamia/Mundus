using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mundus.Data.SuperLayers.DBTables {
    [Table("LStructureLayer", Schema = "Mundus")]
    public class LSPlacedTile : PlacedTile {
        public int Health { get; set; }

        public LSPlacedTile(string stock_id, int health, int yPos, int xPos) : base(stock_id, yPos, xPos) {
            this.Health = health;
        }
    }
}
