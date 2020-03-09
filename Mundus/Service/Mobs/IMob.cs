using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles;

namespace Mundus.Service.Mobs {
    public interface IMob {
        MobTile Tile { get; }
        ISuperLayer CurrSuperLayer { get; set; }
        int XPos { get; set; }
        int YPos { get; set; }
    }
}
