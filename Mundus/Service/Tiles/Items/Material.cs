namespace Mundus.Service.Tiles.Items {
    public class Material : ItemTile {
        public Material(string stock_id) : base(stock_id) 
        { }

        public override string ToString() {
            return $"Material | Stock ID: {this.stock_id}";
        }
    }
}
