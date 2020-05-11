using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mundus.Data.SuperLayers.DBTables {
    [Table("SStructureLayer", Schema = "Mundus")]
    public class SSPlacedTile : PlacedTile {
        public SSPlacedTile(string stock_id, int yPos, int xPos):base(stock_id, yPos, xPos) {
        }
    }
}
