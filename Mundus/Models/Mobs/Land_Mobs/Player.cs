using System;
using Gtk;
using Mundus.Models.SuperLayers;
using Mundus.Models.Tiles;

namespace Mundus.Models.Mobs.Land_Mobs {
    public class Player : IMob {
        public MobTile Tile { get; private set; }
        public ISuperLayer CurrSuperLayer { get; set; }
        public int YPos { get; set; }
        public int XPos { get; set; }

        public Player(string stock_id) : this(new MobTile(stock_id)) 
        { }

        public Player(MobTile tile) {
            this.Tile = tile;
        }
    }
}
