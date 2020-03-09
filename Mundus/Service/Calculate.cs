using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;

namespace Mundus.Service {
    public static class Calculate {
        /*Depending on whether you are on the edge of the map or in the center, the screen renders a bit differently.
         *On the edge it doesn't follow the player and only shows the corner "chunk". In the other parts it follows the
         *the player, making sure he stays in the center of the screen.
         *This means that when the player is followed, rendered part of the map depend on the player position, but when
         *he isn't, it depends on the screen and map sizes.*/
        public static int CalculateMaxY(int size) {
            int maxY = (LMI.Player.YPos - 2 >= 0) ? LMI.Player.YPos + 2 : size - 1;
            if (maxY >= MapSizes.CurrSize) maxY = MapSizes.CurrSize - 1;
            return maxY;
        }
        public static int CalculateStartY(int size) {
            int startY = (LMI.Player.YPos - 2 <= MapSizes.CurrSize - size) ? LMI.Player.YPos - 2 : MapSizes.CurrSize - size;
            if (startY < 0) startY = 0;
            return startY;
        }
        public static int CalculateMaxX(int size) {
            int maxX = (LMI.Player.XPos - 2 >= 0) ? LMI.Player.XPos + 2 : size - 1;
            if (maxX >= MapSizes.CurrSize) maxX = MapSizes.CurrSize - 1;
            return maxX;
        }
        public static int CalculateStartX(int size) {
            int startX = (LMI.Player.XPos - 2 <= MapSizes.CurrSize - size) ? LMI.Player.XPos - 2 : MapSizes.CurrSize - size;
            if (startX < 0) startX = 0;
            return startX;
        }
    }
}
