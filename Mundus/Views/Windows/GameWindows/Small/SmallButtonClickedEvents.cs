namespace Mundus.Views.Windows.GameWindows.Small 
{
    using System;
    using Mundus.Service.Windows;
    using static Mundus.Service.Tiles.Mobs.Inventory;

    public partial class SmallGameWindow : Gtk.Window 
    {
        protected void OnBtnIG1Clicked(object sender, EventArgs e) 
        {
            this.PrintMainMenu();
        }

        protected void OnBtnIG2Clicked(object sender, EventArgs e) 
        {
            this.PrintMainMenu();
        }

        protected void OnBtnPauseClicked(object sender, EventArgs e) 
        {
            // Note: pause window blocks player input
            WindowController.ShowPauseWindow();
        }

        protected void OnBtnMusicClicked(object sender, EventArgs e) 
        {
            WindowController.ShowMusicWindow();
        }

        protected void OnBtnCraftingClicked(object sender, EventArgs e) 
        {
            WindowController.ShowCraftingWindow();
        }

        protected void OnBtnMapClicked(object sender, EventArgs e) 
        {
            // Hide inv menu, if it is visible (so only one of the two is visible)
            if (this.InvMenuIsVisible()) 
            { 
                this.OnBtnInvClicked(this, null); 
            }

            if (this.MapMenuIsVisible()) 
            {
                this.SetMapMenuVisibility(false);
            }
            else 
            {
                this.PrintMap();
                this.SetMapMenuVisibility(true);
            }
        }

        protected void OnBtnInvClicked(object sender, EventArgs e) 
        {
            // Hide map menu, if it is visible (so only one of the two is visible)
            if (this.MapMenuIsVisible()) 
            { 
                this.OnBtnMapClicked(this, null); 
            }

            if (btnI1.Visible) 
            {
                this.SetInvMenuVisibility(false);
            }
            else 
            {
                this.PrintInventory();
                this.SetInvMenuVisibility(true);
            }
        }

        #region Screen buttons

        protected void OnBtnP1Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(1);
            }
        }

        protected void OnBtnP2Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(2);
            }
        }

        protected void OnBtnP3Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(3);
            }
        }

        protected void OnBtnP4Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(4);
            }
        }

        protected void OnBtnP5Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(5);
            }
        }

        protected void OnBtnP6Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(6);
            }
        }

        protected void OnBtnP7Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(7);
            }
        }

        protected void OnBtnP8Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(8);
            }
        }

        protected void OnBtnP9Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(9);
            }
        }

        protected void OnBtnP10Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(10);
            }
        }

        protected void OnBtnP11Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(11);
            }
        }

        protected void OnBtnP12Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(12);
            }
        }

        protected void OnBtnP13Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(13);
            }
        }

        protected void OnBtnP14Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(14);
            }
        }

        protected void OnBtnP15Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(15);
            }
        }

        protected void OnBtnP16Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(16);
            }
        }

        protected void OnBtnP17Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(17);
            }
        }

        protected void OnBtnP18Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(18);
            }
        }

        protected void OnBtnP19Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(19);
            }
        }

        protected void OnBtnP20Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(20);
            }
        }

        protected void OnBtnP21Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(21);
            }
        }

        protected void OnBtnP22Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(22);
            }
        }

        protected void OnBtnP23Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(23);
            }
        }

        protected void OnBtnP24Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(24);
            }
        }

        protected void OnBtnP25Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                WindowController.React(25);
            }
        }

        #endregion

        #region Hotbar buttons

        protected void OnBtnH1Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Hotbar, 0);
                this.PrintMainMenu();
            }
        }

        protected void OnBtnH2Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Hotbar, 1);
                this.PrintMainMenu();
            }
        }

        protected void OnBtnH3Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Hotbar, 2);
                this.PrintMainMenu();
            }
        }

        protected void OnBtnH4Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible)
            {
                this.SelectItem(InventoryPlace.Hotbar, 3);
                this.PrintMainMenu();
            }
        }

        protected void OnBtnH5Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Hotbar, 4);
                this.PrintMainMenu();
            }
        }

        protected void OnBtnLogClicked(object sender, EventArgs e) 
        {
            WindowController.ShowLogWindow();
        }

        #endregion

        #region Inventory (items) buttons

        protected void OnBtnI1Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 0);
                this.PrintInventory();
            }
        }

        protected void OnBtnI2Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 1);
                this.PrintInventory();
            }
        }

        protected void OnBtnI3Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 2);
                this.PrintInventory();
            }
        }

        protected void OnBtnI4Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 3);
                this.PrintInventory();
            }
        }

        protected void OnBtnI5Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 4);
                this.PrintInventory();
            }
        }

        protected void OnBtnI6Clicked(object sender, EventArgs e)
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 5);
                this.PrintInventory();
            }
        }

        protected void OnBtnI7Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 6);
                this.PrintInventory();
            }
        }

        protected void OnBtnI8Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 7);
                this.PrintInventory();
            }
        }

        protected void OnBtnI9Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 8);
                this.PrintInventory();
            }
        }

        protected void OnBtnI10Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 9);
                this.PrintInventory();
            }
        }

        protected void OnBtnI11Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 10);
                this.PrintInventory();
            }
        }

        protected void OnBtnI12Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 11);
                this.PrintInventory();
            }
        }

        protected void OnBtnI13Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 12);
                this.PrintInventory();
            }
        }

        protected void OnBtnI14Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 13);
                this.PrintInventory();
            }
        }

        protected void OnBtnI15Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 14);
                this.PrintInventory();
            }
        }

        protected void OnBtnI16Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 15);
                this.PrintInventory();
            }
        }

        protected void OnBtnI17Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 16);
                this.PrintInventory();
            }
        }

        protected void OnBtnI18Clicked(object sender, EventArgs e)
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 17);
                this.PrintInventory();
            }
        }

        protected void OnBtnI19Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 18);
                this.PrintInventory();
            }
        }

        protected void OnBtnI20Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 19);
                this.PrintInventory();
            }
        }

        protected void OnBtnI21Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 20);
                this.PrintInventory();
            }
        }

        protected void OnBtnI22Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 21);
                this.PrintInventory();
            }
        }

        protected void OnBtnI23Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 22);
                this.PrintInventory();
            }
        }

        protected void OnBtnI24Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 23);
                this.PrintInventory();
            }
        }

        protected void OnBtnI25Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Items, 24);
                this.PrintInventory();
            }
        }

        #endregion

        #region Accessories buttons

        protected void OnBtnA1Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Accessories, 0);
                this.PrintInventory();
            }
        }

        protected void OnBtnA2Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Accessories, 1);
                this.PrintInventory();
            }
        }

        protected void OnBtnA3Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Accessories, 2);
                this.PrintInventory();
            }
        }

        protected void OnBtnA4Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Accessories, 3);
                this.PrintInventory();
            }
        }

        protected void OnBtnA5Clicked(object sender, EventArgs e)
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Accessories, 4);
                this.PrintInventory();
            }
        }

        protected void OnBtnA6Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Accessories, 5);
                this.PrintInventory();
            }
        }

        protected void OnBtnA7Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Accessories, 6);
                this.PrintInventory();
            }
        }

        protected void OnBtnA8Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Accessories, 7);
                this.PrintInventory();
            }
        }

        protected void OnBtnA9Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Accessories, 8);
                this.PrintInventory();
            }
        }

        protected void OnBtnA10Clicked(object sender, EventArgs e)
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Accessories, 9);
                this.PrintInventory();
            }
        }

        #endregion

        #region Gear buttons
        protected void OnBtnG1Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Gear, 0);
                this.PrintInventory();
            }
        }

        protected void OnBtnG2Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Gear, 1);
                this.PrintInventory();
            }
        }

        protected void OnBtnG3Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Gear, 2);
                this.PrintInventory();
            }
        }

        protected void OnBtnG4Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Gear, 3);
                this.PrintInventory();
            }
        }

        protected void OnBtnG5Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem(InventoryPlace.Gear, 4);
                this.PrintInventory();
            }
        }

        #endregion
    }
}
