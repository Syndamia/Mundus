using System;
using Mundus.Models.Mobs;
using Mundus.Models.SuperLayers;

namespace Mundus.Controllers.Mob {
    public static class MobMoving {
        public static void MoveMob(IMob mob, int yPos, int xPos) {

        }

        private static void ChangePosition(IMob mob, int yPos, int xPos) {
            if (mob.CurrSuperLayer.GetItemLayerTile( yPos, xPos ) == null ||
                mob.CurrSuperLayer.GetItemLayerTile( yPos, xPos ).IsWalkable) {
                mob.CurrSuperLayer.RemoveMobFromPosition( mob.YPos, mob.XPos );
                mob.YPos = yPos;
                mob.XPos = xPos;
                mob.CurrSuperLayer.SetMobAtPosition( mob.Tile, yPos, xPos );
            }
        }
    }
}
