namespace Mundus.Data.SuperLayers.DBTables 
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Data type for the DBSet of (Land) LMobLayer table
    /// </summary>
    [Table("LMobLayer", Schema = "Mundus")]
    public class LMPlacedTile : PlacedTile 
    {
        public LMPlacedTile(string stock_id, int health, int yPos, int xPos) : base(stock_id, yPos, xPos)
        {
            this.Health = health;
        }

        /// <summary>
        /// Gets or sets the health of the mob
        /// </summary>
        public int Health { get; set; }
    }
}
