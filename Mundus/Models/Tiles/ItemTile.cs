using System;
using Gtk;

namespace Mundus.Models.Tiles {
    public class ItemTile {
        public string stock_id { get; private set; }
        public Image Texture { get; private set; }

        public bool IsWalkable { get; private set; }

        public ItemTile(string stock_id) : this(stock_id, false ) 
        { }

        public ItemTile(string stock_id, bool isWalkable) {
            this.stock_id = stock_id;
            this.Texture = new Image( stock_id, IconSize.Dnd );

            this.IsWalkable = isWalkable;
        }
    }
}
