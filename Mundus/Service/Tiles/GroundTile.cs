using Gtk;

namespace Mundus.Service.Tiles {
    public class GroundTile : ITile {
        public string stock_id { get; private set; }
        public Image Texture { get; private set; }

        public GroundTile(string stock_id) {
            this.stock_id = stock_id;
            this.Texture = new Image(stock_id, IconSize.Dnd);
        }
    }
}
