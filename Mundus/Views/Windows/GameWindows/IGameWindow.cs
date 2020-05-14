﻿namespace Mundus.Views.Windows 
{
    using Mundus.Service.Tiles.Items;

    public interface IGameWindow 
    {
        int Size { get; }

        /// <summary>
        /// Every time the window is closed, this gets called (hides the window)
        /// </summary>
        void OnDeleteEvent(object o, Gtk.DeleteEventArgs args);

        void SetDefaults();

        void PrintWorldScreen();

        void PrintMap();

        void PrintMainMenu();

        void PrintInventory();

        void PrintMapOrInv();

        void PrintSelectedItemInfo(ItemTile itemTile);

        void Show();
    }
}
