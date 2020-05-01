namespace Mundus.Service.Tiles.Items {
    public class Material : ItemTile {
        /// <summary>
        /// Certain materials can be eaten to replenish energy points. This stores by how much to restore energy points.
        /// Note: If a material mustn't be consumed, his energy points should be less or equal to 0
        /// </summary>
        public double EnergyRestorePoints { get; private set; }

        public Material(Material material) : this(material.stock_id, material.EnergyRestorePoints) 
        { }

        public Material(string stock_id, double energyRestorePoints = -1) : base(stock_id) 
        {
            this.EnergyRestorePoints = energyRestorePoints;
        }

        public override string ToString() {
            if (EnergyRestorePoints > 0) {
                return $"Material | ID: {this.stock_id} EnergyRP: {this.EnergyRestorePoints}";
            }
            return $"Material | ID: {this.stock_id}";
        }
    }
}
