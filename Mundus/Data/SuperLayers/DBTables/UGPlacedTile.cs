using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mundus.Data.SuperLayers.DBTables {
    [Table("UGroundLayer", Schema = "Mundus")]
    public class UGPlacedTile : PlacedTile {
        public UGPlacedTile(string stock_id, int yPos, int xPos) : base(stock_id, yPos, xPos) {
        }
    }
}
