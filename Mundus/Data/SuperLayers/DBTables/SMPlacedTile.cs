using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mundus.Data.SuperLayers.DBTables {
    [Table("SMobLayer", Schema = "Mundus")]
    public class SMPlacedTile : PlacedTile {
        public SMPlacedTile(string stock_id, int yPos, int xPos) : base(stock_id, yPos, xPos) {
        }
    }
}
