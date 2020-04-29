using Mundus.Views.Windows;

namespace Mundus.Data.Windows {
    public static class WI { //stands for Window Instances
        public const string BuildName = "Build 29-04-2020 No2";

        public static IGameWindow SelWin { get; set; }

        public static MainWindow WMain { get; private set; }
        public static NewGameWindow WNewGame { get; private set; }
        public static SmallGameWindow WSGame { get; private set; }
        public static MediumGameWindow WMGame { get; private set; }
        public static LargeGameWindow WLGame { get; private set; }
        public static SettingsWindow WSettings { get; private set; }
        public static PauseWindow WPause { get; private set; }
        public static MusicWindow WMusic { get; private set; }
        public static CraftingWindow WCrafting { get; private set; }

        //Gtk opens all window instances in the project automatically, unless they are hidden
        public static void CreateInstances() {
            WMain = new MainWindow();
            WMain.Hide();
            WNewGame = new NewGameWindow();
            WNewGame.Hide();
            WSGame = new SmallGameWindow();
            WSGame.Hide();
            WMGame = new MediumGameWindow();
            WMGame.Hide();
            WLGame = new LargeGameWindow();
            WLGame.Hide();
            WSettings = new SettingsWindow();
            WSettings.Hide();
            WPause = new PauseWindow();
            WPause.Hide();
            WMusic = new MusicWindow();
            WMusic.Hide();
            WCrafting = new CraftingWindow();
            WCrafting.Hide();
        }
    }
}
