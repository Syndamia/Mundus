using System;
using Mundus.Models.SuperLayers;
using Mundus.Models.Tiles;

namespace Mundus.Models.Mobs {
    public interface IMob {
        MobTile Tile { get; }
        ISuperLayer CurrSuperLayer { get; set; }
        int XPos { get; set; }
        int YPos { get; set; }
    }
}
