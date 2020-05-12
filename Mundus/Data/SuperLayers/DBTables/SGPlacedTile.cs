namespace Mundus.Data.SuperLayers.DBTables 
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Data type for the DBSet of (Sky) SGroundLayer table
    /// </summary>
    [Table("SGroundLayer", Schema = "Mundus")]
    public class SGPlacedTile : PlacedTile 
    {
        public SGPlacedTile(string stock_id, int yPos, int xPos) : base(stock_id, yPos, xPos) 
        {
        }
    }
}
