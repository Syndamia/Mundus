namespace Mundus.Data.SuperLayers {
    public static class LI { //stands for Layer Instances
        //add other layers
        public static Land Land { get; private set; }
        public static Underground Underground { get; private set;}

        public static void CreateInstances() {
            Land = new Land();
            Underground = new Underground();
        }
    }
}
