using Gtk;
using Mundus.Data.Windows;

namespace Mundus.Service {
    public static class WindowController {
        /// <summary>
        /// Shows the settings window and hides the sender
        /// </summary>
        public static void ShowSettingsWindow(Window sender) {
           sender.Hide();
           WI.WSettings.Show(sender);
        }

        /// <summary>
        /// Shows the new game window, sets it's default values and hides the sender
        /// </summary>
        public static void ShowNewGameWindow(Window sender) {
            sender.Hide();
            WI.WNewGame.SetDefaults();
            WI.WNewGame.Show();
        }

        /// <summary>
        /// Shows the main window and hides the sender
        /// </summary>
        public static void ShowMainWindow(Window sender) {
            sender.Hide();
            WI.WMain.Show();
        }

        public static bool PauseWindowVisible { get; set; }

        /// <summary>
        /// Shows the pause window on top of all windows and "pauses" game input (bool PauseWindowVisible)
        /// </summary>
        public static void ShowPauseWindow() {
            WI.WPause.Show();
            WI.WPause.Present();
            PauseWindowVisible = true;
        }

        /// <summary>
        /// Shows the music window on top of all windows
        /// </summary>
        public static void ShowMusicWindow() {
            WI.WMusic.Show();
            WI.WMusic.Present();
        }

        /// <summary>
        /// Shows the crafting window on top of all windows and does initializes it
        /// </summary>
        public static void ShowCraftingWindow() {
            WI.WCrafting.Initialize();
            WI.WCrafting.Show();
            WI.WCrafting.Present();
        }
    }
}
