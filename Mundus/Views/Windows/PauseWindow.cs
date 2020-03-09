﻿using System;
using Gtk;
using Mundus.Service;

namespace Mundus.Views.Windows {
    public partial class PauseWindow : Gtk.Window {
        public IGameWindow GameWindow { get; set; }

        public PauseWindow() : base( Gtk.WindowType.Toplevel ) {
            this.Build();
        }

        protected void OnDeleteEvent(object o, Gtk.DeleteEventArgs args) {
            this.OnBtnBackClicked(this, null);
            args.RetVal = true;
        }

        protected void OnBtnBackClicked(object sender, EventArgs e) {
            WindowController.PauseWindowVisible = false;
            this.Hide();
        }

        protected void OnBtnSettingsClicked(object sender, EventArgs e) {
            WindowController.ShowSettingsWindow(this);
        }

        protected void OnBtnSaveClicked(object sender, EventArgs e) {
            //TODO: call saving code
            this.OnDeleteEvent(this, new DeleteEventArgs());
        }

        protected void OnBtnSaveExitClicked(object sender, EventArgs e) {
            //TODO: call saving code
            this.GameWindow.OnDeleteEvent(this, new DeleteEventArgs());
        }

        protected void OnBtnExitClicked(object sender, EventArgs e) {
            this.GameWindow.OnDeleteEvent(this, new DeleteEventArgs());
        }
    }
}
