using System;

namespace Mundus.Models.Mobs.Land_Mobs {
    public static class LMI { //stands for Land Mob Instances
        public static Player Player { get; private set; }

        public static void CreateInstances() {
            Player = new Player("player");
        }
    }
}
