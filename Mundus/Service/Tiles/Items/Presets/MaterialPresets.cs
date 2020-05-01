namespace Mundus.Service.Tiles.Items.Presets {
    public static class MaterialPresets {
        /// <returns>New instance</returns>
        public static Material GetALandRock() {
            return new Material("L_rock");
        }

        /// <returns>New instance</returns>
        public static Material GetALandStick() {
            return new Material("L_stick");
        }

        /// <returns>New instance</returns>
        public static Material GetALandBeefSteak() {
            return new Material("L_beef_steak", 5);
        }

        // <returns>New instance</returns>
        public static Material GetALandMuttonSteak() {
            return new Material("L_mutton_steak", 4);
        }

        /// <summary>
        /// (TEMPORARY)
        /// </summary>
        public static Material GetAStone() {
            return new Material("U_stone");
        }
    }
}
