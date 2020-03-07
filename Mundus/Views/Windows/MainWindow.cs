using System;
using Gtk;
using Mundus.Models;

namespace Mundus.Views.Windows {
    public partial class MainWindow : Gtk.Window {
        public MainWindow() : base( Gtk.WindowType.Toplevel ) {
            this.Build();
        }

        private void OnDeleteEvent(object sender, DeleteEventArgs a) {
            Application.Quit();
        }

        private void OnBtnNewGameClicked(object sender, EventArgs e) {
            this.Hide();
            WI.WNewGame.SetDefaults();
            WI.WNewGame.Show();
        }

        private void OnBtnSettingsClicked(object sender, EventArgs e) {
            this.Hide();
            WI.WSettings.Show(this);
        }

        protected void OnBtnTutorialClicked(object sender, EventArgs e) {
        }
    }
}
