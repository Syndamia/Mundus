﻿using System;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Tiles.ItemPresets {
    public static class MaterialPresets {
        public static Material GetALandRock() {
            return new Material("land_rock");
        }

        public static Material GetAStick() {
            return new Material("stick");
        }
    }
}
