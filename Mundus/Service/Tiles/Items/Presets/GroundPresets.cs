namespace Mundus.Service.Tiles.Items.Presets {
    public static class GroundPresets {
        /// <summary>
        /// Returns a new instance of the sky ground tile
        /// </summary>
        public static GroundTile GetASSky() {
            return new GroundTile("S_sky", -1, false);
        }

        /// <summary>
        /// Returns a new instance of the land grass ground tile
        /// </summary>
        public static GroundTile GetALGrass() {
            return new GroundTile("L_grass", 1);
        }

        /// <summary>
        /// Returns a new instance of the underground roche ground tile
        /// </summary>
        public static GroundTile GetAURoche() {
            return new GroundTile("U_roche", 10);
        }
    }
}
