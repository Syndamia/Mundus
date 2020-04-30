using System;
using Gtk;
using Mundus.Service;
using Mundus.Service.Mob.Controllers;
using Mundus.Service.Mobs.Controllers;
using Mundus.Service.SuperLayers;
using Mundus.Service.Tiles.Items;

namespace Mundus.Views.Windows {
    public partial class LargeGameWindow : Gtk.Window, IGameWindow {
        public int Size { get; private set; }

        public LargeGameWindow() : base( Gtk.WindowType.Toplevel ) {
            this.Build();
        }

        public void OnDeleteEvent(object o, DeleteEventArgs args) {
            Application.Quit();
        }

        public void SetDefaults() {
            this.Size = 9;
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
                    if (MobFighting.ExistsFightTargetForPlayer(mapYPos, mapXPos)) {
                        MobFighting.PlayerTryFight(selPlace, selIndex, mapYPos, mapXPos);
                    }
                    else {
                        MobTerraforming.PlayerTerraformAt(mapYPos, mapXPos, selPlace, selIndex);
                    }
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
                            case 50: btnP50.Image = img; break;
                            case 51: btnP51.Image = img; break;
                            case 52: btnP52.Image = img; break;
                            case 53: btnP53.Image = img; break;
                            case 54: btnP54.Image = img; break;
                            case 55: btnP55.Image = img; break;
                            case 56: btnP56.Image = img; break;
                            case 57: btnP57.Image = img; break;
                            case 58: btnP58.Image = img; break;
                            case 59: btnP59.Image = img; break;
                            case 60: btnP60.Image = img; break;
                            case 61: btnP61.Image = img; break;
                            case 62: btnP62.Image = img; break;
                            case 63: btnP63.Image = img; break;
                            case 64: btnP64.Image = img; break;
                            case 65: btnP65.Image = img; break;
                            case 66: btnP66.Image = img; break;
                            case 67: btnP67.Image = img; break;
                            case 68: btnP68.Image = img; break;
                            case 69: btnP69.Image = img; break;
                            case 70: btnP70.Image = img; break;
                            case 71: btnP71.Image = img; break;
                            case 72: btnP72.Image = img; break;
                            case 73: btnP73.Image = img; break;
                            case 74: btnP74.Image = img; break;
                            case 75: btnP75.Image = img; break;
                            case 76: btnP76.Image = img; break;
                            case 77: btnP77.Image = img; break;
                            case 78: btnP78.Image = img; break;
                            case 79: btnP79.Image = img; break;
                            case 80: btnP80.Image = img; break;
                            case 81: btnP81.Image = img; break;
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
                    case 0: imgS10.SetFromStock(iName, IconSize.Dnd); break;
                    case 1: imgS11.SetFromStock(iName, IconSize.Dnd); break;
                    case 2: imgS12.SetFromStock(iName, IconSize.Dnd); break;
                    case 3: imgS13.SetFromStock(iName, IconSize.Dnd); break;
                    case 4: imgS14.SetFromStock(iName, IconSize.Dnd); break;
                    case 5: imgS15.SetFromStock(iName, IconSize.Dnd); break;
                    case 6: imgS16.SetFromStock(iName, IconSize.Dnd); break;
                    case 7: imgS17.SetFromStock(iName, IconSize.Dnd); break;
                    case 8: imgS18.SetFromStock(iName, IconSize.Dnd); break;
                }
            }

            //Prints hotbar
            for (int i = 0; i < Size; i++) {
                Image img = ImageController.GetPlayerHotbarImage(i);

                switch (i) {
                    case 0: btnH1.Image = img; break;
                    case 1: btnH2.Image = img; break;
                    case 2: btnH3.Image = img; break;
                    case 3: btnH4.Image = img; break;
                    case 4: btnH5.Image = img; break;
                    case 5: btnH6.Image = img; break;
                    case 6: btnH7.Image = img; break;
                    case 7: btnH8.Image = img; break;
                    case 8: btnH9.Image = img; break;
                }
            }

            //Print log
        }

        public void PrintMap() {
            //Prints the "Ground layer" in map menu
            for (int row = Calculate.CalculateStartY(Size), maxY = Calculate.CalculateMaxY(Size), img = 1; row <= maxY; row++) {
                for (int col = Calculate.CalculateStartX(Size), maxX = Calculate.CalculateMaxX(Size); col <= maxX; col++, img++) {
                    string sName = ImageController.GetPlayerGroundImage(row, col).Stock;

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
                        case 50: imgG50.SetFromStock(sName, IconSize.Dnd); break;
                        case 51: imgG51.SetFromStock(sName, IconSize.Dnd); break;
                        case 52: imgG52.SetFromStock(sName, IconSize.Dnd); break;
                        case 53: imgG53.SetFromStock(sName, IconSize.Dnd); break;
                        case 54: imgG54.SetFromStock(sName, IconSize.Dnd); break;
                        case 55: imgG55.SetFromStock(sName, IconSize.Dnd); break;
                        case 56: imgG56.SetFromStock(sName, IconSize.Dnd); break;
                        case 57: imgG57.SetFromStock(sName, IconSize.Dnd); break;
                        case 58: imgG58.SetFromStock(sName, IconSize.Dnd); break;
                        case 59: imgG59.SetFromStock(sName, IconSize.Dnd); break;
                        case 60: imgG60.SetFromStock(sName, IconSize.Dnd); break;
                        case 61: imgG61.SetFromStock(sName, IconSize.Dnd); break;
                        case 62: imgG62.SetFromStock(sName, IconSize.Dnd); break;
                        case 63: imgG63.SetFromStock(sName, IconSize.Dnd); break;
                        case 64: imgG64.SetFromStock(sName, IconSize.Dnd); break;
                        case 65: imgG65.SetFromStock(sName, IconSize.Dnd); break;
                        case 66: imgG66.SetFromStock(sName, IconSize.Dnd); break;
                        case 67: imgG67.SetFromStock(sName, IconSize.Dnd); break;
                        case 68: imgG68.SetFromStock(sName, IconSize.Dnd); break;
                        case 69: imgG69.SetFromStock(sName, IconSize.Dnd); break;
                        case 70: imgG70.SetFromStock(sName, IconSize.Dnd); break;
                        case 71: imgG71.SetFromStock(sName, IconSize.Dnd); break;
                        case 72: imgG72.SetFromStock(sName, IconSize.Dnd); break;
                        case 73: imgG73.SetFromStock(sName, IconSize.Dnd); break;
                        case 74: imgG74.SetFromStock(sName, IconSize.Dnd); break;
                        case 75: imgG75.SetFromStock(sName, IconSize.Dnd); break;
                        case 76: imgG76.SetFromStock(sName, IconSize.Dnd); break;
                        case 77: imgG77.SetFromStock(sName, IconSize.Dnd); break;
                        case 78: imgG78.SetFromStock(sName, IconSize.Dnd); break;
                        case 79: imgG79.SetFromStock(sName, IconSize.Dnd); break;
                        case 80: imgG80.SetFromStock(sName, IconSize.Dnd); break;
                        case 81: imgG81.SetFromStock(sName, IconSize.Dnd); break;
                    }
                }
            }

            lblSuperLayer.Text = MobStatsController.GetPlayerSuperLayerName();
            lblCoord1.Text = "X: " + MobStatsController.GetPlayerXCoord();
            lblCoord2.Text = "Y: " + MobStatsController.GetPlayerYCoord();

            //Prints the "Item layer" in map menu
            for (int row = Calculate.CalculateStartY(Size), maxY = Calculate.CalculateMaxY(Size), img = 1; row <= maxY; row++) {
                for (int col = Calculate.CalculateStartX(Size), maxX = Calculate.CalculateMaxX(Size); col <= maxX; col++, img++) {
                    string sName = ImageController.GetPlayerStructureImage(row, col).Stock;

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
                        case 50: imgI50.SetFromStock(sName, IconSize.Dnd); break;
                        case 51: imgI51.SetFromStock(sName, IconSize.Dnd); break;
                        case 52: imgI52.SetFromStock(sName, IconSize.Dnd); break;
                        case 53: imgI53.SetFromStock(sName, IconSize.Dnd); break;
                        case 54: imgI54.SetFromStock(sName, IconSize.Dnd); break;
                        case 55: imgI55.SetFromStock(sName, IconSize.Dnd); break;
                        case 56: imgI56.SetFromStock(sName, IconSize.Dnd); break;
                        case 57: imgI57.SetFromStock(sName, IconSize.Dnd); break;
                        case 58: imgI58.SetFromStock(sName, IconSize.Dnd); break;
                        case 59: imgI59.SetFromStock(sName, IconSize.Dnd); break;
                        case 60: imgI60.SetFromStock(sName, IconSize.Dnd); break;
                        case 61: imgI61.SetFromStock(sName, IconSize.Dnd); break;
                        case 62: imgI62.SetFromStock(sName, IconSize.Dnd); break;
                        case 63: imgI63.SetFromStock(sName, IconSize.Dnd); break;
                        case 64: imgI64.SetFromStock(sName, IconSize.Dnd); break;
                        case 65: imgI65.SetFromStock(sName, IconSize.Dnd); break;
                        case 66: imgI66.SetFromStock(sName, IconSize.Dnd); break;
                        case 67: imgI67.SetFromStock(sName, IconSize.Dnd); break;
                        case 68: imgI68.SetFromStock(sName, IconSize.Dnd); break;
                        case 69: imgI69.SetFromStock(sName, IconSize.Dnd); break;
                        case 70: imgI70.SetFromStock(sName, IconSize.Dnd); break;
                        case 71: imgI71.SetFromStock(sName, IconSize.Dnd); break;
                        case 72: imgI72.SetFromStock(sName, IconSize.Dnd); break;
                        case 73: imgI73.SetFromStock(sName, IconSize.Dnd); break;
                        case 74: imgI74.SetFromStock(sName, IconSize.Dnd); break;
                        case 75: imgI75.SetFromStock(sName, IconSize.Dnd); break;
                        case 76: imgI76.SetFromStock(sName, IconSize.Dnd); break;
                        case 77: imgI77.SetFromStock(sName, IconSize.Dnd); break;
                        case 78: imgI78.SetFromStock(sName, IconSize.Dnd); break;
                        case 79: imgI79.SetFromStock(sName, IconSize.Dnd); break;
                        case 80: imgI80.SetFromStock(sName, IconSize.Dnd); break;
                        case 81: imgI81.SetFromStock(sName, IconSize.Dnd); break;
                    }
                }
            }

            lblHoleOnTop.Text = MobStatsController.ExistsHoleOnTopOfPlayer() + "";
        }

        public void PrintInventory() {
            //Prints the actual inventory (items)
            for (int row = 0; row < Size; row++) {
                for (int col = 0; col < Size; col++) {
                    Image img = ImageController.GetPlayerInventoryItemImage(row * Size + col);

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
                        case 50: btnI50.Image = img; break;
                        case 51: btnI51.Image = img; break;
                        case 52: btnI52.Image = img; break;
                        case 53: btnI53.Image = img; break;
                        case 54: btnI54.Image = img; break;
                        case 55: btnI55.Image = img; break;
                        case 56: btnI56.Image = img; break;
                        case 57: btnI57.Image = img; break;
                        case 58: btnI58.Image = img; break;
                        case 59: btnI59.Image = img; break;
                        case 60: btnI60.Image = img; break;
                        case 61: btnI61.Image = img; break;
                        case 62: btnI62.Image = img; break;
                        case 63: btnI63.Image = img; break;
                        case 64: btnI64.Image = img; break;
                        case 65: btnI65.Image = img; break;
                        case 66: btnI66.Image = img; break;
                        case 67: btnI67.Image = img; break;
                        case 68: btnI68.Image = img; break;
                        case 69: btnI69.Image = img; break;
                        case 70: btnI70.Image = img; break;
                        case 71: btnI71.Image = img; break;
                        case 72: btnI72.Image = img; break;
                        case 73: btnI73.Image = img; break;
                        case 74: btnI74.Image = img; break;
                        case 75: btnI75.Image = img; break;
                        case 76: btnI76.Image = img; break;
                        case 77: btnI77.Image = img; break;
                        case 78: btnI78.Image = img; break;
                        case 79: btnI79.Image = img; break;
                        case 80: btnI80.Image = img; break;
                        case 81: btnI81.Image = img; break;
                    }
                }
            }

            //Prints accessories
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < Size; col++) {
                    Image img = ImageController.GetPlayerAccessoryImage(row * Size + col);

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
                        case 15: btnA15.Image = img; break;
                        case 16: btnA16.Image = img; break;
                        case 17: btnA17.Image = img; break;
                        case 18: btnA18.Image = img; break;
                    }
                }
            }

            //Prints gear
            for (int i = 0; i < Size; i++) {
                Image img = ImageController.GetPlayerGearImage(i);

                switch (i + 1) {
                    case 1: btnG1.Image = img; break;
                    case 2: btnG2.Image = img; break;
                    case 3: btnG3.Image = img; break;
                    case 4: btnG4.Image = img; break;
                    case 5: btnG5.Image = img; break;
                    case 6: btnG6.Image = img; break;
                    case 7: btnG7.Image = img; break;
                    case 8: btnG8.Image = img; break;
                    case 9: btnG9.Image = img; break;
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

        protected void OnBtnP50Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(50);
            }
        }

        protected void OnBtnP51Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(51);
            }
        }

        protected void OnBtnP52Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(52);
            }
        }

        protected void OnBtnP53Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(53);
            }
        }

        protected void OnBtnP54Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(54);
            }
        }

        protected void OnBtnP55Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(55);
            }
        }

        protected void OnBtnP56Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(56);
            }
        }

        protected void OnBtnP57Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(57);
            }
        }

        protected void OnBtnP58Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(58);
            }
        }

        protected void OnBtnP59Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(59);
            }
        }

        protected void OnBtnP60Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(60);
            }
        }

        protected void OnBtnP61Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(61);
            }
        }

        protected void OnBtnP62Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(62);
            }
        }

        protected void OnBtnP63Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(63);
            }
        }

        protected void OnBtnP64Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(64);
            }
        }

        protected void OnBtnP65Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(65);
            }
        }

        protected void OnBtnP66Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(66);
            }
        }

        protected void OnBtnP67Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(67);
            }
        }

        protected void OnBtnP68Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(68);
            }
        }

        protected void OnBtnP69Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(69);
            }
        }

        protected void OnBtnP70Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(70);
            }
        }

        protected void OnBtnP71Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(71);
            }
        }

        protected void OnBtnP72Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(72);
            }
        }

        protected void OnBtnP73Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(73);
            }
        }

        protected void OnBtnP74Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(74);
            }
        }

        protected void OnBtnP75Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(75);
            }
        }

        protected void OnBtnP76Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(76);
            }
        }

        protected void OnBtnP77Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(77);
            }
        }

        protected void OnBtnP78Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(78);
            }
        }

        protected void OnBtnP79Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(79);
            }
        }

        protected void OnBtnP80Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(80);
            }
        }

        protected void OnBtnP81Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                React(81);
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

        protected void OnBtnH8Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("hotbar", 7);
                this.PrintMainMenu();
            }
        }

        protected void OnBtnH9Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("hotbar", 8);
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

        protected void OnBtnI50Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 49);
                this.PrintInventory();
            }
        }

        protected void OnBtnI51Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 50);
                this.PrintInventory();
            }
        }

        protected void OnBtnI52Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 51);
                this.PrintInventory();
            }
        }

        protected void OnBtnI53Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 52);
                this.PrintInventory();
            }
        }

        protected void OnBtnI54Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 53);
                this.PrintInventory();
            }
        }

        protected void OnBtnI55Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 54);
                this.PrintInventory();
            }
        }

        protected void OnBtnI56Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 55);
                this.PrintInventory();
            }
        }

        protected void OnBtnI57Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 56);
                this.PrintInventory();
            }
        }

        protected void OnBtnI58Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 57);
                this.PrintInventory();
            }
        }

        protected void OnBtnI59Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 58);
                this.PrintInventory();
            }
        }

        protected void OnBtnI60Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 59);
                this.PrintInventory();
            }
        }

        protected void OnBtnI61Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 60);
                this.PrintInventory();
            }
        }

        protected void OnBtnI62Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 61);
                this.PrintInventory();
            }
        }

        protected void OnBtnI63Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 62);
                this.PrintInventory();
            }
        }

        protected void OnBtnI64Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 63);
                this.PrintInventory();
            }
        }

        protected void OnBtnI65Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 64);
                this.PrintInventory();
            }
        }

        protected void OnBtnI66Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 65);
                this.PrintInventory();
            }
        }

        protected void OnBtnI67Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 66);
                this.PrintInventory();
            }
        }

        protected void OnBtnI68Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 67);
                this.PrintInventory();
            }
        }

        protected void OnBtnI69Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 68);
                this.PrintInventory();
            }
        }

        protected void OnBtnI70Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 69);
                this.PrintInventory();
            }
        }

        protected void OnBtnI71Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 70);
                this.PrintInventory();
            }
        }

        protected void OnBtnI72Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 71);
                this.PrintInventory();
            }
        }

        protected void OnBtnI73Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 72);
                this.PrintInventory();
            }
        }

        protected void OnBtnI74Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 73);
                this.PrintInventory();
            }
        }

        protected void OnBtnI75Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 74);
                this.PrintInventory();
            }
        }

        protected void OnBtnI76Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 75);
                this.PrintInventory();
            }
        }

        protected void OnBtnI77Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 76);
                this.PrintInventory();
            }
        }

        protected void OnBtnI78Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 77);
                this.PrintInventory();
            }
        }

        protected void OnBtnI79Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 78);
                this.PrintInventory();
            }
        }

        protected void OnBtnI80Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 79);
                this.PrintInventory();
            }
        }

        protected void OnBtnI81Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("items", 80);
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

        protected void OnBtnA15Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("accessories", 14);
                this.PrintInventory();
            }
        }

        protected void OnBtnA16Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("accessories", 15);
                this.PrintInventory();
            }
        }

        protected void OnBtnA17Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("accessories", 16);
                this.PrintInventory();
            }
        }

        protected void OnBtnA18Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("accessories", 17);
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

        protected void OnBtnG8Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("gear", 7);
                this.PrintInventory();
            }
        }

        protected void OnBtnG9Clicked(object sender, EventArgs e) {
            if (!WindowController.PauseWindowVisible) {
                this.SelectItem("gear", 8);
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
            imgG50.Visible = isVisible;
            imgG51.Visible = isVisible;
            imgG52.Visible = isVisible;
            imgG53.Visible = isVisible;
            imgG54.Visible = isVisible;
            imgG55.Visible = isVisible;
            imgG56.Visible = isVisible;
            imgG57.Visible = isVisible;
            imgG58.Visible = isVisible;
            imgG59.Visible = isVisible;
            imgG60.Visible = isVisible;
            imgG61.Visible = isVisible;
            imgG62.Visible = isVisible;
            imgG63.Visible = isVisible;
            imgG64.Visible = isVisible;
            imgG65.Visible = isVisible;
            imgG66.Visible = isVisible;
            imgG67.Visible = isVisible;
            imgG68.Visible = isVisible;
            imgG69.Visible = isVisible;
            imgG70.Visible = isVisible;
            imgG71.Visible = isVisible;
            imgG72.Visible = isVisible;
            imgG73.Visible = isVisible;
            imgG74.Visible = isVisible;
            imgG75.Visible = isVisible;
            imgG76.Visible = isVisible;
            imgG77.Visible = isVisible;
            imgG78.Visible = isVisible;
            imgG79.Visible = isVisible;
            imgG80.Visible = isVisible;
            imgG81.Visible = isVisible;

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
            imgI50.Visible = isVisible;
            imgI51.Visible = isVisible;
            imgI52.Visible = isVisible;
            imgI53.Visible = isVisible;
            imgI54.Visible = isVisible;
            imgI55.Visible = isVisible;
            imgI56.Visible = isVisible;
            imgI57.Visible = isVisible;
            imgI58.Visible = isVisible;
            imgI59.Visible = isVisible;
            imgI60.Visible = isVisible;
            imgI61.Visible = isVisible;
            imgI62.Visible = isVisible;
            imgI63.Visible = isVisible;
            imgI64.Visible = isVisible;
            imgI65.Visible = isVisible;
            imgI66.Visible = isVisible;
            imgI67.Visible = isVisible;
            imgI68.Visible = isVisible;
            imgI69.Visible = isVisible;
            imgI70.Visible = isVisible;
            imgI71.Visible = isVisible;
            imgI72.Visible = isVisible;
            imgI73.Visible = isVisible;
            imgI74.Visible = isVisible;
            imgI75.Visible = isVisible;
            imgI76.Visible = isVisible;
            imgI77.Visible = isVisible;
            imgI78.Visible = isVisible;
            imgI79.Visible = isVisible;
            imgI80.Visible = isVisible;
            imgI81.Visible = isVisible;

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
            btnI50.Visible = isVisible;
            btnI51.Visible = isVisible;
            btnI52.Visible = isVisible;
            btnI53.Visible = isVisible;
            btnI54.Visible = isVisible;
            btnI55.Visible = isVisible;
            btnI56.Visible = isVisible;
            btnI57.Visible = isVisible;
            btnI58.Visible = isVisible;
            btnI59.Visible = isVisible;
            btnI60.Visible = isVisible;
            btnI61.Visible = isVisible;
            btnI62.Visible = isVisible;
            btnI63.Visible = isVisible;
            btnI64.Visible = isVisible;
            btnI65.Visible = isVisible;
            btnI66.Visible = isVisible;
            btnI67.Visible = isVisible;
            btnI68.Visible = isVisible;
            btnI69.Visible = isVisible;
            btnI70.Visible = isVisible;
            btnI71.Visible = isVisible;
            btnI72.Visible = isVisible;
            btnI73.Visible = isVisible;
            btnI74.Visible = isVisible;
            btnI75.Visible = isVisible;
            btnI76.Visible = isVisible;
            btnI77.Visible = isVisible;
            btnI78.Visible = isVisible;
            btnI79.Visible = isVisible;
            btnI80.Visible = isVisible;
            btnI81.Visible = isVisible;
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
            btnA15.Visible = isVisible;
            btnA16.Visible = isVisible;
            btnA17.Visible = isVisible;
            btnA18.Visible = isVisible;

            lblGear.Visible = isVisible;
            btnG1.Visible = isVisible;
            btnG2.Visible = isVisible;
            btnG3.Visible = isVisible;
            btnG4.Visible = isVisible;
            btnG5.Visible = isVisible;
            btnG6.Visible = isVisible;
            btnG7.Visible = isVisible;
            btnG8.Visible = isVisible;
            btnG9.Visible = isVisible;

            imgInfo.Visible = isVisible;
            lblInfo.Visible = isVisible;

            lblBlank6.Visible = isVisible;
        }
    }
}
