using Gtk;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Tiles {
    public class GroundTile : ITile {
        public string stock_id { get; private set; }
        public Image Texture { get; private set; }
        public int ReqShovelClass { get; private set; }
        public Material DroppedMaterial { get; private set; }

        public GroundTile(string stock_id, int reqShovelClass, Material droppedMaterial = null) {
            this.stock_id = stock_id;
            this.ReqShovelClass = reqShovelClass;
            this.DroppedMaterial = droppedMaterial;
            this.Texture = new Image(stock_id, IconSize.Dnd);
        }
    }
}
