namespace Mundus.Service.Tiles.Items {
    public class Structure : ItemTile {
        public int ReqToolType { get; private set; }
        public int ReqToolClass { get; private set; }

        public bool IsWalkable { get; private set; }

        public Structure(string stock_id, int reqToolType, int reqToolClass, bool isWalkable = false) : base(stock_id) {
            this.ReqToolType = reqToolType;
            this.ReqToolClass = reqToolClass;
            this.IsWalkable = isWalkable;
        }
    }
}
