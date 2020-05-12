namespace Mundus.Data.SuperLayers.DBTables 
{
    /// <summary>
    /// Abstract class that is used for the classes that correspond to DBSets
    /// </summary>
    public abstract class PlacedTile 
    {
        public PlacedTile(string stock_id, int yPos, int xPos) 
        {
            this.YPos = yPos;
            this.XPos = xPos;
            this.stock_id = stock_id;
        }

        /// <summary>
        /// Gets the unique identifier (primary key ; only used in the tables by MySQL)
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Gets the position on the horizontal (x) axis of the tile in it's layer
        /// </summary>
        public int XPos { get; private set; }

        /// <summary>
        /// Gets the position on the vertical (y) axis of the tile in it's layer
        /// </summary>
        public int YPos { get; private set; }

        /// <summary>
        /// Gets or sets the stock _id of the tile
        /// </summary>
        public string stock_id { get; set; }
    }
}
