using Gtk;
using Mundus.Service.Tiles;

namespace Mundus.Service.Tiles.Items {
    public abstract class ItemTile : ITile {
        public string stock_id { get; private set; }
        public Image Texture { get; private set; }

        public ItemTile(ItemTile item) :this(item.stock_id)
        { }

        public ItemTile(string stock_id) {
            this.stock_id = stock_id;
            this.Texture = new Image( stock_id, IconSize.Dnd );
        }
    }
}
