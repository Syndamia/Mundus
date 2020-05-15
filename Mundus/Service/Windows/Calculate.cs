namespace Mundus.Service.Windows 
{
    using System;
    using Mundus.Data;
    using Mundus.Data.Superlayers.Mobs;

    /// <summary>
    /// Used to calculate values, related to the buttons on the game windows
    /// </summary>
    public static class Calculate 
    {
        /*Depending on whether you are on the edge of the map or in the center, the screen renders a bit differently.
         *On the edge it doesn't follow the player and only shows the corner "chunk". In the other parts it follows the
         *the player, making sure he stays in the center of the screen.
         *This means that when the player is followed, rendered part of the map depend on the player position, but when
         *he isn't, it depends on the screen and map sizes.*/

        public static int CalculateMaxY(int size) 
        {
            int maxY = MI.Player.YPos + (size / 2);

            // If you are on the top edge of the map
            if (MI.Player.YPos - (size / 2) < 0) 
            {
                maxY = size - 1;
            }

            // If you are on the bottom edge of the map
            else if (maxY >= (int)Values.CurrMapSize) 
            {
                maxY = (int)Values.CurrMapSize - 1;
            }

            return maxY;
        }

        public static int CalculateStartY(int size) 
        {
            int startY = MI.Player.YPos - (size / 2);

            // If you are on the top edge of the map
            if (startY < 0) 
            {
                startY = 0;
            }

            // If you are on the bottom edge of the map
            else if (MI.Player.YPos - (size / 2) > (int)Values.CurrMapSize - size) 
            {
                startY = (int)Values.CurrMapSize - size;
            }

            return startY;
        }

        public static int CalculateMaxX(int size) 
        {
            int maxX = MI.Player.XPos + (size / 2);

            // If you are on the leftmost edge of the map
            if (MI.Player.XPos - (size / 2) < 0) 
            {
                maxX = size - 1;
            }

            // If you are on the rightmost edge of the map
            else if (maxX >= (int)Values.CurrMapSize) 
            {
                maxX = (int)Values.CurrMapSize - 1;
            }

            return maxX;
        }

        public static int CalculateStartX(int size) 
        {
            int startX = MI.Player.XPos - (size / 2);

            // If you are on the leftmost edge
            if (startX < 0) 
            {
                startX = 0;
            }

            // If you are on the rightmost edge
            if (MI.Player.XPos - (size / 2) > (int)Values.CurrMapSize - size) 
            {
                startX = (int)Values.CurrMapSize - size;
            }

            return startX;
        }

        // Screen buttons show only a certain part of the whole map

        public static int CalculateYFromButton(int buttonYPos, int size) 
        {
            int newYPos = MI.Player.YPos - (size / 2) + buttonYPos;

            // If you are on the top edge of the map
            if (MI.Player.YPos - (size / 2) < 0) 
            {
                newYPos = buttonYPos;
            }

            // If you are on the bottom edge of the map
            if (MI.Player.YPos > (int)Values.CurrMapSize - Math.Ceiling(size / 2.0)) 
            {
                newYPos = buttonYPos + (int)Values.CurrMapSize - size;
            }

            return newYPos;
        }

        public static int CalculateXFromButton(int buttonXPos, int size) 
        {
            int newXPos = MI.Player.XPos - (size / 2) + buttonXPos;

            // If you are on the leftmost edge of the map
            if (MI.Player.XPos - (size / 2) < 0) 
            {
                newXPos = buttonXPos;
            }

            // If you are on the rightmost edge of the map
            else if (MI.Player.XPos > (int)Values.CurrMapSize - Math.Ceiling(size / 2.0)) 
            {
                newXPos = buttonXPos + (int)Values.CurrMapSize - size;
            }

            return newXPos;
        }
    }
}
