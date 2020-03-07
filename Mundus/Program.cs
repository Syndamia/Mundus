using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Gtk;
using Mundus.Models;
using Mundus.Models.Mobs.Land_Mobs;
using Mundus.Models.Tiles;
using Mundus.Views.Windows;

namespace Mundus {
    public static class MainClass {
        public static bool runGame = true;

        public static void Main(string[] args) {
            Initialize();
        }

        private static void Initialize() {
            Application.Init();
            //All windows that are used by user (instances) are saved and created in WindowInstances.cs
            WI.CreateInstances();
            DI.CreateInstances();
            LI.CreateInstances();
            LMI.CreateInstances();

            WI.WMain.Show();
            Application.Run();
        }

        public static void RunGameLoop() {
            while (runGame) {
                WI.WSGame.PrintScreen();
                Thread.Sleep( 100 );
            }
        }
    }
}
