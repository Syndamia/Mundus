namespace Mundus.Data.SuperLayers.DBTables 
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Data type for the DBSet of (Land) LStructureLayer table
    /// </summary>
    [Table("LStructureLayer", Schema = "Mundus")]
    public class LSPlacedTile : PlacedTile 
    {
        public LSPlacedTile(string stock_id, int health, int yPos, int xPos) : base(stock_id, yPos, xPos) 
        {
            this.Health = health;
        }

        /// <summary>
        /// Gets or sets the health of the structure
        /// </summary>
        public int Health { get; set; }
    }
}
