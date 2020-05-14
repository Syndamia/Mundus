namespace Mundus.Data.Windows 
{
    using Mundus.Views.Windows;
    using Mundus.Views.Windows.GameWindows.Large;
    using Mundus.Views.Windows.GameWindows.Medium;
    using Mundus.Views.Windows.GameWindows.Small;

    /// <summary>
    /// Used to store universally accessed windows
    /// </summary>
    public static class WI 
    {
        /// <summary>
        /// Full name of the build that is used in MainMenu and Pause windows
        /// </summary>
        public const string BuildName = "Requirements Build";

        /// <summary>
        /// Gets or sets the selected game window (should be WSGame, WMGame or WLGame)
        /// </summary>
        /// <value>The sel window.</value>
        public static IGameWindow SelWin { get; set; }

        /// <summary>
        /// Gets the main window
        /// </summary>
        public static MainWindow WMain { get; private set; }

        /// <summary>
        /// Gets the new game window
        /// </summary>
        public static NewGameWindow WNewGame { get; private set; }

        /// <summary>
        /// Gets the small (sized) game window
        /// </summary>
        public static SmallGameWindow WSGame { get; private set; }

        /// <summary>
        /// Gets the medium (sized) window
        /// </summary>
        public static MediumGameWindow WMGame { get; private set; }

        /// <summary>
        /// Gets the large (sized) window
        /// </summary>
        public static LargeGameWindow WLGame { get; private set; }

        /// <summary>
        /// Gets the settings window
        /// </summary>
        public static SettingsWindow WSettings { get; private set; }

        /// <summary>
        /// Gets the pause window
        /// </summary>
        public static PauseWindow WPause { get; private set; }

        /// <summary>
        /// Gets the music window
        /// </summary>
        public static MusicWindow WMusic { get; private set; }

        /// <summary>
        /// Gets the crafting window
        /// </summary>
        public static CraftingWindow WCrafting { get; private set; }

        /// <summary>
        /// Gets the log window
        /// </summary>
        public static LogWindow WLog { get; private set; }

        /// <summary>
        /// Creates all instances of the windows and hides them
        /// Gtk opens all window instances in the project automatically, unless they are hidden
        /// </summary>
        public static void CreateInstances()
        {
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

            WLog = new LogWindow();
            WLog.Hide();
        }
    }
}
