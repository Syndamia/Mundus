using Gtk;
using Mundus.Data.Crafting;
using Mundus.Data.Dialogues;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.SuperLayers;
using Mundus.Data.Windows;

namespace Mundus {
    public static class MainClass {
        public static bool runGame = true;

        public static void Main(string[] args) {
            Application.Init();
            //All windows that are used by user (instances) are saved and created in WindowInstances.cs
            WI.CreateInstances();
            DI.CreateInstances();
            LI.CreateInstances();
            LMI.CreateInstances( 1 );
            RI.CreateInstances();

            WI.WMain.Show();
            Application.Run();
        }
    }
}
