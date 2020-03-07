using System;
using Mundus.Models.SuperLayers;

namespace Mundus.Models.Tiles {
    public static class LI { //stands for Layer Instances
        //add other layers
        public static Land Land { get; private set; }

        public static void CreateInstances() {
            Land = new Land();
        }
    }
}
