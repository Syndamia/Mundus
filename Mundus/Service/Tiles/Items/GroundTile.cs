using Gtk;
using Mundus.Data.Tiles;

namespace Mundus.Service.Tiles.Items {
    public class GroundTile : ItemTile {
        /// <summary>
        /// Required minimal shovel class for destroying the ground tile
        /// </summary>
        public int ReqShovelClass { get; private set; }
        /// <summary>
        /// Determines whether mobs can go through and structures can be placed (if not solid)
        /// </summary>
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
