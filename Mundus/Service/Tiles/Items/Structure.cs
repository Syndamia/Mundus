namespace Mundus.Service.Tiles.Items {
    public class Structure : ItemTile {
        private Material droppedMaterial;

        public string inventory_stock_id { get; private set; }
        public int ReqToolType { get; private set; }
        public int ReqToolClass { get; private set; }
        public int Health { get; private set; }

        public bool IsClimable { get; private set; }
        public bool IsWalkable { get; private set; }


        public Structure(Structure structure) :this(structure.stock_id, structure.inventory_stock_id, structure.Health, structure.ReqToolType, structure.ReqToolClass, structure.IsWalkable, 
                         structure.IsWalkable, (structure.droppedMaterial != null)?new Material(structure.droppedMaterial.stock_id):null) { 
        }

        /// <summary>
        /// Initializes a new instance of the Stucture class.
        /// </summary>
        /// <param name="stock_id">Stock identifier.</param>
        /// <param name="health">Health.</param>
        /// <param name="reqToolType">Required tool type.</param>
        /// <param name="reqToolClass">Required tool class.</param>
        /// <param name="isWalkable">If set to <c>true</c> is walkable.</param>
        /// <param name="droppedMaterial">Dropped material. If null, structure drops itself</param>
        public Structure(string stock_id, string inventory_stock_id, int health, int reqToolType, int reqToolClass, bool isWalkable = false, bool isClimable = false, Material droppedMaterial = null) : base(stock_id) {
            this.inventory_stock_id = inventory_stock_id;
            this.Health = health;
            this.ReqToolType = reqToolType;
            this.ReqToolClass = reqToolClass;
            this.IsWalkable = isWalkable;
            this.IsClimable = isClimable;
            this.droppedMaterial = droppedMaterial;
        }

        /// <summary>
        /// Returns what the structure drops after being broken
        /// </summary>
        /// <returns>The drop.</returns>
        public ItemTile GetDrop() {
            if (droppedMaterial == null) {
                return this;
            }
            return droppedMaterial;
        }

        /// <summary>
        /// Removes 1 health from structure
        /// </summary>
        /// <returns>If the structure can still be damaged</returns>
        public bool Damage(int damagePoints) {
            this.Health -= damagePoints;
            return this.Health > 0;
        }

        public override string ToString() {
            return $"Structure | ID: {this.stock_id} H: {this.Health} TT: {this.ReqToolType} TC: {this.ReqToolClass} " +
            	   $"W: {this.IsWalkable} DM ID: {((droppedMaterial != null)?this.droppedMaterial.stock_id:null)}";
        }
    }
}
