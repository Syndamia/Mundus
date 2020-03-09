using Gtk;

namespace Mundus.Service.Tiles {
    public interface ITile {
        string stock_id { get; }
        Image Texture { get; }
    }
}
