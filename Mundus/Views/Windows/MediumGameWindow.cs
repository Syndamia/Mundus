using System;
using Gtk;
using Mundus.Service;
using Mundus.Service.Mob.Controllers;
using Mundus.Service.Mobs.Controllers;
using Mundus.Service.SuperLayers;
using Mundus.Service.Tiles.Items;

namespace Mundus.Views.Windows {
    public partial class MediumGameWindow : Gtk.Window, IGameWindow {
        public int Size { get; private set; }

        public MediumGameWindow() : base( Gtk.WindowType.Toplevel ) {
            this.Build();
        }

        public void OnDeleteEvent(object o, DeleteEventArgs args) {
            //Open exit dialogue if you haven't saved in a while
            Application.Quit();
        }

        public void SetDefaults() {
            this.Size = 7;
            this.SetMapMenuVisibility(false);
            this.SetInvMenuVisibility(false);
        }

        private void SelectItem(string place, int index) {
            if (HasSelection()) {
                ResetSelection();
                SwitchItems.ReplaceItems(place, index);
            }
            else {
                selPlace = place;
                selIndex = index;
                SwitchItems.SetOrigin(place, index);
            }

            this.PrintMainMenu();
            this.PrintInventory();
        }

        private void React(int button) {
            int buttonYPos = (button - 1) / Size;
            int buttonXPos = (button - (buttonYPos * Size)) - 1;

            int mapXPos = Calculate.CalculateXFromButton(buttonXPos, Size);
            int mapYPos = Calculate.CalculateYFromButton(buttonYPos, Size);

            if (!HasSelection()) {
                MobMovement.MovePlayer(mapYPos, mapXPos, Size);
                MobMovement.MoveRandomlyAllMobs();
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

        private static string selPlace = null;
        private static int selIndex = -1;
        private static void ResetSelection() {
            selPlace = null;
            selIndex = -1;
        }
        private static bool HasSelection() {
            return selPlace != null;
        }

        private bool InvMenuIsVisible() {
            return btnI1.Visible;
        }



        private bool MapMenuIsVisible() {
            return imgG1.Visible;
        }

        //
        // PRINTING
        //

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

        public void PrintScreen() {
            for (int layer = 0; layer < 3; layer++) {
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
                            case 26: btnP26.Image = img; break;
                            case 27: btnP27.Image = img; break;
                            case 28: btnP28.Image = img; break;
                            case 29: btnP29.Image = img; break;
                            case 30: btnP30.Image = img; break;
                            case 31: btnP31.Image = img; break;
                            case 32: btnP32.Image = img; break;
                            case 33: btnP33.Image = img; break;
                            case 34: btnP34.Image = img; break;
                            case 35: btnP35.Image = img; break;
                            case 36: btnP36.Image = img; break;
                            case 37: btnP37.Image = img; break;
                            case 38: btnP38.Image = img; break;
                            case 39: btnP39.Image = img; break;
                            case 40: btnP40.Image = img; break;
                            case 41: btnP41.Image = img; break;
                            case 42: btnP42.Image = img; break;
                            case 43: btnP43.Image = img; break;
                            case 44: btnP44.Image = img; break;
                            case 45: btnP45.Image = img; break;
                            case 46: btnP46.Image = img; break;
                            case 47: btnP47.Image = img; break;
                            case 48: btnP48.Image = img; break;
                            case 49: btnP49.Image = img; break;
                        }
                    }
                }
            }
        }

        public void PrintMainMenu() {
            //Print lungs

            //Print health
            for (int i = 0; i < Size; i++) {
                string iName = MobStatsController.GetPlayerHearth(i);

                switch (i) {
                    case 0: imgS8.SetFromStock(iName, IconSize.Dnd); break;
                    case 1: imgS9.SetFromStock(iName, IconSize.Dnd); break;
                    case 2: imgS10.SetFromStock(iName, IconSize.Dnd); break;
                    case 3: imgS11.SetFromStock(iName, IconSize.Dnd); break;
                    case 4: imgS12.SetFromStock(iName, IconSize.Dnd); break;
                    case 5: imgS13.SetFromStock(iName, IconSize.Dnd); break;
                    case 6: imgS14.SetFromStock(iName, IconSize.Dnd); break;
                }
            }

            //Prints hotbar
            for (int i = 0; i < Size; i++) {
                Image img = ImageController.GetHotbarImage(i);

                switch (i) {
                    case 0: btnH1.Image = img; break;
                    case 1: btnH2.Image = img; break;
                    case 2: btnH3.Image = img; break;
                    case 3: btnH4.Image = img; break;
                    case 4: btnH5.Image = img; break;
                    case 5: btnH6.Image = img; break;
                    case 6: btnH7.Image = img; break;
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
                        case 1: imgG1.SetFromStock(sName, IconSize.Dnd); break;
                        case 2: imgG2.SetFromStock(sName, IconSize.Dnd); break;
                        case 3: imgG3.SetFromStock(sName, IconSize.Dnd); break;
                        case 4: imgG4.SetFromStock(sName, IconSize.Dnd); break;
                        case 5: imgG5.SetFromStock(sName, IconSize.Dnd); break;
                        case 6: imgG6.SetFromStock(sName, IconSize.Dnd); break;
                        case 7: imgG7.SetFromStock(sName, IconSize.Dnd); break;
                        case 8: imgG8.SetFromStock(sName, IconSize.Dnd); break;
                        case 9: imgG9.SetFromStock(sName, IconSize.Dnd); break;
                        case 10: imgG10.SetFromStock(sName, IconSize.Dnd); break;
                        case 11: imgG11.SetFromStock(sName, IconSize.Dnd); break;
                        case 12: imgG12.SetFromStock(sName, IconSize.Dnd); break;
                        case 13: imgG13.SetFromStock(sName, IconSize.Dnd); break;
                        case 14: imgG14.SetFromStock(sName, IconSize.Dnd); break;
                        case 15: imgG15.SetFromStock(sName, IconSize.Dnd); break;
                        case 16: imgG16.SetFromStock(sName, IconSize.Dnd); break;
                        case 17: imgG17.SetFromStock(sName, IconSize.Dnd); break;
                        case 18: imgG18.SetFromStock(sName, IconSize.Dnd); break;
                        case 19: imgG19.SetFromStock(sName, IconSize.Dnd); break;
                        case 20: imgG20.SetFromStock(sName, IconSize.Dnd); break;
                        case 21: imgG21.SetFromStock(sName, IconSize.Dnd); break;
                        case 22: imgG22.SetFromStock(sName, IconSize.Dnd); break;
                        case 23: imgG23.SetFromStock(sName, IconSize.Dnd); break;
                        case 24: imgG24.SetFromStock(sName, IconSize.Dnd); break;
                        case 25: imgG25.SetFromStock(sName, IconSize.Dnd); break;
                        case 26: imgG26.SetFromStock(sName, IconSize.Dnd); break;
                        case 27: imgG27.SetFromStock(sName, IconSize.Dnd); break;
                        case 28: imgG28.SetFromStock(sName, IconSize.Dnd); break;
                        case 29: imgG29.SetFromStock(sName, IconSize.Dnd); break;
                        case 30: imgG30.SetFromStock(sName, IconSize.Dnd); break;
                        case 31: imgG31.SetFromStock(sName, IconSize.Dnd); break;
                        case 32: imgG32.SetFromStock(sName, IconSize.Dnd); break;
                        case 33: imgG33.SetFromStock(sName, IconSize.Dnd); break;
                        case 34: imgG34.SetFromStock(sName, IconSize.Dnd); break;
                        case 35: imgG35.SetFromStock(sName, IconSize.Dnd); break;
                        case 36: imgG36.SetFromStock(sName, IconSize.Dnd); break;
                        case 37: imgG37.SetFromStock(sName, IconSize.Dnd); break;
                        case 38: imgG38.SetFromStock(sName, IconSize.Dnd); break;
                        case 39: imgG39.SetFromStock(sName, IconSize.Dnd); break;
                        case 40: imgG40.SetFromStock(sName, IconSize.Dnd); break;
                        case 41: imgG41.SetFromStock(sName, IconSize.Dnd); break;
                        case 42: imgG42.SetFromStock(sName, IconSize.Dnd); break;
                        case 43: imgG43.SetFromStock(sName, IconSize.Dnd); break;
                        case 44: imgG44.SetFromStock(sName, IconSize.Dnd); break;
                        case 45: imgG45.SetFromStock(sName, IconSize.Dnd); break;
                        case 46: imgG46.SetFromStock(sName, IconSize.Dnd); break;
                        case 47: imgG47.SetFromStock(sName, IconSize.Dnd); break;
                        case 48: imgG48.SetFromStock(sName, IconSize.Dnd); break;
                        case 49: imgG49.SetFromStock(sName, IconSize.Dnd); break;
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
                        case 1: imgI1.SetFromStock(sName, IconSize.Dnd); break;
                        case 2: imgI2.SetFromStock(sName, IconSize.Dnd); break;
                        case 3: imgI3.SetFromStock(sName, IconSize.Dnd); break;
                        case 4: imgI4.SetFromStock(sName, IconSize.Dnd); break;
                        case 5: imgI5.SetFromStock(sName, IconSize.Dnd); break;
                        case 6: imgI6.SetFromStock(sName, IconSize.Dnd); break;
                        case 7: imgI7.SetFromStock(sName, IconSize.Dnd); break;
                        case 8: imgI8.SetFromStock(sName, IconSize.Dnd); break;
                        case 9: imgI9.SetFromStock(sName, IconSize.Dnd); break;
                        case 10: imgI10.SetFromStock(sName, IconSize.Dnd); break;
                        case 11: imgI11.SetFromStock(sName, IconSize.Dnd); break;
                        case 12: imgI12.SetFromStock(sName, IconSize.Dnd); break;
                        case 13: imgI13.SetFromStock(sName, IconSize.Dnd); break;
                        case 14: imgI14.SetFromStock(sName, IconSize.Dnd); break;
                        case 15: imgI15.SetFromStock(sName, IconSize.Dnd); break;
                        case 16: imgI16.SetFromStock(sName, IconSize.Dnd); break;
                        case 17: imgI17.SetFromStock(sName, IconSize.Dnd); break;
                        case 18: imgI18.SetFromStock(sName, IconSize.Dnd); break;
                        case 19: imgI19.SetFromStock(sName, IconSize.Dnd); break;
                        case 20: imgI20.SetFromStock(sName, IconSize.Dnd); break;
                        case 21: imgI21.SetFromStock(sName, IconSize.Dnd); break;
                        case 22: imgI22.SetFromStock(sName, IconSize.Dnd); break;
                        case 23: imgI23.SetFromStock(sName, IconSize.Dnd); break;
                        case 24: imgI24.SetFromStock(sName, IconSize.Dnd); break;
                        case 25: imgI25.SetFromStock(sName, IconSize.Dnd); break;
                        case 26: imgI26.SetFromStock(sName, IconSize.Dnd); break;
                        case 27: imgI27.SetFromStock(sName, IconSize.Dnd); break;
                        case 28: imgI28.SetFromStock(sName, IconSize.Dnd); break;
                        case 29: imgI29.SetFromStock(sName, IconSize.Dnd); break;
                        case 30: imgI30.SetFromStock(sName, IconSize.Dnd); break;
                        case 31: imgI31.SetFromStock(sName, IconSize.Dnd); break;
                        case 32: imgI32.SetFromStock(sName, IconSize.Dnd); break;
                        case 33: imgI33.SetFromStock(sName, IconSize.Dnd); break;
                        case 34: imgI34.SetFromStock(sName, IconSize.Dnd); break;
                        case 35: imgI35.SetFromStock(sName, IconSize.Dnd); break;
                        case 36: imgI36.SetFromStock(sName, IconSize.Dnd); break;
                        case 37: imgI37.SetFromStock(sName, IconSize.Dnd); break;
                        case 38: imgI38.SetFromStock(sName, IconSize.Dnd); break;
                        case 39: imgI39.SetFromStock(sName, IconSize.Dnd); break;
                        case 40: imgI40.SetFromStock(sName, IconSize.Dnd); break;
                        case 41: imgI41.SetFromStock(sName, IconSize.Dnd); break;
                        case 42: imgI42.SetFromStock(sName, IconSize.Dnd); break;
                        case 43: imgI43.SetFromStock(sName, IconSize.Dnd); break;
                        case 44: imgI44.SetFromStock(sName, IconSize.Dnd); break;
                        case 45: imgI45.SetFromStock(sName, IconSize.Dnd); break;
                        case 46: imgI46.SetFromStock(sName, IconSize.Dnd); break;
                        case 47: imgI47.SetFromStock(sName, IconSize.Dnd); break;
                        case 48: imgI48.SetFromStock(sName, IconSize.Dnd); break;
                        case 49: imgI49.SetFromStock(sName, IconSize.Dnd); break;
                    }
                }
            }

            lblHoleOnTop.Text = MobStatsController.ExistsHoleOnTopOfPlayer() + "";
        }

        public void PrintInventory() {
            //Prints the actual inventory (items)
            for (int row = 0; row < Size; row++) {
                for (int col = 0; col < Size; col++) {
                    Image img = ImageController.GetInventoryItemImage(row * Size + col);

                    switch (row * Size + col + 1) {
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
                        case 26: btnI26.Image = img; break;
                        case 27: btnI27.Image = img; break;
                        case 28: btnI28.Image = img; break;
                        case 29: btnI29.Image = img; break;
                        case 30: btnI30.Image = img; break;
                        case 31: btnI31.Image = img; break;
                        case 32: btnI32.Image = img; break;
                        case 33: btnI33.Image = img; break;
                        case 34: btnI34.Image = img; break;
                        case 35: btnI35.Image = img; break;
                        case 36: btnI36.Image = img; break;
                        case 37: btnI37.Image = img; break;
                        case 38: btnI38.Image = img; break;
                        case 39: btnI39.Image = img; break;
                        case 40: btnI40.Image = img; break;
                        case 41: btnI41.Image = img; break;
                        case 42: btnI42.Image = img; break;
                        case 43: btnI43.Image = img; break;
                        case 44: btnI44.Image = img; break;
                        case 45: btnI45.Image = img; break;
                        case 46: btnI46.Image = img; break;
                        case 47: btnI47.Image = img; break;
                        case 48: btnI48.Image = img; break;
                        case 49: btnI49.Image = img; break;
                    }
                }
            }

            //Prints accessories
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < Size; col++) {
                    Image img = ImageController.GetAccessoryImage(row * Size + col);

                    switch (row * Size + col + 1) {
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
                        case 11: btnA11.Image = img; break;
                        case 12: btnA12.Image = img; break;
                        case 13: btnA13.Image = img; break;
                        case 14: btnA14.Image = img; break;
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
                    case 6: btnG6.Image = img; break;
                    case 7: btnG7.Image = img; break;
                }
            }
        }

        //
        // BUTTON CLICKED EVENTS
        //

        protected void OnBtnMapClicked(object sender, EventArgs e) {
            //Hide inv menu, if it is visible (so only one of the two is visible)
            if (this.InvMenuIsVisible()) this.OnBtnInvClicked(this, null);

            if (this.MapMenuIsVisible()) {
                this.SetMapMenuVisibility(false);
            }
            else {
                this.PrintMap();
                this.SetMapMenuVisibility(true);
            }
        }

        protected void OnBtnInvClicked(object sender, EventArgs e) {
            //Hide map menu, if it is visible (so only one of the two is visible)
            if (this.MapMenuIsVisible()) this.OnBtnMapClicked(this, null);

            if (btnI1.Visible) {
                this.SetInvMenuVisibility(false);
            }
            else {
                this.PrintInventory();
                this.SetInvMenuVisibility(true);
            }
        }

        protected void OnBtnPauseClicked(object sender, EventArgs e) {
            // Note: pause window blocks player input
            WindowController.ShowPauseWindow();
        }

        protected void OnBtnMusicClicked(object sender, EventArgs e) {
            WindowController.ShowMusicWindow();
        }


        protected void OnBtnCraftingClicked(object sender, EventArgs e) {
            WindowController.ShowCraftingWindow();
        }

        // Screen buttons
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

        protected void OnBtnP26Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(26);
            }
        }

        protected void OnBtnP27Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(27);
            }
        }

        protected void OnBtnP28Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(28);
            }
        }

        protected void OnBtnP29Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(29);
            }
        }

        protected void OnBtnP30Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(30);
            }
        }

        protected void OnBtnP31Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(31);
            }
        }

        protected void OnBtnP32Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(32);
            }
        }

        protected void OnBtnP33Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(33);
            }
        }

        protected void OnBtnP34Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(34);
            }
        }

        protected void OnBtnP35Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(35);
            }
        }

        protected void OnBtnP36Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(36);
            }
        }

        protected void OnBtnP37Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(37);
            }
        }

        protected void OnBtnP38Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(38);
            }
        }

        protected void OnBtnP39Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(39);
            }
        }

        protected void OnBtnP40Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(40);
            }
        }

        protected void OnBtnP41Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(41);
            }
        }

        protected void OnBtnP42Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(42);
            }
        }

        protected void OnBtnP43Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(43);
            }
        }

        protected void OnBtnP44Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(44);
            }
        }

        protected void OnBtnP45Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(45);
            }
        }

        protected void OnBtnP46Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(46);
            }
        }

        protected void OnBtnP47Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(47);
            }
        }

        protected void OnBtnP48Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(48);
            }
        }

        protected void OnBtnP49Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(49);
            }
        }

        // Hotbar buttons
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

        protected void OnBtnH6Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("hotbar", 5);
                this.PrintMainMenu();
            }
        }

        protected void OnBtnH7Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("hotbar", 6);
                this.PrintMainMenu();
            }
        }

        // Inventory (items) buttons
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

        protected void OnBtnI26Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 25);
                this.PrintInventory();
            }
        }

        protected void OnBtnI27Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 26);
                this.PrintInventory();
            }
        }

        protected void OnBtnI28Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 27);
                this.PrintInventory();
            }
        }

        protected void OnBtnI29Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 28);
                this.PrintInventory();
            }
        }

        protected void OnBtnI30Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 29);
                this.PrintInventory();
            }
        }

        protected void OnBtnI31Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 30);
                this.PrintInventory();
            }
        }

        protected void OnBtnI32Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 31);
                this.PrintInventory();
            }
        }

        protected void OnBtnI33Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 32);
                this.PrintInventory();
            }
        }

        protected void OnBtnI34Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 33);
                this.PrintInventory();
            }
        }

        protected void OnBtnI35Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 34);
                this.PrintInventory();
            }
        }

        protected void OnBtnI36Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 35);
                this.PrintInventory();
            }
        }

        protected void OnBtnI37Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 36);
                this.PrintInventory();
            }
        }

        protected void OnBtnI38Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 37);
                this.PrintInventory();
            }
        }

        protected void OnBtnI39Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 38);
                this.PrintInventory();
            }
        }

        protected void OnBtnI40Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 39);
                this.PrintInventory();
            }
        }

        protected void OnBtnI41Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 40);
                this.PrintInventory();
            }
        }

        protected void OnBtnI42Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 41);
                this.PrintInventory();
            }
        }

        protected void OnBtnI43Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 42);
                this.PrintInventory();
            }
        }

        protected void OnBtnI44Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 43);
                this.PrintInventory();
            }
        }

        protected void OnBtnI45Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 44);
                this.PrintInventory();
            }
        }

        protected void OnBtnI46Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 45);
                this.PrintInventory();
            }
        }

        protected void OnBtnI47Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 46);
                this.PrintInventory();
            }
        }

        protected void OnBtnI48Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 47);
                this.PrintInventory();
            }
        }

        protected void OnBtnI49Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 48);
                this.PrintInventory();
            }
        }

        // Accessories buttons
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

        protected void OnBtnA11Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("accessories", 10);
                this.PrintInventory();
            }
        }

        protected void OnBtnA12Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("accessories", 11);
                this.PrintInventory();
            }
        }

        protected void OnBtnA13Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("accessories", 12);
                this.PrintInventory();
            }
        }

        protected void OnBtnA14Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("accessories", 13);
                this.PrintInventory();
            }
        }

        // Gear buttons
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

        protected void OnBtnG6Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("gear", 5);
                this.PrintInventory();
            }
        }

        protected void OnBtnG7Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("gear", 6);
                this.PrintInventory();
            }
        }

        //
        // VISIBILITY
        //

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
            imgG26.Visible = isVisible;
            imgG27.Visible = isVisible;
            imgG28.Visible = isVisible;
            imgG29.Visible = isVisible;
            imgG30.Visible = isVisible;
            imgG31.Visible = isVisible;
            imgG32.Visible = isVisible;
            imgG33.Visible = isVisible;
            imgG34.Visible = isVisible;
            imgG35.Visible = isVisible;
            imgG36.Visible = isVisible;
            imgG37.Visible = isVisible;
            imgG38.Visible = isVisible;
            imgG39.Visible = isVisible;
            imgG40.Visible = isVisible;
            imgG41.Visible = isVisible;
            imgG42.Visible = isVisible;
            imgG43.Visible = isVisible;
            imgG44.Visible = isVisible;
            imgG45.Visible = isVisible;
            imgG46.Visible = isVisible;
            imgG47.Visible = isVisible;
            imgG48.Visible = isVisible;
            imgG49.Visible = isVisible;

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
            imgI26.Visible = isVisible;
            imgI27.Visible = isVisible;
            imgI28.Visible = isVisible;
            imgI29.Visible = isVisible;
            imgI30.Visible = isVisible;
            imgI31.Visible = isVisible;
            imgI32.Visible = isVisible;
            imgI33.Visible = isVisible;
            imgI34.Visible = isVisible;
            imgI35.Visible = isVisible;
            imgI36.Visible = isVisible;
            imgI37.Visible = isVisible;
            imgI38.Visible = isVisible;
            imgI39.Visible = isVisible;
            imgI40.Visible = isVisible;
            imgI41.Visible = isVisible;
            imgI42.Visible = isVisible;
            imgI43.Visible = isVisible;
            imgI44.Visible = isVisible;
            imgI45.Visible = isVisible;
            imgI46.Visible = isVisible;
            imgI47.Visible = isVisible;
            imgI48.Visible = isVisible;
            imgI49.Visible = isVisible;

            lblHoleMsg.Visible = isVisible;
            lblHoleOnTop.Visible = isVisible;

            lblBlank6.Visible = isVisible;
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
            btnI26.Visible = isVisible;
            btnI27.Visible = isVisible;
            btnI28.Visible = isVisible;
            btnI29.Visible = isVisible;
            btnI30.Visible = isVisible;
            btnI31.Visible = isVisible;
            btnI32.Visible = isVisible;
            btnI33.Visible = isVisible;
            btnI34.Visible = isVisible;
            btnI35.Visible = isVisible;
            btnI36.Visible = isVisible;
            btnI37.Visible = isVisible;
            btnI38.Visible = isVisible;
            btnI39.Visible = isVisible;
            btnI40.Visible = isVisible;
            btnI41.Visible = isVisible;
            btnI42.Visible = isVisible;
            btnI43.Visible = isVisible;
            btnI44.Visible = isVisible;
            btnI45.Visible = isVisible;
            btnI46.Visible = isVisible;
            btnI47.Visible = isVisible;
            btnI48.Visible = isVisible;
            btnI49.Visible = isVisible;
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
            btnA11.Visible = isVisible;
            btnA12.Visible = isVisible;
            btnA13.Visible = isVisible;
            btnA14.Visible = isVisible;

            lblGear.Visible = isVisible;
            btnG1.Visible = isVisible;
            btnG2.Visible = isVisible;
            btnG3.Visible = isVisible;
            btnG4.Visible = isVisible;
            btnG5.Visible = isVisible;
            btnG6.Visible = isVisible;
            btnG7.Visible = isVisible;

            imgInfo.Visible = isVisible;
            lblInfo.Visible = isVisible;

            lblBlank6.Visible = isVisible;
        }
    }
}
