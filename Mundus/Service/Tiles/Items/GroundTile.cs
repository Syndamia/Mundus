using Gtk;
using Mundus.Data.Tiles;

namespace Mundus.Service.Tiles.Items {
    public class GroundTile : ItemTile {
        public int ReqShovelClass { get; private set; }

        public GroundTile(GroundTile groundTile) :this(groundTile.stock_id, groundTile.ReqShovelClass)
        { }

        public GroundTile(string stock_id, int reqShovelClass) :base(stock_id) {
            this.ReqShovelClass = reqShovelClass;
        }

        public override string ToString() {
            return $"GroundTile | ID: {this.stock_id} TT: {ToolTypes.Shovel} TC: {this.ReqShovelClass}";
        }
    }
}
