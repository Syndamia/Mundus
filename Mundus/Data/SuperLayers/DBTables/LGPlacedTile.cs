namespace Mundus.Data.SuperLayers.DBTables 
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Data type for the DBSet of (Land) LGroundLayer table
    /// </summary>
    [Table("LGroundLayer", Schema = "Mundus")]
    public class LGPlacedTile : PlacedTile 
    {
        public LGPlacedTile(string stock_id, int yPos, int xPos) : base(stock_id, yPos, xPos) 
        { 
        }
    }
}
