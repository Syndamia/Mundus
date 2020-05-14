namespace Mundus.Views.Windows 
{
    using System;
    using Gtk;
    using Mundus.Service.Windows;

    public partial class PauseWindow : Gtk.Window 
    {
        public PauseWindow() : base(Gtk.WindowType.Toplevel) 
        {
            this.Build();
            this.lblBuild.Text = Mundus.Data.Windows.WI.BuildName;
        }

        /// <summary>
        /// Gets or sets the game window that opened the pause window (see OnBtnExitClicked)
        /// </summary>
        public IGameWindow GameWindow { get; set; }

        /// <summary>
        /// Every time the window is closed, this gets called (hides the window)
        /// </summary>
        protected void OnDeleteEvent(object o, Gtk.DeleteEventArgs args) 
        {
            WindowController.PauseWindowVisible = false;
            this.Hide();
            args.RetVal = true;
        }

        protected void OnBtnSettingsClicked(object sender, EventArgs e) 
        {
            WindowController.ShowSettingsWindow(this);
        }

        /// <summary>
        /// Saves the game state (map and inventories) and closes the pause window
        /// </summary>
        protected void OnBtnSaveClicked(object sender, EventArgs e) 
        {
            // TODO: call saving code
            this.OnDeleteEvent(this, new DeleteEventArgs());
        }

        /// <summary>
        /// Saves the game, closes the window and also closes the window that opened it
        /// </summary>
        protected void OnBtnSaveExitClicked(object sender, EventArgs e) 
        {
            this.OnBtnSaveClicked(null, null);
            this.GameWindow.OnDeleteEvent(this, new DeleteEventArgs());
        }

        /// <summary>
        /// Closes the window and also closes the window that opened it
        /// </summary>
        protected void OnBtnExitClicked(object sender, EventArgs e) 
        {
            this.GameWindow.OnDeleteEvent(this, new DeleteEventArgs());
        }
    }
}
