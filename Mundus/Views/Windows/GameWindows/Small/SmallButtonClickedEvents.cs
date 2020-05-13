namespace Mundus.Views.Windows 
{
    using System;
    using Mundus.Service;

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
                this.React(1);
            }
        }

        protected void OnBtnP2Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(2);
            }
        }

        protected void OnBtnP3Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(3);
            }
        }

        protected void OnBtnP4Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(4);
            }
        }

        protected void OnBtnP5Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(5);
            }
        }

        protected void OnBtnP6Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(6);
            }
        }

        protected void OnBtnP7Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(7);
            }
        }

        protected void OnBtnP8Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(8);
            }
        }

        protected void OnBtnP9Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(9);
            }
        }

        protected void OnBtnP10Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(10);
            }
        }

        protected void OnBtnP11Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(11);
            }
        }

        protected void OnBtnP12Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(12);
            }
        }

        protected void OnBtnP13Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(13);
            }
        }

        protected void OnBtnP14Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(14);
            }
        }

        protected void OnBtnP15Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(15);
            }
        }

        protected void OnBtnP16Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(16);
            }
        }

        protected void OnBtnP17Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(17);
            }
        }

        protected void OnBtnP18Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(18);
            }
        }

        protected void OnBtnP19Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(19);
            }
        }

        protected void OnBtnP20Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(20);
            }
        }

        protected void OnBtnP21Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(21);
            }
        }

        protected void OnBtnP22Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(22);
            }
        }

        protected void OnBtnP23Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(23);
            }
        }

        protected void OnBtnP24Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(24);
            }
        }

        protected void OnBtnP25Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.React(25);
            }
        }

        #endregion

        #region Hotbar buttons

        protected void OnBtnH1Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("hotbar", 0);
                this.PrintMainMenu();
            }
        }

        protected void OnBtnH2Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("hotbar", 1);
                this.PrintMainMenu();
            }
        }

        protected void OnBtnH3Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("hotbar", 2);
                this.PrintMainMenu();
            }
        }

        protected void OnBtnH4Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible)
            {
                this.SelectItem("hotbar", 3);
                this.PrintMainMenu();
            }
        }

        protected void OnBtnH5Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("hotbar", 4);
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
                this.SelectItem("items", 0);
                this.PrintInventory();
            }
        }

        protected void OnBtnI2Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 1);
                this.PrintInventory();
            }
        }

        protected void OnBtnI3Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 2);
                this.PrintInventory();
            }
        }

        protected void OnBtnI4Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 3);
                this.PrintInventory();
            }
        }

        protected void OnBtnI5Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 4);
                this.PrintInventory();
            }
        }

        protected void OnBtnI6Clicked(object sender, EventArgs e)
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 5);
                this.PrintInventory();
            }
        }

        protected void OnBtnI7Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 6);
                this.PrintInventory();
            }
        }

        protected void OnBtnI8Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 7);
                this.PrintInventory();
            }
        }

        protected void OnBtnI9Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 8);
                this.PrintInventory();
            }
        }

        protected void OnBtnI10Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 9);
                this.PrintInventory();
            }
        }

        protected void OnBtnI11Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 10);
                this.PrintInventory();
            }
        }

        protected void OnBtnI12Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 11);
                this.PrintInventory();
            }
        }

        protected void OnBtnI13Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 12);
                this.PrintInventory();
            }
        }

        protected void OnBtnI14Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 13);
                this.PrintInventory();
            }
        }

        protected void OnBtnI15Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 14);
                this.PrintInventory();
            }
        }

        protected void OnBtnI16Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 15);
                this.PrintInventory();
            }
        }

        protected void OnBtnI17Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 16);
                this.PrintInventory();
            }
        }

        protected void OnBtnI18Clicked(object sender, EventArgs e)
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 17);
                this.PrintInventory();
            }
        }

        protected void OnBtnI19Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 18);
                this.PrintInventory();
            }
        }

        protected void OnBtnI20Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 19);
                this.PrintInventory();
            }
        }

        protected void OnBtnI21Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 20);
                this.PrintInventory();
            }
        }

        protected void OnBtnI22Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 21);
                this.PrintInventory();
            }
        }

        protected void OnBtnI23Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 22);
                this.PrintInventory();
            }
        }

        protected void OnBtnI24Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 23);
                this.PrintInventory();
            }
        }

        protected void OnBtnI25Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("items", 24);
                this.PrintInventory();
            }
        }

        #endregion

        #region Accessories buttons

        protected void OnBtnA1Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("accessories", 0);
                this.PrintInventory();
            }
        }

        protected void OnBtnA2Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("accessories", 1);
                this.PrintInventory();
            }
        }

        protected void OnBtnA3Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("accessories", 2);
                this.PrintInventory();
            }
        }

        protected void OnBtnA4Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("accessories", 3);
                this.PrintInventory();
            }
        }

        protected void OnBtnA5Clicked(object sender, EventArgs e)
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("accessories", 4);
                this.PrintInventory();
            }
        }

        protected void OnBtnA6Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("accessories", 5);
                this.PrintInventory();
            }
        }

        protected void OnBtnA7Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("accessories", 6);
                this.PrintInventory();
            }
        }

        protected void OnBtnA8Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("accessories", 7);
                this.PrintInventory();
            }
        }

        protected void OnBtnA9Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("accessories", 8);
                this.PrintInventory();
            }
        }

        protected void OnBtnA10Clicked(object sender, EventArgs e)
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("accessories", 9);
                this.PrintInventory();
            }
        }

        #endregion

        #region Gear buttons
        protected void OnBtnG1Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("gear", 0);
                this.PrintInventory();
            }
        }

        protected void OnBtnG2Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("gear", 1);
                this.PrintInventory();
            }
        }

        protected void OnBtnG3Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("gear", 2);
                this.PrintInventory();
            }
        }

        protected void OnBtnG4Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("gear", 3);
                this.PrintInventory();
            }
        }

        protected void OnBtnG5Clicked(object sender, EventArgs e) 
        {
            if (!WindowController.PauseWindowVisible) 
            {
                this.SelectItem("gear", 4);
                this.PrintInventory();
            }
        }

        #endregion
    }
}
