using System;
using Gtk;
using Mundus.Service;

namespace Mundus.Views.Windows {
    public partial class MainWindow : Gtk.Window {
        public MainWindow() : base( Gtk.WindowType.Toplevel ) {
            this.Build();
        }

        private void OnDeleteEvent(object sender, DeleteEventArgs a) {
            Application.Quit();
        }

        private void OnBtnNewGameClicked(object sender, EventArgs e) {
            WindowController.ShowNewGameWindow(this);
        }

        private void OnBtnSettingsClicked(object sender, EventArgs e) {
            WindowController.ShowSettingsWindow(this);
        }

        protected void OnBtnTutorialClicked(object sender, EventArgs e) {
        }
    }
}
