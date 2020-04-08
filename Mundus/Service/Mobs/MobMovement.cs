using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;

namespace Mundus.Service.Mobs {
    public static class MobMovement {
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
                mob.CurrSuperLayer.RemoveMobFromPosition(mob.YPos, mob.XPos);

                if (mob.CurrSuperLayer.GetGroundLayerTile(yPos, xPos) == null &&
                    mob.GetLayerUndearneathCurr() != null) {
                    mob.CurrSuperLayer = mob.GetLayerUndearneathCurr();
                }
                else if (mob.CurrSuperLayer.GetStructureLayerTile(yPos, xPos) != null) {
                    //Mobs can only climb to the superlayer on top of them, if there is a climable structure
                    //and there is a "hole" on top of the climable structure
                    if (mob.CurrSuperLayer.GetStructureLayerTile(yPos, xPos).IsClimable &&
                        mob.GetLayerOnTopOfCurr() != null &&
                        mob.GetLayerOnTopOfCurr().GetGroundLayerTile(yPos, xPos) == null) {
                        mob.CurrSuperLayer = mob.GetLayerOnTopOfCurr();
                    }
                }

                mob.YPos = yPos;
                mob.XPos = xPos;
                mob.CurrSuperLayer.SetMobAtPosition(mob.Tile, yPos, xPos);
            }
        }

        private static bool Walkable(IMob mob, int yPos, int xPos) {
            //Mobs can only walk on free ground (no structure on top) or walkable structures
            return (mob.CurrSuperLayer.GetStructureLayerTile(yPos, xPos) == null ||
                    mob.CurrSuperLayer.GetStructureLayerTile(yPos, xPos).IsWalkable) ||
                    mob.CurrSuperLayer.GetMobLayerTile(yPos, xPos) != null;
        }
    }
}
