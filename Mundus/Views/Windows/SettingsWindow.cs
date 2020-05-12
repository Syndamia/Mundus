namespace Mundus.Views.Windows 
{
    using Gtk;

    public partial class SettingsWindow : Gtk.Window 
    {
        public SettingsWindow() : base(Gtk.WindowType.Toplevel) 
        {
            this.Build();
        }

        /// <summary>
        /// This is used to show the sender (the window that opened this one) when you close this window
        /// </summary>
        public Window Sender { get; private set; }

        public void Show(Window sender) 
        {
            this.Show();
            this.Sender = sender;
        }

        protected void OnDeleteEvent(object sender, DeleteEventArgs a) 
        {
            // Return to the sender window (and dont destroy the settings window instance)
            this.Hide();
            this.Sender.Show();
            a.RetVal = true;
        }
    }
}
