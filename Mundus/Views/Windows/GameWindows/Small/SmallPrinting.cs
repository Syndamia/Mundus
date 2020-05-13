namespace Mundus.Views.Windows 
{
    using Gtk;
    using Mundus.Service;
    using Mundus.Service.SuperLayers;
    using Mundus.Service.Tiles.Items;
    using Mundus.Service.Tiles.Mobs.Controllers;

    public partial class SmallGameWindow 
    {
        /// <summary>
        /// Prints the screen that the player uses to interract with the game map
        /// </summary>
        public void PrintWorldScreen() 
        {
            for (int layer = 0; layer < 3; layer++) 
            {
                for (int row = Calculate.CalculateStartY(Size), maxY = Calculate.CalculateMaxY(Size), btn = 1; row <= maxY; row++) 
                {
                    for (int col = Calculate.CalculateStartX(Size), maxX = Calculate.CalculateMaxX(Size); col <= maxX; col++, btn++) 
                    {
                        Image img = ImageController.GetScreenImage(row, col, layer);

                        if (img == null) 
                        {
                            continue;
                        }

                        switch (btn) 
                        {
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
        /// Prints the energy, health and hot bars and log
        /// </summary>
        public void PrintMainMenu() 
        {
            this.PrintEnergyBar();
            this.PrintHealthBar();
            this.PrintHotBar();
            this.PrintLog();
        }

        /// <summary>
        /// Prints the inventory (items, accessories and gear)
        /// </summary>
        public void PrintInventory() 
        {
            this.PrintItemsInventory();
            this.PrintAccessoriesInventory();
            this.PrintGearInventory();
        }

        /// <summary>
        /// Prints the information that is avalable for the given item
        /// </summary>
        public void PrintSelectedItemInfo(ItemTile itemTile) 
        {
            if (itemTile != null) 
            {
                imgInfo.SetFromStock(itemTile.stock_id, IconSize.Dnd);
                lblInfo.Text = itemTile.ToString();
            }
            else 
            {
                imgInfo.SetFromImage(null, null);
                lblInfo.Text = null;
            }
        }

        /// <summary>
        /// Prints the map menu items (ground layer, structure layer, coordinates, current superlayer, there is hole on top of player)
        /// </summary>
        public void PrintMap() 
        {
            this.PrintGroundLayerMap();

            lblSuperLayer.Text = MobStatsController.GetPlayerSuperLayerName();
            lblCoord1.Text = "X: " + MobStatsController.GetPlayerXCoord();
            lblCoord2.Text = "Y: " + MobStatsController.GetPlayerYCoord();

            this.PrintStructureLayerMap();

            lblHoleOnTop.Text = MobStatsController.ExistsHoleOnTopOfPlayer() + string.Empty;
        }

        #region Main menu

        private void PrintEnergyBar() 
        {
            for (int i = 0; i < Size; i++) 
            {
                string iconName = MobStatsController.GetPlayerEnergyStock(i);

                switch (i) 
                {
                    case 0: imgS1.SetFromStock(iconName, IconSize.Dnd); break;
                    case 1: imgS2.SetFromStock(iconName, IconSize.Dnd); break;
                    case 2: imgS3.SetFromStock(iconName, IconSize.Dnd); break;
                    case 3: imgS4.SetFromStock(iconName, IconSize.Dnd); break;
                    case 4: imgS5.SetFromStock(iconName, IconSize.Dnd); break;
                }
            }
        }

        private void PrintHealthBar() 
        {
            for (int i = 0; i < Size; i++) 
            {
                string iconName = MobStatsController.GetPlayerHearthStock(i);

                switch (i) 
                {
                    case 0: imgS6.SetFromStock(iconName, IconSize.Dnd); break;
                    case 1: imgS7.SetFromStock(iconName, IconSize.Dnd); break;
                    case 2: imgS8.SetFromStock(iconName, IconSize.Dnd); break;
                    case 3: imgS9.SetFromStock(iconName, IconSize.Dnd); break;
                    case 4: imgS10.SetFromStock(iconName, IconSize.Dnd); break;
                }
            }
        }

        private void PrintHotBar() 
        {
            for (int i = 0; i < Size; i++) 
            {
                Image img = ImageController.GetPlayerHotbarImage(i);

                switch (i + 1) 
                {
                    case 1: btnH1.Image = img; break;
                    case 2: btnH2.Image = img; break;
                    case 3: btnH3.Image = img; break;
                    case 4: btnH4.Image = img; break;
                    case 5: btnH5.Image = img; break;
                }
            }
        }

        private void PrintLog() 
        {
            for (int i = 0, msgIndex = GameEventLogController.GetCount() - 1; i < Size; msgIndex--, i++) 
            {
                string msg = GameEventLogController.GetMessagage(msgIndex);

                switch (i) 
                {
                    case 0: lblLog1.Text = msg; break;
                    case 1: lblLog2.Text = msg; break;
                    case 2: lblLog3.Text = msg; break;
                    case 3: lblLog4.Text = msg; break;
                }
            }
        }

        #endregion

        #region Inventory

        private void PrintItemsInventory() {
            for (int row = 0; row < Size; row++) {
                for (int col = 0; col < Size; col++) {
                    Image img = ImageController.GetPlayerInventoryItemImage((row * Size) + col);

                    switch ((row * Size) + col + 1) {
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
        }

        private void PrintAccessoriesInventory() {
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < Size; col++) {
                    Image img = ImageController.GetPlayerAccessoryImage((row * Size) + col);

                    switch ((row * Size) + col + 1) {
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
        }

        private void PrintGearInventory() {
            for (int i = 0; i < Size; i++) {
                Image img = ImageController.GetPlayerGearImage(i);

                switch (i + 1) {
                    case 1: btnG1.Image = img; break;
                    case 2: btnG2.Image = img; break;
                    case 3: btnG3.Image = img; break;
                    case 4: btnG4.Image = img; break;
                    case 5: btnG5.Image = img; break;
                }
            }
        }

        #endregion

        #region Map

        private void PrintGroundLayerMap() 
        {
            for (int row = Calculate.CalculateStartY(Size), maxY = Calculate.CalculateMaxY(Size), img = 1; row <= maxY; row++) 
            {
                for (int col = Calculate.CalculateStartX(Size), maxX = Calculate.CalculateMaxX(Size); col <= maxX; col++, img++) 
                {
                    string stockName = ImageController.GetPlayerGroundImage(row, col).Stock;

                    switch (img) 
                    {
                        case 1: imgG1.SetFromStock(stockName, IconSize.Dnd); break;
                        case 2: imgG2.SetFromStock(stockName, IconSize.Dnd); break;
                        case 3: imgG3.SetFromStock(stockName, IconSize.Dnd); break;
                        case 4: imgG4.SetFromStock(stockName, IconSize.Dnd); break;
                        case 5: imgG5.SetFromStock(stockName, IconSize.Dnd); break;
                        case 6: imgG6.SetFromStock(stockName, IconSize.Dnd); break;
                        case 7: imgG7.SetFromStock(stockName, IconSize.Dnd); break;
                        case 8: imgG8.SetFromStock(stockName, IconSize.Dnd); break;
                        case 9: imgG9.SetFromStock(stockName, IconSize.Dnd); break;
                        case 10: imgG10.SetFromStock(stockName, IconSize.Dnd); break;
                        case 11: imgG11.SetFromStock(stockName, IconSize.Dnd); break;
                        case 12: imgG12.SetFromStock(stockName, IconSize.Dnd); break;
                        case 13: imgG13.SetFromStock(stockName, IconSize.Dnd); break;
                        case 14: imgG14.SetFromStock(stockName, IconSize.Dnd); break;
                        case 15: imgG15.SetFromStock(stockName, IconSize.Dnd); break;
                        case 16: imgG16.SetFromStock(stockName, IconSize.Dnd); break;
                        case 17: imgG17.SetFromStock(stockName, IconSize.Dnd); break;
                        case 18: imgG18.SetFromStock(stockName, IconSize.Dnd); break;
                        case 19: imgG19.SetFromStock(stockName, IconSize.Dnd); break;
                        case 20: imgG20.SetFromStock(stockName, IconSize.Dnd); break;
                        case 21: imgG21.SetFromStock(stockName, IconSize.Dnd); break;
                        case 22: imgG22.SetFromStock(stockName, IconSize.Dnd); break;
                        case 23: imgG23.SetFromStock(stockName, IconSize.Dnd); break;
                        case 24: imgG24.SetFromStock(stockName, IconSize.Dnd); break;
                        case 25: imgG25.SetFromStock(stockName, IconSize.Dnd); break;
                    }
                }
            }
        }

        private void PrintStructureLayerMap() 
        {
            for (int row = Calculate.CalculateStartY(Size), maxY = Calculate.CalculateMaxY(Size), img = 1; row <= maxY; row++) 
            {
                for (int col = Calculate.CalculateStartX(Size), maxX = Calculate.CalculateMaxX(Size); col <= maxX; col++, img++) 
                {
                    string stockName = ImageController.GetPlayerStructureImage(row, col).Stock;

                    switch (img) 
                    {
                        case 1: imgI1.SetFromStock(stockName, IconSize.Dnd); break;
                        case 2: imgI2.SetFromStock(stockName, IconSize.Dnd); break;
                        case 3: imgI3.SetFromStock(stockName, IconSize.Dnd); break;
                        case 4: imgI4.SetFromStock(stockName, IconSize.Dnd); break;
                        case 5: imgI5.SetFromStock(stockName, IconSize.Dnd); break;
                        case 6: imgI6.SetFromStock(stockName, IconSize.Dnd); break;
                        case 7: imgI7.SetFromStock(stockName, IconSize.Dnd); break;
                        case 8: imgI8.SetFromStock(stockName, IconSize.Dnd); break;
                        case 9: imgI9.SetFromStock(stockName, IconSize.Dnd); break;
                        case 10: imgI10.SetFromStock(stockName, IconSize.Dnd); break;
                        case 11: imgI11.SetFromStock(stockName, IconSize.Dnd); break;
                        case 12: imgI12.SetFromStock(stockName, IconSize.Dnd); break;
                        case 13: imgI13.SetFromStock(stockName, IconSize.Dnd); break;
                        case 14: imgI14.SetFromStock(stockName, IconSize.Dnd); break;
                        case 15: imgI15.SetFromStock(stockName, IconSize.Dnd); break;
                        case 16: imgI16.SetFromStock(stockName, IconSize.Dnd); break;
                        case 17: imgI17.SetFromStock(stockName, IconSize.Dnd); break;
                        case 18: imgI18.SetFromStock(stockName, IconSize.Dnd); break;
                        case 19: imgI19.SetFromStock(stockName, IconSize.Dnd); break;
                        case 20: imgI20.SetFromStock(stockName, IconSize.Dnd); break;
                        case 21: imgI21.SetFromStock(stockName, IconSize.Dnd); break;
                        case 22: imgI22.SetFromStock(stockName, IconSize.Dnd); break;
                        case 23: imgI23.SetFromStock(stockName, IconSize.Dnd); break;
                        case 24: imgI24.SetFromStock(stockName, IconSize.Dnd); break;
                        case 25: imgI25.SetFromStock(stockName, IconSize.Dnd); break;
                    }
                }
            }
        }

        #endregion

    }
}
