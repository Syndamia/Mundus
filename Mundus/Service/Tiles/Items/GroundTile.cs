using Gtk;
using Mundus.Data.Tiles;

namespace Mundus.Service.Tiles.Items {
    public class GroundTile : ItemTile {
        public int ReqShovelClass { get; private set; }
        public bool Solid { get; private set; }

        public GroundTile(GroundTile groundTile) :this(groundTile.stock_id, groundTile.ReqShovelClass, groundTile.Solid)
        { }

        public GroundTile(string stock_id, int reqShovelClass, bool solid = true) :base(stock_id) {
            this.ReqShovelClass = reqShovelClass;
            this.Solid = solid;
        }

        public override string ToString() {
            return $"GroundTile | ID: {this.stock_id} TT: {ToolTypes.Shovel} TC: {this.ReqShovelClass}";
        }
    }
}
