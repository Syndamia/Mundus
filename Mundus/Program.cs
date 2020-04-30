using Gtk;
using Mundus.Data.Crafting;
using Mundus.Data.Dialogues;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.SuperLayers;
using Mundus.Data.Windows;
using Mundus.Data;
using Mundus.Service;

namespace Mundus {
    public static class MainClass {
        public static bool runGame = true;

        public static void Main(string[] args) {
            Application.Init();
            //All windows and dialogues that are used by user (instances) are saved and created in WindowInstances.cs
            LogController.Initialize();
            WI.CreateInstances();
            DI.CreateInstances();
            LI.CreateInstances();
            RI.CreateInstances();

            WI.WMain.Show();
            Application.Run();
        }
    }
}
