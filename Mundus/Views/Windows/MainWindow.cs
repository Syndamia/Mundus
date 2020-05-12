namespace Mundus.Views.Windows 
{
    using System;
    using Gtk;
    using Mundus.Service;

    public partial class MainWindow : Gtk.Window 
    {
        public MainWindow() : base(Gtk.WindowType.Toplevel) 
        {
            this.Build();
            this.lblBuild.Text = Mundus.Data.Windows.WI.BuildName;
        }

        protected void OnBtnTutorialClicked(object sender, EventArgs e) 
        {
            // TODO: impliment
        }

        /// <summary>
        /// Every time the window is closed, this gets called (hides the window)
        /// </summary>
        private void OnDeleteEvent(object sender, DeleteEventArgs a) 
        {
            Application.Quit();
        }

        private void OnBtnNewGameClicked(object sender, EventArgs e) 
        {
            WindowController.ShowNewGameWindow(this);
        }

        private void OnBtnSettingsClicked(object sender, EventArgs e) 
        {
            WindowController.ShowSettingsWindow(this);
        }
    }
}