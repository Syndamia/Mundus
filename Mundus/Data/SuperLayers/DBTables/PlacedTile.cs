namespace Mundus.Data.SuperLayers.DBTables {
    public abstract class PlacedTile {
        public int ID { get; private set; }
        public int XPos { get; private set; }
        public int YPos { get; private set; }
        public string stock_id { get; set; }

        public PlacedTile(string stock_id, int yPos, int xPos) {
            this.YPos = yPos;
            this.XPos = xPos;
            this.stock_id = stock_id;
        }
    }
}
