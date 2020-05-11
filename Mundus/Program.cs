using Gtk;
using Mundus.Data;
using Mundus.Data.Crafting;
using Mundus.Data.Dialogues;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.SuperLayers;
using Mundus.Data.Windows;

namespace Mundus {
    public static class MainClass {
        public static bool runGame = true;

        public static void Main(string[] args) {
            DataBaseContexts.CreateInstances();
            Application.Init();
            //All windows and dialogues that are used by user (instances) are saved and created in WindowInstances.cs
            WI.CreateInstances();
            DI.CreateInstances();

            WI.WMain.Show();
            Application.Run();
        }
    }
}
