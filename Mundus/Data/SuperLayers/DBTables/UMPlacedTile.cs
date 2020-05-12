namespace Mundus.Data.SuperLayers.DBTables 
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Data type for the DBSet of (Undergound) UMobLayer table
    /// </summary>
    [Table("UMobLayer", Schema = "Mundus")]
    public class UMPlacedTile : PlacedTile 
    {
        public UMPlacedTile(string stock_id, int health, int yPos, int xPos) : base(stock_id, yPos, xPos) 
        {
            this.Health = health;
        }

        /// <summary>
        /// Gets or sets the health of the mob
        /// </summary>
        public int Health { get; set; }
    }
}
