namespace Mundus.Service.Tiles.Items {
    public class Material : ItemTile {
        public Material(Material material) : base(material.stock_id) { }

        public Material(string stock_id) : base(stock_id) 
        { }

        public override string ToString() {
            return $"Material | ID: {this.stock_id}";
        }
    }
}
