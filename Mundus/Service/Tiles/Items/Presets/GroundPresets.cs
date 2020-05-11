namespace Mundus.Service.Tiles.Items.Presets {
    public static class GroundPresets {
        private static GroundTile sSky = new GroundTile("S_sky", -1, false);
        private static GroundTile lGrass = new GroundTile("L_grass", 1);
        private static GroundTile uRoche = new GroundTile("U_roche", 10);

        public static GroundTile GetSSky() {
            return sSky;
        }

        public static GroundTile GetLGrass() {
            return lGrass;
        }

        public static GroundTile GetURoche() {
            return uRoche;
        }

        public static GroundTile GetFromStock(string stock_id) {
            switch(stock_id) {
                case "S_sky": return GetSSky();
                case "L_grass": return GetLGrass();
                case "U_roche": return GetURoche();
                default: return null;
            }
        }
    }
}
