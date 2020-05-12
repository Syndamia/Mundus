namespace Mundus.Data.SuperLayers.DBTables 
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Data type for the DBSet of (Undergound) UGroundLayer table
    /// </summary>
    [Table("UGroundLayer", Schema = "Mundus")]
    public class UGPlacedTile : PlacedTile 
    {
        public UGPlacedTile(string stock_id, int yPos, int xPos) : base(stock_id, yPos, xPos) 
        {
        }
    }
}
