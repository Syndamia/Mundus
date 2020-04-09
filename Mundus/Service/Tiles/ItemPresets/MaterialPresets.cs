using System;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Tiles.ItemPresets {
    public static class MaterialPresets {
        public static Material GetALandRock() {
            return new Material("L_rock");
        }

        public static Material GetAStick() {
            return new Material("L_stick");
        }

        public static Material GetAGrass() {
            return new Material("L_grass");
        }

        public static Material GetAStone() {
            return new Material("U_stone");
        }
    }
}
