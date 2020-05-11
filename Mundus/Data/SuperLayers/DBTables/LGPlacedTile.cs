using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mundus.Data.SuperLayers.DBTables {
    [Table("LGroundLayer", Schema = "Mundus")]
    public class LGPlacedTile : PlacedTile {
        public LGPlacedTile(string stock_id, int yPos, int xPos) : base(stock_id, yPos, xPos) {
        }
    }
}
