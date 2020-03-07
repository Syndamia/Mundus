using System;
using Gtk;
using Mundus.Models;
using Mundus.Models.Tiles;
using Mundus.Models.SuperLayers;
using Mundus.Views.Windows.Interfaces;
using Mundus.Models.Mobs.Land_Mobs;
using Mundus.Controllers.Mob;
using System.ComponentModel;

namespace Mundus.Views.Windows {
    public partial class SmallGameWindow : Gtk.Window, IGameWindow {
        /*Constant for the height and width of the game screen, map screens and inventory screen
         *and the width of stats, hotbar, accessories, gear & items on the ground menus*/
        public const int SIZE = 5;

        public SmallGameWindow() : base( Gtk.WindowType.Toplevel ) {
            this.Build();
        }

        public void OnDeleteEvent(object o, Gtk.DeleteEventArgs args) {
            //Open exit dialogue if you haven't saved in a while
            if (false) { //TODO: check if you have saved
                //TODO: pause game cycle

                ResponseType rt = (ResponseType)DI.DExit.Run();
                DI.DExit.Hide();

                if(rt == ResponseType.Cancel || rt == ResponseType.DeleteEvent) {
                    //cancel the exit procedure and keep the window open
                    args.RetVal = true;
                    return;
                }
                else if (rt == ResponseType.Accept) {
                    //TODO: call code for saving the game
                }
            }

            Application.Quit();
        }

        public void SetDefaults() {
            this.SetMapMenuVisibility(false);
            this.SetInvMenuVisibility(false);
            WI.WPause.GameWindow = this;

        }

        protected void OnBtnPauseClicked(object sender, EventArgs e) {
            //TODO: add code that stops (pauses) game cycle
            WI.WPause.Show();
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

            btnGM1.Visible = isVisible;
            btnGM2.Visible = isVisible;
            btnGM3.Visible = isVisible;

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

            btnIM1.Visible = isVisible;
            btnIM2.Visible = isVisible;
            btnIM3.Visible = isVisible;

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

            lblItemsOnGround.Visible = isVisible;
            btnIG1.Visible = isVisible;
            btnIG2.Visible = isVisible;
            btnIG3.Visible = isVisible;
            btnIG4.Visible = isVisible;
            btnIG5.Visible = isVisible; 
            btnIG6.Visible = isVisible;
            btnIG7.Visible = isVisible;
            btnIG8.Visible = isVisible;
            btnIG9.Visible = isVisible;
            btnIG10.Visible = isVisible;

            lblBlank4.Visible = isVisible;
        }

        private bool InvMenuIsVisible() {
            return btnI1.Visible;
        }

        protected void OnBtnMusicClicked(object sender, EventArgs e) {
            WI.WMusic.Show();
        }

        public void PrintScreen() {
            ISuperLayer superLayer = LMI.Player.CurrSuperLayer;

            for(int i = 0; i < 3; i++) {
                int btn = 1;
                for (int row = this.CalculateStartY(), maxY = this.CalculateMaxY(); row <= maxY; row++) {
                    for (int col = this.CalculateStartX(), maxX = this.CalculateMaxX(); col <= maxX; col++, btn++) {
                        //Set the image to be either the ground layer tile, "blank" icon, item layer tile, mob layer tile or don't set it to anything 
                        //Note: first the ground and the blank icons are printed, then over them are printed the item tiles and over them are mob tiles
                        Image img = new Image();

                        if (i == 0) {
                            if (superLayer.GetGroundLayerTile( row, col ) == null) {
                                img = new Image( "blank", IconSize.Dnd );
                            }
                            else {
                                img = new Image( superLayer.GetGroundLayerTile( row, col ).stock_id, IconSize.Dnd );
                            }
                        } 
                        else if (i == 1) {
                            if (superLayer.GetItemLayerTile( row, col ) == null) continue;
                            img = new Image( superLayer.GetItemLayerTile( row, col ).stock_id, IconSize.Dnd );
                        }
                        else {
                            if (superLayer.GetMobLayerTile( row, col ) == null) continue;
                            img = new Image( superLayer.GetMobLayerTile( row, col ).stock_id, IconSize.Dnd );
                        }

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

        public void PrintMap() {
            //TODO: get the superlayer that the player is in
            ISuperLayer superLayer = LI.Land;

            string sName;

            //Prints the "Ground layer" in map menu
            int img = 1;
            for (int row = this.CalculateStartY(), maxY = this.CalculateMaxY(); row <= maxY; row++) {
                for (int col = this.CalculateStartX(), maxX = this.CalculateMaxX(); col <= maxX; col++, img++) {
                    //Print a tile if it exists, otherwise print the "blank" icon
                    if (row < 0 || col < 0 || col >= MapSizes.CurrSize || row >= MapSizes.CurrSize) {
                        sName = "blank";
                    }
                    else if (superLayer.GetGroundLayerTile( row, col ) == null) {
                        sName = "blank";
                    }
                    else {
                        sName = superLayer.GetGroundLayerTile( row, col ).stock_id;
                    }

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

            //Prints the "Item layer" in map menu
            img = 1;
            for (int row = this.CalculateStartY(), maxY = this.CalculateMaxY(); row <= maxY; row++) {
                for (int col = this.CalculateStartX(), maxX = this.CalculateMaxX(); col <= maxX; col++, img++) {
                    //Print a tile if it exists, otherwise print the "blank" icon
                    if (row < 0 || col < 0 || col >= MapSizes.CurrSize || row >= MapSizes.CurrSize) {
                        sName = "blank";
                    }
                    else if (superLayer.GetItemLayerTile( row, col ) == null) {
                        sName = "blank";
                    }
                    else {
                        sName = superLayer.GetItemLayerTile( row, col ).stock_id;
                    }

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
        }

        public void PrintInventory() {

        }

        protected void OnBtnH1Clicked(object sender, EventArgs e) {
            this.PrintScreen();
        }

        protected void OnBtnP1Clicked(object sender, EventArgs e) {
            ChangePosition(1);
        }

        protected void OnBtnP2Clicked(object sender, EventArgs e) {
            ChangePosition(2);
        }

        protected void OnBtnP3Clicked(object sender, EventArgs e) {
            ChangePosition(3);
        }

        protected void OnBtnP4Clicked(object sender, EventArgs e) {
            ChangePosition(4);
        }

        protected void OnBtnP5Clicked(object sender, EventArgs e) {
            ChangePosition(5);
        }

        protected void OnBtnP6Clicked(object sender, EventArgs e) {
            ChangePosition(6);
        }

        protected void OnBtnP7Clicked(object sender, EventArgs e) {
            ChangePosition(7);
        }

        protected void OnBtnP8Clicked(object sender, EventArgs e) {
            ChangePosition(8);
        }

        protected void OnBtnP9Clicked(object sender, EventArgs e) {
            ChangePosition(9);
        }

        protected void OnBtnP10Clicked(object sender, EventArgs e) {
            ChangePosition(10);
        }

        protected void OnBtnP11Clicked(object sender, EventArgs e) {
            ChangePosition(11);
        }

        protected void OnBtnP12Clicked(object sender, EventArgs e) {
            ChangePosition(12);
        }

        protected void OnBtnP13Clicked(object sender, EventArgs e) {
            ChangePosition(13);
        }

        protected void OnBtnP14Clicked(object sender, EventArgs e) {
            ChangePosition(14);
        }

        protected void OnBtnP15Clicked(object sender, EventArgs e) {
            ChangePosition(15);
        }

        protected void OnBtnP16Clicked(object sender, EventArgs e) {
            ChangePosition(16);
        }

        protected void OnBtnP17Clicked(object sender, EventArgs e) {
            ChangePosition(17);
        }

        protected void OnBtnP18Clicked(object sender, EventArgs e) {
            ChangePosition(18);
        }

        protected void OnBtnP19Clicked(object sender, EventArgs e) {
            ChangePosition(19);
        }

        protected void OnBtnP20Clicked(object sender, EventArgs e) {
            ChangePosition(20);
        }

        protected void OnBtnP21Clicked(object sender, EventArgs e) {
            ChangePosition(21);
        }

        protected void OnBtnP22Clicked(object sender, EventArgs e) {
            ChangePosition(22);
        }

        protected void OnBtnP23Clicked(object sender, EventArgs e) {
            ChangePosition(23);
        }

        protected void OnBtnP24Clicked(object sender, EventArgs e) {
            ChangePosition(24);
        }

        protected void OnBtnP25Clicked(object sender, EventArgs e) {
            ChangePosition(25);
        }

        private void ChangePosition(int button) {
            int buttonYPos = (button - 1) / 5;
            int buttonXPos = button - buttonYPos * 5 - 1;

            int newYPos = (LMI.Player.YPos - 2 >= 0) ? LMI.Player.YPos - 2 + buttonYPos : buttonYPos;
            if (LMI.Player.YPos > MapSizes.CurrSize - 3) newYPos = buttonYPos + MapSizes.CurrSize - SIZE;
            int newXPos = (LMI.Player.XPos - 2 >= 0) ? LMI.Player.XPos - 2 + buttonXPos : buttonXPos;
            if (LMI.Player.XPos > MapSizes.CurrSize - 3) newXPos = buttonXPos + MapSizes.CurrSize - SIZE;

            if (newYPos >= 0 && newXPos >= 0 && newYPos < MapSizes.CurrSize && newXPos < MapSizes.CurrSize) {
                MobMoving.MoveMob( LMI.Player, newYPos, newXPos );
            }

            this.PrintScreen();
            if (this.MapMenuIsVisible()) {
                this.PrintMap();
            }
        }

        /*Depending on whether you are on the edge of the map or in the center, the screen renders a bit differently.
         *On the edge it doesn't follow the player and only shows the corner "chunk". In the other parts it follows the
         *the player, making sure he stays in the center of the screen.
         *This means that when the player is followed, rendered part of the map depend on the player position, but when
         *he isn't, it depends on the screen and map sizes.*/
        private int CalculateMaxY() {
            int maxY = (LMI.Player.YPos - 2 >= 0) ? LMI.Player.YPos + 2 : SIZE - 1;
            if (maxY >= MapSizes.CurrSize) maxY = MapSizes.CurrSize - 1;
            return maxY;
        }
        private int CalculateStartY() {
            int startY = (LMI.Player.YPos - 2 <= MapSizes.CurrSize - SIZE) ? LMI.Player.YPos - 2 : MapSizes.CurrSize - SIZE;
            if (startY < 0) startY = 0;
            return startY;
        }
        private int CalculateMaxX() {
            int maxX = (LMI.Player.XPos - 2 >= 0) ? LMI.Player.XPos + 2 : SIZE - 1;
            if (maxX >= MapSizes.CurrSize) maxX = MapSizes.CurrSize - 1;
            return maxX;
        }
        private int CalculateStartX() {
            int startX = (LMI.Player.XPos - 2 <= MapSizes.CurrSize - SIZE) ? LMI.Player.XPos - 2 : MapSizes.CurrSize - SIZE;
            if (startX < 0) startX = 0;
            return startX;
        }
    }
}
