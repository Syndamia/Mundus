using Mundus.Data.Tiles;

namespace Mundus.Service.Tiles.Items {
    public class Tool : ItemTile {
        public int Type { get; private set; }
        public int Class { get; private set; }

        public Tool(string stock_id, int toolType, int toolClass) : base(stock_id) {
            this.Type = toolType;
            this.Class = toolClass;
        }
    }
}
