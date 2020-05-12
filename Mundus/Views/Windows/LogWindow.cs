namespace Mundus.Views.Windows 
{
    using System;
    using Mundus.Service;

    public partial class LogWindow : Gtk.Window 
    {
        /// <summary>
        /// Used for crolling up and down the log messages
        /// </summary>
        private int scroll = 0;

        public LogWindow() : base(Gtk.WindowType.Toplevel) 
        {
            this.Build();
        }

        /// <summary>
        /// Prints all logs it can (starting from most recent) and updates the buttons
        /// </summary>
        public void Initialize() 
        {
            this.PrintLogs();
            this.UpdateButtons();
        }

        /// <summary>
        /// Prints the log messages
        /// </summary>
        public void PrintLogs() 
        {
            for (int i = GameEventLogController.GetCount() - 1 - this.scroll, logIndex = 0; logIndex < 9; logIndex++, i--) 
            {
                string msg = GameEventLogController.GetMessagage(i);

                switch (logIndex) 
                {
                    case 0: this.lblLog1.Text = msg; break;
                    case 1: this.lblLog2.Text = msg; break;
                    case 2: this.lblLog3.Text = msg; break;
                    case 3: this.lblLog4.Text = msg; break;
                    case 4: this.lblLog5.Text = msg; break;
                    case 5: this.lblLog6.Text = msg; break;
                    case 6: this.lblLog7.Text = msg; break;
                    case 7: this.lblLog8.Text = msg; break;
                    case 8: this.lblLog9.Text = msg; break;
                }
            }
        }

        /// <summary>
        /// Every time the window is closed, this gets called (hides the window)
        /// </summary>
        protected void OnDeleteEvent(object o, Gtk.DeleteEventArgs args) 
        {
            args.RetVal = true;
            this.Hide();
        }

        protected void OnBtnNewerClicked(object sender, EventArgs e) 
        {
            this.scroll--;
            this.PrintLogs();

            this.UpdateButtons();
        }

        protected void OnBtnOlderClicked(object sender, EventArgs e) 
        {
            this.scroll++;
            this.PrintLogs();

            this.UpdateButtons();
        }

        /// <summary>
        /// Updates the butNewer and btnOlder sensitivity
        /// </summary>
        private void UpdateButtons() 
        {
            this.btnNewer.Sensitive = this.scroll > 0;
            this.btnOlder.Sensitive = this.scroll < GameEventLogController.GetCount() - 9;
        }
    }
}
