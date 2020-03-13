using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;

namespace Mundus.Service.Mobs {
    public static class MobMoving {
        public static void MovePlayer(int yPos, int xPos, int size) {
            ChangePosition(LMI.Player, yPos, xPos, size);
        }

        public static void ChangePosition(IMob mob, int yPos, int xPos, int size) {
            if (yPos >= 0 && xPos >= 0 && yPos < MapSizes.CurrSize && xPos < MapSizes.CurrSize) {
                ChangePosition(mob, yPos, xPos);
            }
        }

        public static void ChangePosition(IMob mob, int yPos, int xPos) {
            if (Walkable(mob, yPos, xPos)) {
                mob.CurrSuperLayer.RemoveMobFromPosition( mob.YPos, mob.XPos );
                mob.YPos = yPos;
                mob.XPos = xPos;
                mob.CurrSuperLayer.SetMobAtPosition( mob.Tile, yPos, xPos );
            }
        }

        private static bool Walkable(IMob mob, int yPos, int xPos) {
            return (mob.CurrSuperLayer.GetStructureLayerTile(yPos, xPos) == null ||
                    mob.CurrSuperLayer.GetStructureLayerTile(yPos, xPos).IsWalkable) ||
                    mob.CurrSuperLayer.GetMobLayerTile(yPos, xPos) != null;
        }

        public static bool PlayerCanWalkTo(int yPos, int xPos) {
            return Walkable(LMI.Player, yPos, xPos);
        }
    }
}
