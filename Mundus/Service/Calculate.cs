using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;
using System;

namespace Mundus.Service {
    public static class Calculate {
        /*Depending on whether you are on the edge of the map or in the center, the screen renders a bit differently.
         *On the edge it doesn't follow the player and only shows the corner "chunk". In the other parts it follows the
         *the player, making sure he stays in the center of the screen.
         *This means that when the player is followed, rendered part of the map depend on the player position, but when
         *he isn't, it depends on the screen and map sizes.*/
        public static int CalculateMaxY(int size) {
            int maxY = (MI.Player.YPos - size/2 >= 0) ? MI.Player.YPos + size/2 : size - 1;
            if (maxY >= MapSizes.CurrSize) maxY = MapSizes.CurrSize - 1;
            return maxY;
        }
        public static int CalculateStartY(int size) {
            int startY = (MI.Player.YPos - size/2 <= MapSizes.CurrSize - size) ? MI.Player.YPos - size/2 : MapSizes.CurrSize - size;
            if (startY < 0) startY = 0;
            return startY;
        }
        public static int CalculateMaxX(int size) {
            int maxX = (MI.Player.XPos - size/2 >= 0) ? MI.Player.XPos + size/2 : size - 1;
            if (maxX >= MapSizes.CurrSize) maxX = MapSizes.CurrSize - 1;
            return maxX;
        }
        public static int CalculateStartX(int size) {
            int startX = (MI.Player.XPos - size/2 <= MapSizes.CurrSize - size) ? MI.Player.XPos - size/2 : MapSizes.CurrSize - size;
            if (startX < 0) startX = 0;
            return startX;
        }

        //Screen buttons show only a certain part of the whole map
        public static int CalculateYFromButton(int buttonYPos, int size) {
            int newYPos = (MI.Player.YPos - size/2 >= 0) ? MI.Player.YPos - size/2 + buttonYPos : buttonYPos;
            if (MI.Player.YPos > MapSizes.CurrSize - Math.Ceiling(size/2.0)) newYPos = buttonYPos + MapSizes.CurrSize - size;
            return newYPos;
        }
        public static int CalculateXFromButton(int buttonXPos, int size) {
            int newXPos = (MI.Player.XPos - size/2 >= 0) ? MI.Player.XPos - size/2 + buttonXPos : buttonXPos;
            if (MI.Player.XPos > MapSizes.CurrSize - Math.Ceiling(size/2.0)) newXPos = buttonXPos + MapSizes.CurrSize - size;
            return newXPos;
        }
    }
}
