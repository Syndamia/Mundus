namespace Mundus.Service.Tiles.Mobs.Controllers 
{
    using System;
    using Mundus.Data;
    using Mundus.Service.Tiles.Mobs;
    using Mundus.Service.Tiles.Items.Presets;
    using Mundus.Service.SuperLayers;
    using Mundus.Service.Tiles.Mobs.LandMobs;
    using static Mundus.Data.Values;

    public static class MobMovement 
    {
        private static Random rnd = new Random();

        /// <summary>
        /// Moves all mobs that have a RndMovementRate of more than one on a random tile 
        /// in a 3x3 radius (including the tile they are currently on)
        /// </summary>
        public static void MoveRandomlyAllMobs() 
        {
            foreach (var superLayer in DataBaseContexts.SuperLayerContexts) 
            {
                for (int y = 0; y < (int)Values.CurrMapSize; y++) 
                {
                    for (int x = 0; x < (int)Values.CurrMapSize; x++) 
                    {
                        MobTile mob = LandMobsPresets.GetFromStock(superLayer.GetMobLayerStock(y, x));

                        if (mob != null) 
                        {
                            // Checks validity of RndMovementRate and descides if a mob will move to another tile
                            if (mob.RndMovementRate > 0 && rnd.Next(0, mob.RndMovementRate) == 1) 
                            {
                                int newYPos = rnd.Next(y - 1, y + 2);
                                int newXPos = rnd.Next(x - 1, x + 2);

                                mob.XPos = x;
                                mob.YPos = y;
                                mob.CurrSuperLayer = superLayer;

                                ChangeMobPosition(mob, newYPos, newXPos, (int)Values.CurrMapSize);
                            }
                        }
                    }
                }
            }
        }

        public static void ChangeMobPosition(MobTile mob, int destinationYPos, int destinationXPos, int mapSize) 
        {
            if (InBoundaries(destinationYPos, destinationXPos)) 
            {
                if (CanWalkTo(mob, destinationYPos, destinationXPos)) 
                {
                    ChangeMobPosition(mob, destinationYPos, destinationXPos);
                }
                else if (mob.GetType() == typeof(Player)) 
                {
                    GameEventLogController.AddMessage($"Cannot walk to Y:{destinationYPos}, X:{destinationXPos}");
                }
            }
        }

        public static void MovePlayer(int yPos, int xPos, int mapSize) 
        {
            ChangeMobPosition(MI.Player, yPos, xPos, mapSize);

            if (MI.Player.YPos == yPos && MI.Player.XPos == xPos) 
            {
                MI.Player.DrainEnergy(TAKEN_ENERGY_FROM_MOVEMENT + Values.DifficultyValueModifier());
            }
        }

        private static void ChangeMobPosition(MobTile mob, int yPos, int xPos) 
        {
            // Mob is removed from his current superlayer and in the end is added to the new one
            // Note: mob could not move, but will still be removed and readded to the superlayer
            mob.CurrSuperLayer.RemoveMobFromPosition(mob.YPos, mob.XPos);

            // If mob can go down a layer from a hole
            if (mob.CurrSuperLayer.GetGroundLayerStock(yPos, xPos) == null &&
                HeightController.GetSuperLayerUnderneathMob(mob) != null) 
            {
                MobDescendASuperLayer(mob, yPos, xPos);
            }

            // If mob can go down a layer from non-solid ground
            else if (!GroundPresets.GetFromStock(mob.CurrSuperLayer.GetGroundLayerStock(yPos, xPos)).Solid &&
                     HeightController.GetSuperLayerUnderneathMob(mob) != null) 
            {
                MobDescendASuperLayer(mob, yPos, xPos);
            }

            // If mob can climb up
            else if (mob.CurrSuperLayer.GetStructureLayerStock(yPos, xPos) != null &&
                     HeightController.GetSuperLayerAboveMob(mob).GetMobLayerStock(yPos, xPos) == null) 
            {
                MobAscendASuperLayer(mob, yPos, xPos);
            }
            else if (HeightController.GetSuperLayerAboveMob(mob).GetMobLayerStock(yPos, xPos) != null && mob.GetType() == typeof(Player)) 
            {
                GameEventLogController.AddMessage($"Cannot climb up a superlayer, {HeightController.GetSuperLayerAboveMob(mob).GetMobLayerStock(yPos, xPos)} is blocking the way");
            }

            mob.YPos = yPos;
            mob.XPos = xPos;

            mob.CurrSuperLayer.SetMobAtPosition(mob.stock_id, mob.Health, yPos, xPos);
        }

        private static void MobDescendASuperLayer(MobTile mob, int yPos, int xPos) 
        {
            if (HeightController.GetSuperLayerUnderneathMob(mob).GetMobLayerStock(yPos, xPos) == null) 
            {
                mob.CurrSuperLayer = HeightController.GetSuperLayerUnderneathMob(mob);

                if (mob.GetType() == typeof(Player)) 
                {
                    GameEventLogController.AddMessage($"Player descend a superlayer, to {mob.CurrSuperLayer}");
                }
            }
            else if (mob.GetType() == typeof(Player)) 
            {
                GameEventLogController.AddMessage($"Cannot descend a superlayer, blocked by {HeightController.GetSuperLayerUnderneathMob(mob).GetMobLayerStock(yPos, xPos)}");
            }
        }

        private static void MobAscendASuperLayer(MobTile mob, int yPos, int xPos) 
        {
            if (StructurePresets.GetFromStock(mob.CurrSuperLayer.GetStructureLayerStock(yPos, xPos)).IsClimable &&
                HeightController.GetSuperLayerAboveMob(mob) != null) 
                {
                var superLayerAbove = HeightController.GetSuperLayerAboveMob(mob);

                // To ascend, the ground above mustn't be solid or exist and there are no mobs on top
                if (superLayerAbove.GetGroundLayerStock(yPos, xPos) == null ||
                    !GroundPresets.GetFromStock(superLayerAbove.GetGroundLayerStock(yPos, xPos)).Solid) 
                {
                    mob.CurrSuperLayer = superLayerAbove;

                    if (mob.GetType() == typeof(Player)) 
                    {
                        GameEventLogController.AddMessage($"Player ascended a superlayer");
                    }
                }
                else if (HeightController.GetSuperLayerAboveMob(mob).GetGroundLayerStock(yPos, xPos) != null && mob.GetType() == typeof(Player)) 
                {
                    GameEventLogController.AddMessage($"Cannot ascend a superlayer, there is solid ground above");
                }
            }
            else if (!StructurePresets.GetFromStock(mob.CurrSuperLayer.GetStructureLayerStock(yPos, xPos)).IsClimable && mob.GetType() == typeof(Player)) 
            {
                GameEventLogController.AddMessage($"Cannot ascend a superlayer using a \"{mob.CurrSuperLayer.GetStructureLayerStock(yPos, xPos)}\"");
            }
            else if (HeightController.GetSuperLayerAboveMob(mob) == null && mob.GetType() == typeof(Player)) 
            {
                GameEventLogController.AddMessage($"There is no superlayer to climb up to");
            }
        }

        private static bool CanWalkTo(MobTile mob, int yPos, int xPos) 
        {
            // Mobs can only walk on if there is no structure or the structure is walkable
            // Mobs can move to the same location they're in
            if (mob.CurrSuperLayer.GetStructureLayerStock(yPos, xPos) == null ||
                StructurePresets.GetFromStock(mob.CurrSuperLayer.GetStructureLayerStock(yPos, xPos)).IsWalkable) 
            {
                return mob.CurrSuperLayer.GetMobLayerStock(yPos, xPos) == null ||
                       (mob.YPos == yPos && mob.XPos == xPos);
            }
      
            return false;
        }

        /// <summary>
        /// Returns if the chosen new location is inside the boundaries of the map
        /// </summary>
        private static bool InBoundaries(int yPos, int xPos) 
        {
            return yPos >= 0 && xPos >= 0 && yPos < (int)Values.CurrMapSize && xPos < (int)Values.CurrMapSize;
        }
    }
}
