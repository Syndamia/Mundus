using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles.Mobs;

namespace Mundus.Service.SuperLayers {
    public static class HeightController {
        // Order of layers (top to bottom): sky, land, underground

        private static ISuperLayer sky = LI.Sky;
        private static ISuperLayer land = LI.Land;
        private static ISuperLayer underground = LI.Underground;

        public static ISuperLayer GetLayerUnderneath(ISuperLayer currentLayer) {
            if (land == currentLayer) {
                return underground;
            }
            if (sky == currentLayer) {
                return land;
            }
            return null;
        }

        public static ISuperLayer GetLayerUnderneathMob(MobTile currentMob) {
            return GetLayerUnderneath(currentMob.CurrSuperLayer);
        }

        public static ISuperLayer GetLayerAbove(ISuperLayer currentLayer) {
            if (underground == currentLayer) {
                return land;
            }
            if (land == currentLayer) {
                return sky;
            }
            return null;
        }

        public static ISuperLayer GetLayerAboveMob(MobTile currentMob) {
            return GetLayerAbove(currentMob.CurrSuperLayer);
        }
    }
}
