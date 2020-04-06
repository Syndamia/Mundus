namespace Mundus.Service.Tiles.Items {
    public class Structure : ItemTile {
        public int ReqToolType { get; private set; }
        public int ReqToolClass { get; private set; }
        public Material DroppedMaterial { get; private set; }
        public byte Health { get; private set; }

        public bool IsWalkable { get; private set; }


        public Structure(Structure structure) :this(structure.stock_id, structure.Health, structure.ReqToolType, structure.ReqToolClass, structure.IsWalkable, 
                         new Material(structure.DroppedMaterial.stock_id)) { 
        }

        public Structure(string stock_id, byte health, int reqToolType, int reqToolClass, bool isWalkable = false, Material droppedMaterial = null) : base(stock_id) {
            this.Health = health;
            this.ReqToolType = reqToolType;
            this.ReqToolClass = reqToolClass;
            this.IsWalkable = isWalkable;
            this.DroppedMaterial = droppedMaterial;
        }

        /// <summary>
        /// Removes 1 health from structure
        /// </summary>
        /// <returns>If the structure can still be damaged</returns>
        public bool Damage() {
            this.Health--;
            return this.Health > 0;
        }

        public override string ToString() {
            return $"Structure | ID: {this.stock_id} H: {this.Health} TT: {this.ReqToolType} TC: {this.ReqToolClass} " +
            	   $"W: {this.IsWalkable} DM ID: {this.DroppedMaterial.stock_id}";
        }
    }
}
