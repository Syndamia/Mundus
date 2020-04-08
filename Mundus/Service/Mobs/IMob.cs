using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles;

namespace Mundus.Service.Mobs {
    public interface IMob {
        MobTile Tile { get; }
        ISuperLayer CurrSuperLayer { get; set; }
        ISuperLayer GetLayerUndearneathCurr();
        ISuperLayer GetLayerOnTopOfCurr();
        int XPos { get; set; }
        int YPos { get; set; }
        int Health { get; set; }
    }
}
