namespace Mundus.Views.Windows.GameWindows.Large 
{
    using Gtk;
    using Mundus.Service;
    using Mundus.Service.SuperLayers;
    using Mundus.Service.Tiles.Items;
    using Mundus.Service.Tiles.Mobs.Controllers;
    using Mundus.Service.Windows;

    public partial class LargeGameWindow  
    {
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
                    case 5: imgS6.SetFromStock(iconName, IconSize.Dnd); break;
                    case 6: imgS7.SetFromStock(iconName, IconSize.Dnd); break;
                    case 7: imgS8.SetFromStock(iconName, IconSize.Dnd); break;
                    case 8: imgS9.SetFromStock(iconName, IconSize.Dnd); break;
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
                    case 0: imgS10.SetFromStock(iconName, IconSize.Dnd); break;
                    case 1: imgS11.SetFromStock(iconName, IconSize.Dnd); break;
                    case 2: imgS12.SetFromStock(iconName, IconSize.Dnd); break;
                    case 3: imgS13.SetFromStock(iconName, IconSize.Dnd); break;
                    case 4: imgS14.SetFromStock(iconName, IconSize.Dnd); break;
                    case 5: imgS15.SetFromStock(iconName, IconSize.Dnd); break;
                    case 6: imgS16.SetFromStock(iconName, IconSize.Dnd); break;
                    case 7: imgS17.SetFromStock(iconName, IconSize.Dnd); break;
                    case 8: imgS18.SetFromStock(iconName, IconSize.Dnd); break;
                }
            }
        }

        private void PrintHotBar()  
        {
            for (int i = 0; i < Size; i++)  
            {
                Image img = ImageController.GetPlayerHotbarImage(i);

                switch (i)  
                {
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
                    case 4: lblLog5.Text = msg; break;
                    case 5: lblLog6.Text = msg; break;
                    case 7: lblLog7.Text = msg; break;
                    case 8: lblLog8.Text = msg; break;
                }
            }
        }

        #endregion

        #region Invenory

        private void PrintItemsInventory()  
        {
            for (int row = 0; row < Size; row++)  
            {
                for (int col = 0; col < Size; col++)  
                {
                    Image img = ImageController.GetPlayerInventoryItemImage((row * Size) + col);

                    switch ((row * Size) + col + 1)  
                    {
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
        }

        private void PrintAccessoriesInventory()  
        {
            for (int row = 0; row < 2; row++)  
            {
                for (int col = 0; col < Size; col++)  
                {
                    Image img = ImageController.GetPlayerAccessoryImage((row * Size) + col);

                    switch ((row * Size) + col + 1)  
                    {
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
        }

        private void PrintGearInventory()  
        {
            for (int i = 0; i < Size; i++)  
            {
                Image img = ImageController.GetPlayerGearImage(i);

                switch (i + 1)  
                {
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
                        case 26: imgG26.SetFromStock(stockName, IconSize.Dnd); break;
                        case 27: imgG27.SetFromStock(stockName, IconSize.Dnd); break;
                        case 28: imgG28.SetFromStock(stockName, IconSize.Dnd); break;
                        case 29: imgG29.SetFromStock(stockName, IconSize.Dnd); break;
                        case 30: imgG30.SetFromStock(stockName, IconSize.Dnd); break;
                        case 31: imgG31.SetFromStock(stockName, IconSize.Dnd); break;
                        case 32: imgG32.SetFromStock(stockName, IconSize.Dnd); break;
                        case 33: imgG33.SetFromStock(stockName, IconSize.Dnd); break;
                        case 34: imgG34.SetFromStock(stockName, IconSize.Dnd); break;
                        case 35: imgG35.SetFromStock(stockName, IconSize.Dnd); break;
                        case 36: imgG36.SetFromStock(stockName, IconSize.Dnd); break;
                        case 37: imgG37.SetFromStock(stockName, IconSize.Dnd); break;
                        case 38: imgG38.SetFromStock(stockName, IconSize.Dnd); break;
                        case 39: imgG39.SetFromStock(stockName, IconSize.Dnd); break;
                        case 40: imgG40.SetFromStock(stockName, IconSize.Dnd); break;
                        case 41: imgG41.SetFromStock(stockName, IconSize.Dnd); break;
                        case 42: imgG42.SetFromStock(stockName, IconSize.Dnd); break;
                        case 43: imgG43.SetFromStock(stockName, IconSize.Dnd); break;
                        case 44: imgG44.SetFromStock(stockName, IconSize.Dnd); break;
                        case 45: imgG45.SetFromStock(stockName, IconSize.Dnd); break;
                        case 46: imgG46.SetFromStock(stockName, IconSize.Dnd); break;
                        case 47: imgG47.SetFromStock(stockName, IconSize.Dnd); break;
                        case 48: imgG48.SetFromStock(stockName, IconSize.Dnd); break;
                        case 49: imgG49.SetFromStock(stockName, IconSize.Dnd); break;
                        case 50: imgG50.SetFromStock(stockName, IconSize.Dnd); break;
                        case 51: imgG51.SetFromStock(stockName, IconSize.Dnd); break;
                        case 52: imgG52.SetFromStock(stockName, IconSize.Dnd); break;
                        case 53: imgG53.SetFromStock(stockName, IconSize.Dnd); break;
                        case 54: imgG54.SetFromStock(stockName, IconSize.Dnd); break;
                        case 55: imgG55.SetFromStock(stockName, IconSize.Dnd); break;
                        case 56: imgG56.SetFromStock(stockName, IconSize.Dnd); break;
                        case 57: imgG57.SetFromStock(stockName, IconSize.Dnd); break;
                        case 58: imgG58.SetFromStock(stockName, IconSize.Dnd); break;
                        case 59: imgG59.SetFromStock(stockName, IconSize.Dnd); break;
                        case 60: imgG60.SetFromStock(stockName, IconSize.Dnd); break;
                        case 61: imgG61.SetFromStock(stockName, IconSize.Dnd); break;
                        case 62: imgG62.SetFromStock(stockName, IconSize.Dnd); break;
                        case 63: imgG63.SetFromStock(stockName, IconSize.Dnd); break;
                        case 64: imgG64.SetFromStock(stockName, IconSize.Dnd); break;
                        case 65: imgG65.SetFromStock(stockName, IconSize.Dnd); break;
                        case 66: imgG66.SetFromStock(stockName, IconSize.Dnd); break;
                        case 67: imgG67.SetFromStock(stockName, IconSize.Dnd); break;
                        case 68: imgG68.SetFromStock(stockName, IconSize.Dnd); break;
                        case 69: imgG69.SetFromStock(stockName, IconSize.Dnd); break;
                        case 70: imgG70.SetFromStock(stockName, IconSize.Dnd); break;
                        case 71: imgG71.SetFromStock(stockName, IconSize.Dnd); break;
                        case 72: imgG72.SetFromStock(stockName, IconSize.Dnd); break;
                        case 73: imgG73.SetFromStock(stockName, IconSize.Dnd); break;
                        case 74: imgG74.SetFromStock(stockName, IconSize.Dnd); break;
                        case 75: imgG75.SetFromStock(stockName, IconSize.Dnd); break;
                        case 76: imgG76.SetFromStock(stockName, IconSize.Dnd); break;
                        case 77: imgG77.SetFromStock(stockName, IconSize.Dnd); break;
                        case 78: imgG78.SetFromStock(stockName, IconSize.Dnd); break;
                        case 79: imgG79.SetFromStock(stockName, IconSize.Dnd); break;
                        case 80: imgG80.SetFromStock(stockName, IconSize.Dnd); break;
                        case 81: imgG81.SetFromStock(stockName, IconSize.Dnd); break;
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
                        case 26: imgI26.SetFromStock(stockName, IconSize.Dnd); break;
                        case 27: imgI27.SetFromStock(stockName, IconSize.Dnd); break;
                        case 28: imgI28.SetFromStock(stockName, IconSize.Dnd); break;
                        case 29: imgI29.SetFromStock(stockName, IconSize.Dnd); break;
                        case 30: imgI30.SetFromStock(stockName, IconSize.Dnd); break;
                        case 31: imgI31.SetFromStock(stockName, IconSize.Dnd); break;
                        case 32: imgI32.SetFromStock(stockName, IconSize.Dnd); break;
                        case 33: imgI33.SetFromStock(stockName, IconSize.Dnd); break;
                        case 34: imgI34.SetFromStock(stockName, IconSize.Dnd); break;
                        case 35: imgI35.SetFromStock(stockName, IconSize.Dnd); break;
                        case 36: imgI36.SetFromStock(stockName, IconSize.Dnd); break;
                        case 37: imgI37.SetFromStock(stockName, IconSize.Dnd); break;
                        case 38: imgI38.SetFromStock(stockName, IconSize.Dnd); break;
                        case 39: imgI39.SetFromStock(stockName, IconSize.Dnd); break;
                        case 40: imgI40.SetFromStock(stockName, IconSize.Dnd); break;
                        case 41: imgI41.SetFromStock(stockName, IconSize.Dnd); break;
                        case 42: imgI42.SetFromStock(stockName, IconSize.Dnd); break;
                        case 43: imgI43.SetFromStock(stockName, IconSize.Dnd); break;
                        case 44: imgI44.SetFromStock(stockName, IconSize.Dnd); break;
                        case 45: imgI45.SetFromStock(stockName, IconSize.Dnd); break;
                        case 46: imgI46.SetFromStock(stockName, IconSize.Dnd); break;
                        case 47: imgI47.SetFromStock(stockName, IconSize.Dnd); break;
                        case 48: imgI48.SetFromStock(stockName, IconSize.Dnd); break;
                        case 49: imgI49.SetFromStock(stockName, IconSize.Dnd); break;
                        case 50: imgI50.SetFromStock(stockName, IconSize.Dnd); break;
                        case 51: imgI51.SetFromStock(stockName, IconSize.Dnd); break;
                        case 52: imgI52.SetFromStock(stockName, IconSize.Dnd); break;
                        case 53: imgI53.SetFromStock(stockName, IconSize.Dnd); break;
                        case 54: imgI54.SetFromStock(stockName, IconSize.Dnd); break;
                        case 55: imgI55.SetFromStock(stockName, IconSize.Dnd); break;
                        case 56: imgI56.SetFromStock(stockName, IconSize.Dnd); break;
                        case 57: imgI57.SetFromStock(stockName, IconSize.Dnd); break;
                        case 58: imgI58.SetFromStock(stockName, IconSize.Dnd); break;
                        case 59: imgI59.SetFromStock(stockName, IconSize.Dnd); break;
                        case 60: imgI60.SetFromStock(stockName, IconSize.Dnd); break;
                        case 61: imgI61.SetFromStock(stockName, IconSize.Dnd); break;
                        case 62: imgI62.SetFromStock(stockName, IconSize.Dnd); break;
                        case 63: imgI63.SetFromStock(stockName, IconSize.Dnd); break;
                        case 64: imgI64.SetFromStock(stockName, IconSize.Dnd); break;
                        case 65: imgI65.SetFromStock(stockName, IconSize.Dnd); break;
                        case 66: imgI66.SetFromStock(stockName, IconSize.Dnd); break;
                        case 67: imgI67.SetFromStock(stockName, IconSize.Dnd); break;
                        case 68: imgI68.SetFromStock(stockName, IconSize.Dnd); break;
                        case 69: imgI69.SetFromStock(stockName, IconSize.Dnd); break;
                        case 70: imgI70.SetFromStock(stockName, IconSize.Dnd); break;
                        case 71: imgI71.SetFromStock(stockName, IconSize.Dnd); break;
                        case 72: imgI72.SetFromStock(stockName, IconSize.Dnd); break;
                        case 73: imgI73.SetFromStock(stockName, IconSize.Dnd); break;
                        case 74: imgI74.SetFromStock(stockName, IconSize.Dnd); break;
                        case 75: imgI75.SetFromStock(stockName, IconSize.Dnd); break;
                        case 76: imgI76.SetFromStock(stockName, IconSize.Dnd); break;
                        case 77: imgI77.SetFromStock(stockName, IconSize.Dnd); break;
                        case 78: imgI78.SetFromStock(stockName, IconSize.Dnd); break;
                        case 79: imgI79.SetFromStock(stockName, IconSize.Dnd); break;
                        case 80: imgI80.SetFromStock(stockName, IconSize.Dnd); break;
                        case 81: imgI81.SetFromStock(stockName, IconSize.Dnd); break;
                    }
                }
            }
        }

        #endregion
    }
}
