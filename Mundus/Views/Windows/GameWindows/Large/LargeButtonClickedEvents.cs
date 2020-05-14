namespace Mundus.Views.Windows.GameWindows.Large 
{
    using System;
    using Mundus.Service.Windows;
    using static Mundus.Service.Tiles.Mobs.Inventory;

    public partial class LargeGameWindow 
    {
        protected void OnBtnMapClicked(object sender, EventArgs e)  
        {
            //Hide inv menu, if it is visible (so only one of the two is visible)
            if (this.InvMenuIsVisible()) this.OnBtnInvClicked(this, null);

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
            //Hide map menu, if it is visible (so only one of the two is visible)
            if (this.MapMenuIsVisible()) this.OnBtnMapClicked(this, null);

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

        protected void OnBtnP26Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(26);
            }
        }

        protected void OnBtnP27Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(27);
            }
        }

        protected void OnBtnP28Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(28);
            }
        }

        protected void OnBtnP29Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(29);
            }
        }

        protected void OnBtnP30Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(30);
            }
        }

        protected void OnBtnP31Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(31);
            }
        }

        protected void OnBtnP32Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(32);
            }
        }

        protected void OnBtnP33Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(33);
            }
        }

        protected void OnBtnP34Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(34);
            }
        }

        protected void OnBtnP35Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(35);
            }
        }

        protected void OnBtnP36Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(36);
            }
        }

        protected void OnBtnP37Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(37);
            }
        }

        protected void OnBtnP38Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(38);
            }
        }

        protected void OnBtnP39Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(39);
            }
        }

        protected void OnBtnP40Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(40);
            }
        }

        protected void OnBtnP41Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(41);
            }
        }

        protected void OnBtnP42Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(42);
            }
        }

        protected void OnBtnP43Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(43);
            }
        }

        protected void OnBtnP44Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(44);
            }
        }

        protected void OnBtnP45Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(45);
            }
        }

        protected void OnBtnP46Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(46);
            }
        }

        protected void OnBtnP47Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(47);
            }
        }

        protected void OnBtnP48Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(48);
            }
        }

        protected void OnBtnP49Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(49);
            }
        }

        protected void OnBtnP50Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(50);
            }
        }

        protected void OnBtnP51Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(51);
            }
        }

        protected void OnBtnP52Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(52);
            }
        }

        protected void OnBtnP53Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(53);
            }
        }

        protected void OnBtnP54Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(54);
            }
        }

        protected void OnBtnP55Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(55);
            }
        }

        protected void OnBtnP56Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(56);
            }
        }

        protected void OnBtnP57Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(57);
            }
        }

        protected void OnBtnP58Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(58);
            }
        }

        protected void OnBtnP59Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(59);
            }
        }

        protected void OnBtnP60Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(60);
            }
        }

        protected void OnBtnP61Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(61);
            }
        }

        protected void OnBtnP62Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(62);
            }
        }

        protected void OnBtnP63Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(63);
            }
        }

        protected void OnBtnP64Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(64);
            }
        }

        protected void OnBtnP65Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(65);
            }
        }

        protected void OnBtnP66Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(66);
            }
        }

        protected void OnBtnP67Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(67);
            }
        }

        protected void OnBtnP68Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(68);
            }
        }

        protected void OnBtnP69Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(69);
            }
        }

        protected void OnBtnP70Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(70);
            }
        }

        protected void OnBtnP71Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(71);
            }
        }

        protected void OnBtnP72Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(72);
            }
        }

        protected void OnBtnP73Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(73);
            }
        }

        protected void OnBtnP74Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(74);
            }
        }

        protected void OnBtnP75Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(75);
            }
        }

        protected void OnBtnP76Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(76);
            }
        }

        protected void OnBtnP77Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(77);
            }
        }

        protected void OnBtnP78Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(78);
            }
        }

        protected void OnBtnP79Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(79);
            }
        }

        protected void OnBtnP80Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(80);
            }
        }

        protected void OnBtnP81Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                WindowController.React(81);
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

        protected void OnBtnH6Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Hotbar, 5);
                this.PrintMainMenu();
            }
        }

        protected void OnBtnH7Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Hotbar, 6);
                this.PrintMainMenu();
            }
        }

        protected void OnBtnH8Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Hotbar, 7);
                this.PrintMainMenu();
            }
        }

        protected void OnBtnH9Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Hotbar, 8);
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

        protected void OnBtnI26Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 25);
                this.PrintInventory();
            }
        }

        protected void OnBtnI27Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 26);
                this.PrintInventory();
            }
        }

        protected void OnBtnI28Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 27);
                this.PrintInventory();
            }
        }

        protected void OnBtnI29Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 28);
                this.PrintInventory();
            }
        }

        protected void OnBtnI30Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 29);
                this.PrintInventory();
            }
        }

        protected void OnBtnI31Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 30);
                this.PrintInventory();
            }
        }

        protected void OnBtnI32Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 31);
                this.PrintInventory();
            }
        }

        protected void OnBtnI33Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 32);
                this.PrintInventory();
            }
        }

        protected void OnBtnI34Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 33);
                this.PrintInventory();
            }
        }

        protected void OnBtnI35Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 34);
                this.PrintInventory();
            }
        }

        protected void OnBtnI36Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 35);
                this.PrintInventory();
            }
        }

        protected void OnBtnI37Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 36);
                this.PrintInventory();
            }
        }

        protected void OnBtnI38Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 37);
                this.PrintInventory();
            }
        }

        protected void OnBtnI39Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 38);
                this.PrintInventory();
            }
        }

        protected void OnBtnI40Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 39);
                this.PrintInventory();
            }
        }

        protected void OnBtnI41Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 40);
                this.PrintInventory();
            }
        }

        protected void OnBtnI42Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 41);
                this.PrintInventory();
            }
        }

        protected void OnBtnI43Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 42);
                this.PrintInventory();
            }
        }

        protected void OnBtnI44Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 43);
                this.PrintInventory();
            }
        }

        protected void OnBtnI45Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 44);
                this.PrintInventory();
            }
        }

        protected void OnBtnI46Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 45);
                this.PrintInventory();
            }
        }

        protected void OnBtnI47Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 46);
                this.PrintInventory();
            }
        }

        protected void OnBtnI48Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 47);
                this.PrintInventory();
            }
        }

        protected void OnBtnI49Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 48);
                this.PrintInventory();
            }
        }

        protected void OnBtnI50Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 49);
                this.PrintInventory();
            }
        }

        protected void OnBtnI51Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 50);
                this.PrintInventory();
            }
        }

        protected void OnBtnI52Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 51);
                this.PrintInventory();
            }
        }

        protected void OnBtnI53Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 52);
                this.PrintInventory();
            }
        }

        protected void OnBtnI54Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 53);
                this.PrintInventory();
            }
        }

        protected void OnBtnI55Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 54);
                this.PrintInventory();
            }
        }

        protected void OnBtnI56Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 55);
                this.PrintInventory();
            }
        }

        protected void OnBtnI57Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 56);
                this.PrintInventory();
            }
        }

        protected void OnBtnI58Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 57);
                this.PrintInventory();
            }
        }

        protected void OnBtnI59Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 58);
                this.PrintInventory();
            }
        }

        protected void OnBtnI60Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 59);
                this.PrintInventory();
            }
        }

        protected void OnBtnI61Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 60);
                this.PrintInventory();
            }
        }

        protected void OnBtnI62Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 61);
                this.PrintInventory();
            }
        }

        protected void OnBtnI63Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 62);
                this.PrintInventory();
            }
        }

        protected void OnBtnI64Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 63);
                this.PrintInventory();
            }
        }

        protected void OnBtnI65Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 64);
                this.PrintInventory();
            }
        }

        protected void OnBtnI66Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 65);
                this.PrintInventory();
            }
        }

        protected void OnBtnI67Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 66);
                this.PrintInventory();
            }
        }

        protected void OnBtnI68Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 67);
                this.PrintInventory();
            }
        }

        protected void OnBtnI69Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 68);
                this.PrintInventory();
            }
        }

        protected void OnBtnI70Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 69);
                this.PrintInventory();
            }
        }

        protected void OnBtnI71Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 70);
                this.PrintInventory();
            }
        }

        protected void OnBtnI72Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 71);
                this.PrintInventory();
            }
        }

        protected void OnBtnI73Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 72);
                this.PrintInventory();
            }
        }

        protected void OnBtnI74Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 73);
                this.PrintInventory();
            }
        }

        protected void OnBtnI75Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 74);
                this.PrintInventory();
            }
        }

        protected void OnBtnI76Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 75);
                this.PrintInventory();
            }
        }

        protected void OnBtnI77Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 76);
                this.PrintInventory();
            }
        }

        protected void OnBtnI78Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 77);
                this.PrintInventory();
            }
        }

        protected void OnBtnI79Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 78);
                this.PrintInventory();
            }
        }

        protected void OnBtnI80Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 79);
                this.PrintInventory();
            }
        }

        protected void OnBtnI81Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Items, 80);
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

        protected void OnBtnA11Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Accessories, 10);
                this.PrintInventory();
            }
        }

        protected void OnBtnA12Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Accessories, 11);
                this.PrintInventory();
            }
        }

        protected void OnBtnA13Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Accessories, 12);
                this.PrintInventory();
            }
        }

        protected void OnBtnA14Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Accessories, 13);
                this.PrintInventory();
            }
        }

        protected void OnBtnA15Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Accessories, 14);
                this.PrintInventory();
            }
        }

        protected void OnBtnA16Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Accessories, 15);
                this.PrintInventory();
            }
        }

        protected void OnBtnA17Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Accessories, 16);
                this.PrintInventory();
            }
        }

        protected void OnBtnA18Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Accessories, 17);
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

        protected void OnBtnG6Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Gear, 5);
                this.PrintInventory();
            }
        }

        protected void OnBtnG7Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Gear, 6);
                this.PrintInventory();
            }
        }

        protected void OnBtnG8Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Gear, 7);
                this.PrintInventory();
            }
        }

        protected void OnBtnG9Clicked(object sender, EventArgs e)  
        {
            if (!WindowController.PauseWindowVisible)  
            {
                this.SelectItem(InventoryPlace.Gear, 8);
                this.PrintInventory();
            }
        }

        #endregion
    }
}
