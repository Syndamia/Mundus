using System;
using Gtk;
using Mundus.Service.Tiles.Items;

namespace Mundus.Views.Windows {
    public partial class LargeGameWindow : Gtk.Window, IGameWindow {
        public int Size { get; private set; }

        public LargeGameWindow() : base( Gtk.WindowType.Toplevel ) {
            this.Build();
        }

        public void OnDeleteEvent(object o, DeleteEventArgs args) {
            throw new NotImplementedException();
        }

        public void PrintAll() {
            throw new NotImplementedException();
        }

        public void PrintMainMenu() {
            throw new NotImplementedException();
        }

        public void PrintMap() {
            throw new NotImplementedException();
        }

        public void PrintScreen() {
            throw new NotImplementedException();
        }

        public void SetDefaults() {
            throw new NotImplementedException();
        }

        public void PrintSelectedItemInfo(ItemTile itemTile) {
            throw new NotImplementedException();
        }
    }
}
