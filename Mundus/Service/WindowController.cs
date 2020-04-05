using Gtk;
using Mundus.Data.Windows;

namespace Mundus.Service {
    public static class WindowController {
        public static void ShowSettingsWindow(Window sender) {
           sender.Hide();
           WI.WSettings.Show(sender);
        }

        public static void ShowNewGameWindow(Window sender) {
            sender.Hide();
            WI.WNewGame.SetDefaults();
            WI.WNewGame.Show();
        }

        public static void ShowMainWindow(Window sender) {
            sender.Hide();
            WI.WMain.Show();
        }

        public static bool PauseWindowVisible { get; set; }

        public static void ShowPauseWindow() {
            WI.WPause.Show();
            WI.WPause.Present();
            PauseWindowVisible = true;
        }

        public static void ShowMusicWindow() {
            WI.WMusic.Show();
            WI.WMusic.Present();
        }

        public static void ShowCraftingWindow() {
            WI.WCrafting.Initialize();
            WI.WCrafting.Show();
            WI.WCrafting.Present();
        }
    }
}
