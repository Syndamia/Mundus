namespace Mundus.Service.Tiles.Items {
    public class Structure : ItemTile {
        public int ReqToolType { get; private set; }
        public int ReqToolClass { get; private set; }
        public Material DroppedMaterial { get; private set; }

        public bool IsWalkable { get; private set; }

        public Structure(string stock_id, int reqToolType, int reqToolClass, bool isWalkable = false, Material droppedMaterial = null) : base(stock_id) {
            this.ReqToolType = reqToolType;
            this.ReqToolClass = reqToolClass;
            this.IsWalkable = isWalkable;
            this.DroppedMaterial = droppedMaterial;
        }

        public override string ToString() {
            return $"Structure | Stock ID: {this.stock_id} Tool Type: {this.ReqToolType} Tool Class: {this.ReqToolClass} " +
            	   $"Walkable: {this.IsWalkable} Dropped Material: {this.DroppedMaterial.stock_id}";
        }
    }
}
