using System;
using Mundus.Service;

namespace Mundus.Views.Windows {
    public partial class LogWindow : Gtk.Window {
        public LogWindow() :
                base(Gtk.WindowType.Toplevel) {
            this.Build();

        }

        public void Initialize() {
            PrintLogs();
            UpdateButtons();
        }

        protected void OnDeleteEvent(object o, Gtk.DeleteEventArgs args) {
            args.RetVal = true;
            this.Hide();
        }

        private int scroll = 0;

        public void PrintLogs() {
            for (int i = LogController.GetCount() - 1 - scroll, logIndex = 0; logIndex < 9; logIndex++, i--) {
                string msg = LogController.GetMessagage(i);

                switch (logIndex) {
                    case 0: lblLog1.Text = msg; break;
                    case 1: lblLog2.Text = msg; break;
                    case 2: lblLog3.Text = msg; break;
                    case 3: lblLog4.Text = msg; break;
                    case 4: lblLog5.Text = msg; break;
                    case 5: lblLog6.Text = msg; break;
                    case 6: lblLog7.Text = msg; break;
                    case 7: lblLog8.Text = msg; break;
                    case 8: lblLog9.Text = msg; break;
                }
            }
        }

        protected void OnBtnNewerClicked(object sender, EventArgs e) {
            scroll--;
            PrintLogs();
            UpdateButtons();
        }

        protected void OnBtnOlderClicked(object sender, EventArgs e) {
            scroll++;
            PrintLogs();
            UpdateButtons();
        }

        private void UpdateButtons() {
            btnNewer.Sensitive = scroll > 0;
            btnOlder.Sensitive = scroll < LogController.GetCount() - 9;
        }
    }
}
