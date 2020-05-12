namespace Mundus.Data.SuperLayers.DBTables 
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Data type for the DBSet of (Undergound) UStructureLayer table
    /// </summary>
    [Table("UStructureLayer", Schema = "Mundus")]
    public class USPlacedTile : PlacedTile 
    {
        public USPlacedTile(string stock_id, int health, int yPos, int xPos) : base(stock_id, yPos, xPos) 
        {
            this.Health = health;
        }

        /// <summary>
        /// Gets or sets the health of the structure
        /// </summary>
        public int Health { get; set; }
    }
}
