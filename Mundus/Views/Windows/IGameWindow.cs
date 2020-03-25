using Mundus.Service.Tiles.Items;

namespace Mundus.Views.Windows {
    public interface IGameWindow {
        int Size { get; }

        //Events that are generated from designer window
        void OnDeleteEvent(object o, Gtk.DeleteEventArgs args);
        void SetDefaults();
        void PrintScreen();
        void PrintMap();
        void PrintMainMenu();
        void PrintSelectedItemInfo(ItemTile itemTile);

        //Stuff that are in Gtk.Window class
        void Show();
    }
}
