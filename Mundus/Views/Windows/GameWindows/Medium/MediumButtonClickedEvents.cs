namespace Mundus.Views.Windows
{
    using System;
    using Mundus.Service;

    public partial class MediumGameWindow 
    {
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

        protected void OnBtnP26Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(26);
            }
        }

        protected void OnBtnP27Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(27);
            }
        }

        protected void OnBtnP28Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(28);
            }
        }

        protected void OnBtnP29Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(29);
            }
        }

        protected void OnBtnP30Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(30);
            }
        }

        protected void OnBtnP31Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(31);
            }
        }

        protected void OnBtnP32Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(32);
            }
        }

        protected void OnBtnP33Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(33);
            }
        }

        protected void OnBtnP34Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(34);
            }
        }

        protected void OnBtnP35Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(35);
            }
        }

        protected void OnBtnP36Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(36);
            }
        }

        protected void OnBtnP37Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(37);
            }
        }

        protected void OnBtnP38Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(38);
            }
        }

        protected void OnBtnP39Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(39);
            }
        }

        protected void OnBtnP40Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(40);
            }
        }

        protected void OnBtnP41Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(41);
            }
        }

        protected void OnBtnP42Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(42);
            }
        }

        protected void OnBtnP43Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(43);
            }
        }

        protected void OnBtnP44Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(44);
            }
        }

        protected void OnBtnP45Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(45);
            }
        }

        protected void OnBtnP46Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(46);
            }
        }

        protected void OnBtnP47Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(47);
            }
        }

        protected void OnBtnP48Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(48);
            }
        }

        protected void OnBtnP49Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.React(49);
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

        protected void OnBtnH6Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("hotbar", 5);
                this.PrintMainMenu();
            }
        }

        protected void OnBtnH7Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("hotbar", 6);
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

        protected void OnBtnI26Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 25);
                this.PrintInventory();
            }
        }

        protected void OnBtnI27Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 26);
                this.PrintInventory();
            }
        }

        protected void OnBtnI28Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 27);
                this.PrintInventory();
            }
        }

        protected void OnBtnI29Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 28);
                this.PrintInventory();
            }
        }

        protected void OnBtnI30Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 29);
                this.PrintInventory();
            }
        }

        protected void OnBtnI31Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 30);
                this.PrintInventory();
            }
        }

        protected void OnBtnI32Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 31);
                this.PrintInventory();
            }
        }

        protected void OnBtnI33Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 32);
                this.PrintInventory();
            }
        }

        protected void OnBtnI34Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 33);
                this.PrintInventory();
            }
        }

        protected void OnBtnI35Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 34);
                this.PrintInventory();
            }
        }

        protected void OnBtnI36Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 35);
                this.PrintInventory();
            }
        }

        protected void OnBtnI37Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 36);
                this.PrintInventory();
            }
        }

        protected void OnBtnI38Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 37);
                this.PrintInventory();
            }
        }

        protected void OnBtnI39Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 38);
                this.PrintInventory();
            }
        }

        protected void OnBtnI40Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 39);
                this.PrintInventory();
            }
        }

        protected void OnBtnI41Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 40);
                this.PrintInventory();
            }
        }

        protected void OnBtnI42Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 41);
                this.PrintInventory();
            }
        }

        protected void OnBtnI43Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 42);
                this.PrintInventory();
            }
        }

        protected void OnBtnI44Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 43);
                this.PrintInventory();
            }
        }

        protected void OnBtnI45Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 44);
                this.PrintInventory();
            }
        }

        protected void OnBtnI46Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 45);
                this.PrintInventory();
            }
        }

        protected void OnBtnI47Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 46);
                this.PrintInventory();
            }
        }

        protected void OnBtnI48Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 47);
                this.PrintInventory();
            }
        }

        protected void OnBtnI49Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("items", 48);
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

        protected void OnBtnA11Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("accessories", 10);
                this.PrintInventory();
            }
        }

        protected void OnBtnA12Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("accessories", 11);
                this.PrintInventory();
            }
        }

        protected void OnBtnA13Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("accessories", 12);
                this.PrintInventory();
            }
        }

        protected void OnBtnA14Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("accessories", 13);
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

        protected void OnBtnG6Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("gear", 5);
                this.PrintInventory();
            }
        }

        protected void OnBtnG7Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem("gear", 6);
                this.PrintInventory();
            }
        }

        #endregion
    }
}
