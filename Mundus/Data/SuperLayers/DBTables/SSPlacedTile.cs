namespace Mundus.Data.SuperLayers.DBTables 
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Data type for the DBSet of (Sky) SStructureLayer table
    /// </summary>
    [Table("SStructureLayer", Schema = "Mundus")]
    public class SSPlacedTile : PlacedTile 
    {
        public SSPlacedTile(string stock_id, int health, int yPos, int xPos) : base(stock_id, yPos, xPos)
        {
            this.Health = health;
        }

        /// <summary>
        /// Gets or sets the health of the structure
        /// </summary>
        public int Health { get; set; }
    }
}
