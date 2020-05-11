using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mundus.Data.SuperLayers.DBTables {
    [Table("SStructureLayer", Schema = "Mundus")]
    public class SSPlacedTile : PlacedTile {
        public int Health { get; set; }

        public SSPlacedTile(string stock_id, int health, int yPos, int xPos):base(stock_id, yPos, xPos) {
            this.Health = health;
        }
    }
}
