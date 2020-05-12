namespace Mundus.Views.Windows 
{
    using System;
    using System.Media;
    using Gtk;

    public partial class MusicWindow : Gtk.Window 
    {
        private SoundPlayer sp;

        public MusicWindow() : base( Gtk.WindowType.Toplevel ) 
        {
            this.Build();
            this.sp = new SoundPlayer();
        }

        /// <summary>
        /// Every time the window is closed, this gets called (hides the window)
        /// </summary>
        protected void OnDeleteEvent(object o, DeleteEventArgs args) 
        {
            this.OnBtnBackClicked(this, null);
            args.RetVal = true;
        }

        protected void OnBtnBackClicked(object sender, EventArgs e) 
        {
            // TODO: resume game loop ?
            this.Hide();
        }

        protected void OnBtnPlayClicked(object sender, EventArgs e) 
        {
            this.sp.SoundLocation = this.fcMusic.Filename;
            this.sp.Play();
        }

        protected void OnFcMusicSelectionChanged(object sender, EventArgs e) 
        {
            this.lblPath.Text = this.fcMusic.Filename;
        }

        protected void OnBtnStopClicked(object sender, EventArgs e) 
        {
            this.sp.Stop();
        }

        protected void OnBtnNextClicked(object sender, EventArgs e) 
        {
            // TODO: impliment
        }
    }
}
