using Gtk;
using Mundus.Service.Tiles.Items;

namespace Mundus.Views.Windows {
    public partial class CraftingWindow : Gtk.Window {
        public CraftingWindow() : base( Gtk.WindowType.Toplevel ) {
            this.Build();
        }



        private void Reset() {
            lblC1.Text = "0";
            lblC2.Text = "0";
            lblC3.Text = "0";
            lblC4.Text = "0";
            lblC5.Text = "0";

            imgI1.IconSet = null;
            imgI2.IconSet = null;
            imgI3.IconSet = null;
            imgI4.IconSet = null;
            imgI5.IconSet = null;

            imgItem.IconSet = null;
            lblInfo.Text = null;
            btnPrev.Sensitive = false;
            btnNext.Sensitive = false;
        }
    }
}
