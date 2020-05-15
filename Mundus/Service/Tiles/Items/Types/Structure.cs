namespace Mundus.Service.Tiles.Items.Types 
{
    using static Mundus.Data.Values;

    public class Structure : ItemTile 
    {
        private Material droppedMaterial;

        public Structure(Structure structure) :this(structure.stock_id, structure.inventory_stock_id, structure.Health, structure.ReqToolType, structure.ReqToolClass, structure.IsWalkable, 
                         structure.IsWalkable, (structure.droppedMaterial != null)?new Material(structure.droppedMaterial.stock_id):null) 
        { 
        }

        public Structure(string stock_id, string inventory_stock_id, int health, ToolType reqToolType, int reqToolClass, bool isWalkable = false, bool isClimable = false, Material droppedMaterial = null) : base(stock_id) 
        {
            this.inventory_stock_id = inventory_stock_id;
            this.Health = health;
            this.ReqToolType = reqToolType;
            this.ReqToolClass = reqToolClass;
            this.IsWalkable = isWalkable;
            this.IsClimable = isClimable;
            this.droppedMaterial = droppedMaterial;
        }

        /// <summary>
        /// Gets the stock_id for when the structure is in an inventory
        /// </summary>
        public string inventory_stock_id { get; private set; }

        /// <summary>
        /// Gets the required type of tool to break the structure
        /// </summary>
        public ToolType ReqToolType { get; private set; }

        /// <summary>
        /// Gets the required minimal tool class to break the structure
        /// </summary>
        public int ReqToolClass { get; private set; }

        public int Health { get; private set; }

        /// <summary>
        /// Gets whether mobs can change superlayers (climb up or down a superlayer ; true) or not (false)
        /// </summary>
        public bool IsClimable { get; private set; }

        /// <summary>
        /// Gets whether mob can walk on top of the structure (true) or not (false)
        /// </summary>
        public bool IsWalkable { get; private set; }

        /// <summary>
        /// Returns what the structure drops after being broken
        /// </summary>
        public ItemTile GetDrop() 
        {
            if (this.droppedMaterial == null) 
            {
                return this;
            }

            return droppedMaterial;
        }

        /// <summary>
        /// Removes health from structure
        /// </summary>
        /// <returns>Whether the structure can still be damaged</returns>
        public bool TakeDamage(int damagePoints) 
        {
            this.Health -= damagePoints;
            return this.Health > 0;
        }

        public override string ToString() 
        {
            return $"Structure | ID: {this.stock_id} H: {this.Health} TT: {this.ReqToolType} TC: {this.ReqToolClass} " +
            	   $"W: {this.IsWalkable} DM ID: {((this.droppedMaterial != null) ? this.droppedMaterial.stock_id : null)}";
        }
    }
}
