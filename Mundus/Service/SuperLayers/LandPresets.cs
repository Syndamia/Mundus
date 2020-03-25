using Mundus.Data.Tiles;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.SuperLayers {
    public static class LandPresets {
        public static Structure Boulder() {
            return new Structure("boulder", ToolTypes.Pickaxe, 1, false, new Material("land_rock"));
        }

        public static Structure Tree() {
            return new Structure("tree", ToolTypes.Axe, 1);
        }
    }
}
