using System;
using Gtk;
using Mundus.Service;
using Mundus.Service.Mobs;
using Mundus.Service.SuperLayers;
using Mundus.Service.Tiles.Items;

namespace Mundus.Views.Windows {
    public partial class SmallGameWindow : Gtk.Window, IGameWindow {
        /*Value for the height and width of the game screen, map screens and inventory screen
         *and the width of stats, hotbar, accessories, gear & items on the ground menus*/
        public int Size { get; private set; }

        public SmallGameWindow() : base( Gtk.WindowType.Toplevel ) {
            this.Build();
        }

        public void OnDeleteEvent(object o, Gtk.DeleteEventArgs args) {
            //Open exit dialogue if you haven't saved in a while
            //if () { //TODO: check if you have saved
            //    //TODO: pause game cycle

            //    ResponseType rt = (ResponseType)DI.DExit.Run();
            //    DI.DExit.Hide();

            //    if(rt == ResponseType.Cancel || rt == ResponseType.DeleteEvent) {
            //        //cancel the exit procedure and keep the window open
            //        args.RetVal = true;
            //        return;
            //    }
            //    else if (rt == ResponseType.Accept) {
            //        //TODO: call code for saving the game
            //    }
            //}

            Application.Quit();
        }

        public void SetDefaults() {
            this.Size = 5;
            this.SetMapMenuVisibility(false);
            this.SetInvMenuVisibility(false);
        }

        protected void OnBtnPauseClicked(object sender, EventArgs e) {
            //TODO: add code that stops (pauses) game cycle
            WindowController.ShowPauseWindow();
        }

        protected void OnBtnMapClicked(object sender, EventArgs e) {
            //Hide inv menu, if it is visible (so only one of the two is visible)
            if (this.InvMenuIsVisible()) this.OnBtnInvClicked(this, null);

            if (this.MapMenuIsVisible()) {
                this.SetMapMenuVisibility(false);
            } else {
                this.PrintMap();
                this.SetMapMenuVisibility(true);
            }
        }

        private void SetMapMenuVisibility(bool isVisible) {
            lblGroundLayer.Visible = isVisible;
            imgG1.Visible = isVisible;
            imgG2.Visible = isVisible;
            imgG3.Visible = isVisible;
            imgG4.Visible = isVisible;
            imgG5.Visible = isVisible;
            imgG6.Visible = isVisible;
            imgG7.Visible = isVisible;
            imgG8.Visible = isVisible;
            imgG9.Visible = isVisible;
            imgG10.Visible = isVisible;
            imgG11.Visible = isVisible;
            imgG12.Visible = isVisible;
            imgG13.Visible = isVisible;
            imgG14.Visible = isVisible;
            imgG15.Visible = isVisible;
            imgG16.Visible = isVisible;
            imgG17.Visible = isVisible;
            imgG18.Visible = isVisible;
            imgG19.Visible = isVisible;
            imgG20.Visible = isVisible;
            imgG21.Visible = isVisible;
            imgG22.Visible = isVisible;
            imgG23.Visible = isVisible;
            imgG24.Visible = isVisible;
            imgG25.Visible = isVisible;

            lblSuperLayer.Visible = isVisible;
            lblCoord1.Visible = isVisible;
            lblCoord2.Visible = isVisible;

            lblItemLayer.Visible = isVisible;
            imgI1.Visible = isVisible;
            imgI2.Visible = isVisible;
            imgI3.Visible = isVisible;
            imgI4.Visible = isVisible;
            imgI5.Visible = isVisible;
            imgI6.Visible = isVisible;
            imgI7.Visible = isVisible;
            imgI8.Visible = isVisible;
            imgI9.Visible = isVisible;
            imgI10.Visible = isVisible;
            imgI11.Visible = isVisible;
            imgI12.Visible = isVisible;
            imgI13.Visible = isVisible;
            imgI14.Visible = isVisible;
            imgI15.Visible = isVisible;
            imgI16.Visible = isVisible;
            imgI17.Visible = isVisible;
            imgI18.Visible = isVisible;
            imgI19.Visible = isVisible;
            imgI20.Visible = isVisible;
            imgI21.Visible = isVisible;
            imgI22.Visible = isVisible;
            imgI23.Visible = isVisible;
            imgI24.Visible = isVisible;
            imgI25.Visible = isVisible;

            lblHoleMsg.Visible = isVisible;
            lblHoleOnTop.Visible = isVisible;

            lblBlank5.Visible = isVisible;
        }

        private bool MapMenuIsVisible() {
            return imgG1.Visible;
        }

        protected void OnBtnInvClicked(object sender, EventArgs e) {
            //Hide map menu, if it is visible (so only one of the two is visible)
            if (this.MapMenuIsVisible()) this.OnBtnMapClicked(this, null);

            if (btnI1.Visible) {
                this.SetInvMenuVisibility(false);
            } else {
                this.PrintInventory();
                this.SetInvMenuVisibility(true);
            }
        }

        private void SetInvMenuVisibility(bool isVisible) {
            btnI1.Visible = isVisible;
            btnI2.Visible = isVisible;
            btnI3.Visible = isVisible;
            btnI4.Visible = isVisible;
            btnI5.Visible = isVisible;
            btnI6.Visible = isVisible;
            btnI7.Visible = isVisible;
            btnI8.Visible = isVisible;
            btnI9.Visible = isVisible;
            btnI10.Visible = isVisible;
            btnI11.Visible = isVisible;
            btnI12.Visible = isVisible;
            btnI13.Visible = isVisible;
            btnI14.Visible = isVisible;
            btnI15.Visible = isVisible;
            btnI16.Visible = isVisible;
            btnI17.Visible = isVisible;
            btnI18.Visible = isVisible;
            btnI19.Visible = isVisible;
            btnI20.Visible = isVisible;
            btnI21.Visible = isVisible;
            btnI22.Visible = isVisible;
            btnI23.Visible = isVisible;
            btnI24.Visible = isVisible;
            btnI25.Visible = isVisible;
            btnCrafting.Visible = isVisible;

            lblAccessories.Visible = isVisible;
            btnA1.Visible = isVisible;
            btnA2.Visible = isVisible;
            btnA3.Visible = isVisible;
            btnA4.Visible = isVisible;
            btnA5.Visible = isVisible;
            btnA6.Visible = isVisible;
            btnA7.Visible = isVisible;
            btnA8.Visible = isVisible;
            btnA9.Visible = isVisible;
            btnA10.Visible = isVisible;

            lblGear.Visible = isVisible;
            btnG1.Visible = isVisible;
            btnG2.Visible = isVisible;
            btnG3.Visible = isVisible;
            btnG4.Visible = isVisible;
            btnG5.Visible = isVisible;

            btnIG1.Visible = isVisible;
            btnIG2.Visible = isVisible;

            imgInfo.Visible = isVisible;
            lblInfo.Visible = isVisible;

            lblBlank4.Visible = isVisible;
        }

        private bool InvMenuIsVisible() {
            return btnI1.Visible;
        }

        protected void OnBtnMusicClicked(object sender, EventArgs e) {
            WindowController.ShowMusicWindow();
        }

        public void PrintScreen() {
            for(int layer = 0; layer < 3; layer++) {
                for (int row = Calculate.CalculateStartY(Size), maxY = Calculate.CalculateMaxY(Size), btn = 1; row <= maxY; row++) {
                    for (int col = Calculate.CalculateStartX(Size), maxX = Calculate.CalculateMaxX(Size); col <= maxX; col++, btn++) {
                        Image img = ImageController.GetScreenImage(row, col, layer);

                        if (img == null) continue;

                        switch (btn) {
                            case 1: btnP1.Image = img; break;
                            case 2: btnP2.Image = img; break;
                            case 3: btnP3.Image = img; break;
                            case 4: btnP4.Image = img; break;
                            case 5: btnP5.Image = img; break;
                            case 6: btnP6.Image = img; break;
                            case 7: btnP7.Image = img; break;
                            case 8: btnP8.Image = img; break;
                            case 9: btnP9.Image = img; break;
                            case 10: btnP10.Image = img; break;
                            case 11: btnP11.Image = img; break;
                            case 12: btnP12.Image = img; break;
                            case 13: btnP13.Image = img; break;
                            case 14: btnP14.Image = img; break;
                            case 15: btnP15.Image = img; break;
                            case 16: btnP16.Image = img; break;
                            case 17: btnP17.Image = img; break;
                            case 18: btnP18.Image = img; break;
                            case 19: btnP19.Image = img; break;
                            case 20: btnP20.Image = img; break;
                            case 21: btnP21.Image = img; break;
                            case 22: btnP22.Image = img; break;
                            case 23: btnP23.Image = img; break;
                            case 24: btnP24.Image = img; break;
                            case 25: btnP25.Image = img; break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Prints the lung capacity, health, hotbar items and event log
        /// </summary>
        public void PrintMainMenu() {
            //Print lungs

            //Print health
            for (int i = 0; i < Size; i++) {
                string iName = MobStatsController.GetPlayerHearth(i);

                switch (i) {
                    case 0: imgS6.SetFromStock(iName, IconSize.Dnd); break;
                    case 1: imgS7.SetFromStock(iName, IconSize.Dnd); break;
                    case 2: imgS8.SetFromStock(iName, IconSize.Dnd); break;
                    case 3: imgS9.SetFromStock(iName, IconSize.Dnd); break;
                    case 4: imgS10.SetFromStock(iName, IconSize.Dnd); break;
                }
            }

            //Prints hotbar
            for (int i = 0; i < Size; i++) {
                Image img = ImageController.GetHotbarImage(i);

                switch (i + 1) {
                    case 1: btnH1.Image = img; break;
                    case 2: btnH2.Image = img; break;
                    case 3: btnH3.Image = img; break;
                    case 4: btnH4.Image = img; break;
                    case 5: btnH5.Image = img; break;
                }
            }

            //Print log
        }

        public void PrintMap() {
            //Prints the "Ground layer" in map menu
            for (int row = Calculate.CalculateStartY(Size), maxY = Calculate.CalculateMaxY(Size), img = 1; row <= maxY; row++) {
                for (int col = Calculate.CalculateStartX(Size), maxX = Calculate.CalculateMaxX(Size); col <= maxX; col++, img++) {
                    string sName = ImageController.GetGroundImage(row, col).Stock;

                    switch (img) {
                        case 1: imgG1.SetFromStock( sName, IconSize.Dnd ); break;
                        case 2: imgG2.SetFromStock( sName, IconSize.Dnd ); break;
                        case 3: imgG3.SetFromStock( sName, IconSize.Dnd ); break;
                        case 4: imgG4.SetFromStock( sName, IconSize.Dnd ); break;
                        case 5: imgG5.SetFromStock( sName, IconSize.Dnd ); break;
                        case 6: imgG6.SetFromStock( sName, IconSize.Dnd ); break;
                        case 7: imgG7.SetFromStock( sName, IconSize.Dnd ); break;
                        case 8: imgG8.SetFromStock( sName, IconSize.Dnd ); break;
                        case 9: imgG9.SetFromStock( sName, IconSize.Dnd ); break;
                        case 10: imgG10.SetFromStock( sName, IconSize.Dnd ); break;
                        case 11: imgG11.SetFromStock( sName, IconSize.Dnd ); break;
                        case 12: imgG12.SetFromStock( sName, IconSize.Dnd ); break;
                        case 13: imgG13.SetFromStock( sName, IconSize.Dnd ); break;
                        case 14: imgG14.SetFromStock( sName, IconSize.Dnd ); break;
                        case 15: imgG15.SetFromStock( sName, IconSize.Dnd ); break;
                        case 16: imgG16.SetFromStock( sName, IconSize.Dnd ); break;
                        case 17: imgG17.SetFromStock( sName, IconSize.Dnd ); break;
                        case 18: imgG18.SetFromStock( sName, IconSize.Dnd ); break;
                        case 19: imgG19.SetFromStock( sName, IconSize.Dnd ); break;
                        case 20: imgG20.SetFromStock( sName, IconSize.Dnd ); break;
                        case 21: imgG21.SetFromStock( sName, IconSize.Dnd ); break;
                        case 22: imgG22.SetFromStock( sName, IconSize.Dnd ); break;
                        case 23: imgG23.SetFromStock( sName, IconSize.Dnd ); break;
                        case 24: imgG24.SetFromStock( sName, IconSize.Dnd ); break;
                        case 25: imgG25.SetFromStock( sName, IconSize.Dnd ); break;
                    }
                }
            }

            lblSuperLayer.Text = MobStatsController.GetPlayerSuperLayerName();
            lblCoord1.Text = "X: " + MobStatsController.GetPlayerXCoord();
            lblCoord2.Text = "Y: " + MobStatsController.GetPlayerYCoord();

            //Prints the "Item layer" in map menu
            for (int row = Calculate.CalculateStartY(Size), maxY = Calculate.CalculateMaxY(Size), img = 1; row <= maxY; row++) {
                for (int col = Calculate.CalculateStartX(Size), maxX = Calculate.CalculateMaxX(Size); col <= maxX; col++, img++) {
                    string sName = ImageController.GetStructureImage(row, col).Stock;

                    switch (img) {
                        case 1: imgI1.SetFromStock( sName, IconSize.Dnd ); break;
                        case 2: imgI2.SetFromStock( sName, IconSize.Dnd ); break;
                        case 3: imgI3.SetFromStock( sName, IconSize.Dnd ); break;
                        case 4: imgI4.SetFromStock( sName, IconSize.Dnd ); break;
                        case 5: imgI5.SetFromStock( sName, IconSize.Dnd ); break;
                        case 6: imgI6.SetFromStock( sName, IconSize.Dnd ); break;
                        case 7: imgI7.SetFromStock( sName, IconSize.Dnd ); break;
                        case 8: imgI8.SetFromStock( sName, IconSize.Dnd ); break;
                        case 9: imgI9.SetFromStock( sName, IconSize.Dnd ); break;
                        case 10: imgI10.SetFromStock( sName, IconSize.Dnd ); break;
                        case 11: imgI11.SetFromStock( sName, IconSize.Dnd ); break;
                        case 12: imgI12.SetFromStock( sName, IconSize.Dnd ); break;
                        case 13: imgI13.SetFromStock( sName, IconSize.Dnd ); break;
                        case 14: imgI14.SetFromStock( sName, IconSize.Dnd ); break;
                        case 15: imgI15.SetFromStock( sName, IconSize.Dnd ); break;
                        case 16: imgI16.SetFromStock( sName, IconSize.Dnd ); break;
                        case 17: imgI17.SetFromStock( sName, IconSize.Dnd ); break;
                        case 18: imgI18.SetFromStock( sName, IconSize.Dnd ); break;
                        case 19: imgI19.SetFromStock( sName, IconSize.Dnd ); break;
                        case 20: imgI20.SetFromStock( sName, IconSize.Dnd ); break;
                        case 21: imgI21.SetFromStock( sName, IconSize.Dnd ); break;
                        case 22: imgI22.SetFromStock( sName, IconSize.Dnd ); break;
                        case 23: imgI23.SetFromStock( sName, IconSize.Dnd ); break;
                        case 24: imgI24.SetFromStock( sName, IconSize.Dnd ); break;
                        case 25: imgI25.SetFromStock( sName, IconSize.Dnd ); break;
                    }
                }
            }

            lblHoleOnTop.Text = MobStatsController.ExistsHoleOnTopOfPlayer() + "";
        }

        public void PrintInventory() {
            //Prints the actual inventory (items)
            for (int row = 0; row < Size; row++) {
                for (int col = 0; col < Size; col++) {
                    Image img = ImageController.GetInventoryItemImage(row * 5 + col);

                    switch (row * 5 + col + 1) {
                        case 1: btnI1.Image = img; break;
                        case 2: btnI2.Image = img; break;
                        case 3: btnI3.Image = img; break;
                        case 4: btnI4.Image = img; break;
                        case 5: btnI5.Image = img; break;
                        case 6: btnI6.Image = img; break;
                        case 7: btnI7.Image = img; break;
                        case 8: btnI8.Image = img; break;
                        case 9: btnI9.Image = img; break;
                        case 10: btnI10.Image = img; break;
                        case 11: btnI11.Image = img; break;
                        case 12: btnI12.Image = img; break;
                        case 13: btnI13.Image = img; break;
                        case 14: btnI14.Image = img; break;
                        case 15: btnI15.Image = img; break;
                        case 16: btnI16.Image = img; break;
                        case 17: btnI17.Image = img; break;
                        case 18: btnI18.Image = img; break;
                        case 19: btnI19.Image = img; break;
                        case 20: btnI20.Image = img; break;
                        case 21: btnI21.Image = img; break;
                        case 22: btnI22.Image = img; break;
                        case 23: btnI23.Image = img; break;
                        case 24: btnI24.Image = img; break;
                        case 25: btnI25.Image = img; break;
                    }
                }
            }

            //Prints accessories
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < Size; col++) {
                    Image img = ImageController.GetAccessoryImage(row * 5 + col);

                    switch (row * 5 + col + 1) {
                        case 1: btnA1.Image = img; break;
                        case 2: btnA2.Image = img; break;
                        case 3: btnA3.Image = img; break;
                        case 4: btnA4.Image = img; break;
                        case 5: btnA5.Image = img; break;
                        case 6: btnA6.Image = img; break;
                        case 7: btnA7.Image = img; break;
                        case 8: btnA8.Image = img; break;
                        case 9: btnA9.Image = img; break;
                        case 10: btnA10.Image = img; break;
                    }
                }
            }

            //Prints gear
            for (int i = 0; i < Size; i++) {
                Image img = ImageController.GetGearImage(i);

                switch (i + 1) {
                    case 1: btnG1.Image = img; break;
                    case 2: btnG2.Image = img; break;
                    case 3: btnG3.Image = img; break;
                    case 4: btnG4.Image = img; break;
                    case 5: btnG5.Image = img; break;
                }
            }
        }

        protected void OnBtnCraftingClicked(object sender, EventArgs e) {
            WindowController.ShowCraftingWindow();
        }

        public void PrintSelectedItemInfo(ItemTile itemTile) {
            if (itemTile != null) {
                imgInfo.SetFromStock(itemTile.stock_id, IconSize.Dnd);
                lblInfo.Text = itemTile.ToString();
            }
            else {
                imgInfo.SetFromImage(null, null);
                lblInfo.Text = null;
            }
        }

        //Screen buttons
        protected void OnBtnP1Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(1);
            }
        }
        protected void OnBtnP2Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(2);
            }
        }
        protected void OnBtnP3Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(3);
            }
        }
        protected void OnBtnP4Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(4);
            }
        }
        protected void OnBtnP5Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(5);
            }
        }
        protected void OnBtnP6Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(6);
            }
        }
        protected void OnBtnP7Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(7);
            }
        }
        protected void OnBtnP8Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(8);
            }
        }
        protected void OnBtnP9Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(9);
            }
        }
        protected void OnBtnP10Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(10);
            }
        }
        protected void OnBtnP11Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(11);
            }
        }
        protected void OnBtnP12Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(12);
            }
        }
        protected void OnBtnP13Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(13);
            }
        }
        protected void OnBtnP14Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(14);
            }
        }
        protected void OnBtnP15Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(15);
            }
        }
        protected void OnBtnP16Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(16);
            }
        }
        protected void OnBtnP17Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(17);
            }
        }
        protected void OnBtnP18Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(18);
            }
        }
        protected void OnBtnP19Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(19);
            }
        }
        protected void OnBtnP20Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(20);
            }
        }
        protected void OnBtnP21Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(21);
            }
        }
        protected void OnBtnP22Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(22);
            }
        }
        protected void OnBtnP23Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(23);
            }
        }
        protected void OnBtnP24Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(24);
            }
        }
        protected void OnBtnP25Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(25);
            }
        }

        private void React(int button) {
            int buttonYPos = (button - 1) / 5;
            int buttonXPos = button - buttonYPos * 5 - 1;

            int mapXPos = Calculate.CalculateXFromButton(buttonXPos, Size);
            int mapYPos = Calculate.CalculateYFromButton(buttonYPos, Size);

            if (!HasSelection()) {
                MobMovement.MovePlayer(mapYPos, mapXPos, Size);
            }
            else {
                if (Inventory.GetPlayerItem(selPlace, selIndex) != null) {
                    //try to do MobFighting
                    MobTerraforming.PlayerTerraformAt(mapYPos, mapXPos, selPlace, selIndex);
                }
                ResetSelection();
            }

            this.PrintScreen();
            this.PrintMainMenu();

            if (this.MapMenuIsVisible()) {
                this.PrintMap();
            }
            else if (this.InvMenuIsVisible()) {
                this.PrintInventory();
            }
        }

        //Hotbar buttons
        protected void OnBtnH1Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("hotbar", 0);
                this.PrintMainMenu();
            }
        }
        protected void OnBtnH2Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("hotbar", 1);
                this.PrintMainMenu();
            }
        }
        protected void OnBtnH3Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("hotbar", 2);
                this.PrintMainMenu();
            }
        }
        protected void OnBtnH4Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("hotbar", 3);
                this.PrintMainMenu();
            }
        }
        protected void OnBtnH5Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("hotbar", 4);
                this.PrintMainMenu();
            }
        }

        //Inventory (items) buttons
        protected void OnBtnI1Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 0);
                this.PrintInventory();
            }
        }
        protected void OnBtnI2Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 1);
                this.PrintInventory();
            }
        }
        protected void OnBtnI3Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 2);
                this.PrintInventory();
            }
        }
        protected void OnBtnI4Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 3);
                this.PrintInventory();
            }
        }
        protected void OnBtnI5Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 4);
                this.PrintInventory();
            }
        }
        protected void OnBtnI6Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 5);
                this.PrintInventory();
            }
        }
        protected void OnBtnI7Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 6);
                this.PrintInventory();
            }
        }
        protected void OnBtnI8Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 7);
                this.PrintInventory();
            }
        }
        protected void OnBtnI9Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 8);
                this.PrintInventory();
            }
        }
        protected void OnBtnI10Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 9);
                this.PrintInventory();
            }
        }
        protected void OnBtnI11Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 10);
                this.PrintInventory();
            }
        }
        protected void OnBtnI12Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 11);
                this.PrintInventory();
            }
        }
        protected void OnBtnI13Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 12);
                this.PrintInventory();
            }
        }
        protected void OnBtnI14Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 13);
                this.PrintInventory();
            }
        }
        protected void OnBtnI15Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 14);
                this.PrintInventory();
            }
        }
        protected void OnBtnI16Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 15);
                this.PrintInventory();
            }
        }
        protected void OnBtnI17Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 16);
                this.PrintInventory();
            }
        }
        protected void OnBtnI18Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 17);
                this.PrintInventory();
            }
        }
        protected void OnBtnI19Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 18);
                this.PrintInventory();
            }
        }
        protected void OnBtnI20Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 19);
                this.PrintInventory();
            }
        }
        protected void OnBtnI21Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 20);
                this.PrintInventory();
            }
        }
        protected void OnBtnI22Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 21);
                this.PrintInventory();
            }
        }
        protected void OnBtnI23Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 22);
                this.PrintInventory();
            }
        }
        protected void OnBtnI24Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 23);
                this.PrintInventory();
            }
        }
        protected void OnBtnI25Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 24);
                this.PrintInventory();
            }
        }

        //Accessories buttons
        protected void OnBtnA1Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("accessories", 0);
                this.PrintInventory();
            }
        }
        protected void OnBtnA2Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("accessories", 1);
                this.PrintInventory();
            }
        }
        protected void OnBtnA3Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("accessories", 2);
                this.PrintInventory();
            }
        }
        protected void OnBtnA4Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("accessories", 3);
                this.PrintInventory();
            }
        }
        protected void OnBtnA5Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("accessories", 4);
                this.PrintInventory();
            }
        }
        protected void OnBtnA6Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("accessories", 5);
                this.PrintInventory();
            }
        }
        protected void OnBtnA7Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("accessories", 6);
                this.PrintInventory();
            }
        }
        protected void OnBtnA8Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("accessories", 7);
                this.PrintInventory();
            }
        }
        protected void OnBtnA9Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("accessories", 8);
                this.PrintInventory();
            }
        }
        protected void OnBtnA10Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("accessories", 9);
                this.PrintInventory();
            }
        }

        //Gear buttons
        protected void OnBtnG1Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("gear", 0);
                this.PrintInventory();
            }
        }

        protected void OnBtnG2Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("gear", 1);
                this.PrintInventory();
            }
        }

        protected void OnBtnG3Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("gear", 2);
                this.PrintInventory();
            }
        }

        protected void OnBtnG4Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("gear", 3);
                this.PrintInventory();
            }
        }

        protected void OnBtnG5Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("gear", 4);
                this.PrintInventory();
            }
        }

        private static string selPlace = null;
        private static int selIndex = -1;
        private static void ResetSelection() {
            selPlace = null;
            selIndex = -1;
        }
        private static bool HasSelection() {
            return selPlace != null; 
        }

        private void SelectItem(string place, int index) {
            if (HasSelection()) {
                ResetSelection();
                SwitchItems.ReplaceItems(place, index);
            } else {
                selPlace = place;
                selIndex = index;
                SwitchItems.SetOrigin(place, index);
            }

            this.PrintMainMenu();
            this.PrintInventory();
        }

        protected void OnBtnIG1Clicked(object sender, EventArgs e) {
            //Mundus.Data.Superlayers.Mobs.LMI.Player.Inventory.Hotbar[0] = LandPresets.Boulder();
            MobStatsController.DamagePlayer(1);
            //Service.Crafting.CraftingController.FindAvalableItems();
            PrintMainMenu();
        }

        protected void OnBtnIG2Clicked(object sender, EventArgs e) {
            //Mundus.Data.Superlayers.Mobs.LMI.Player.Inventory.Hotbar[1] = new Service.Tiles.Items.Tool("blank_hand", Mundus.Data.Tiles.ToolTypes.Pickaxe, 1);
            //Mundus.Data.Superlayers.Mobs.LMI.Player.Inventory.Hotbar[0] = new Service.Tiles.Items.Tool("blank_hand", Mundus.Data.Tiles.ToolTypes.Axe, 1);

            MobStatsController.TryHealPlayer(1);
            PrintMainMenu();
        }


    }
}
