using Mundus.Data;
using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles.Mobs;

namespace Mundus.Service.SuperLayers {
    public static class HeightController {
        // Order of layers (top to bottom): sky, land, underground

        private static ISuperLayerContext sky = DataBaseContexts.SContext;
        private static ISuperLayerContext land = DataBaseContexts.LContext;
        private static ISuperLayerContext underground = DataBaseContexts.UContext;

        public static ISuperLayerContext GetLayerUnderneath(ISuperLayerContext currentLayer) {
            if (land == currentLayer) {
                return underground;
            }
            if (sky == currentLayer) {
                return land;
            }
            return null;
        }

        public static ISuperLayerContext GetLayerUnderneathMob(MobTile currentMob) {
            return GetLayerUnderneath(currentMob.CurrSuperLayer);
        }

        public static ISuperLayerContext GetLayerAbove(ISuperLayerContext currentLayer) {
            if (underground == currentLayer) {
                return land;
            }
            if (land == currentLayer) {
                return sky;
            }
            return null;
        }

        public static ISuperLayerContext GetLayerAboveMob(MobTile currentMob) {
            return GetLayerAbove(currentMob.CurrSuperLayer);
        }
    }
}
