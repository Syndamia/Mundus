namespace Mundus.Service.Tiles.Mobs.Controllers 
{
    using System;
    using System.Linq;
    using Mundus.Data;
    using Mundus.Data.Tiles.Mobs;
    using Mundus.Service.Tiles.Items.Types;
    using static Mundus.Data.Values;

    public static class MobFighting 
    {
        /// <summary>
        /// Returns if for the specified position in the superlayer the payer is in, there exists a mob
        /// Returns false also if the specified positoin is the player's current position
        /// </summary>
        public static bool ExistsFightTargetForPlayer(int mapYPos, int mapXPos) 
        {
            return ExistsFightTargetForMob(MI.Player, mapYPos, mapXPos);
        }

        /// <summary>
        /// The player tries to damage mob on the specified map position
        /// Note: will fail of the player uses an invalid tool to fight with
        /// </summary>
        public static void PlayerTryFight(int mapYPos, int mapXPos) 
        {
            if (PlayerTryFightWithMobAtPosition(mapYPos, mapXPos)) 
            {
                MI.Player.DrainEnergy(TAKEN_ENERGY_FROM_FIGHTING + DifficultyValueModifier());
            }
        }

        /// <summary>
        /// Returns if for the specified position in the superlayer the given mob is in, there exists a mob
        /// Returns false also if the specified positoin is the mob's current position
        /// </summary>
        private static bool ExistsFightTargetForMob(MobTile mob, int mapYPos, int mapXPos) 
        {
            return mob.CurrSuperLayer.GetMobLayerStock(mapYPos, mapXPos) != null &&
                   !(mob.YPos == mapYPos && mob.XPos == mapXPos);
        }

        /// <summary>
        /// The given mob tries to damage the mob on the specified map position
        /// Note: will fail of the given mob uses an invalid item
        /// </summary>
        private static bool PlayerTryFightWithMobAtPosition(int mapYPos, int mapXPos) 
        {
            if (PlayerCanFightWithMob(mapYPos, mapXPos)) 
            {
                Tool selTool = (Tool)Inventory.GetPlayerItemFromItemSelection();
                MobTile targetMob = LandMobsPresets.GetFromStock(MI.Player.CurrSuperLayer.GetMobLayerStock(mapYPos, mapXPos));

                if (selTool.Class >= targetMob.Defense) 
                {
                    targetMob.XPos = mapXPos;
                    targetMob.YPos = mapYPos;

                    PlayerFightWithMob(targetMob, selTool);
                    return true;
                }

                GameEventLogController.AddMessage($"You need a tool class of atleast {targetMob.Defense} to fight this mob");
            }
            else if (MI.Player.CurrSuperLayer.GetMobLayerStock(mapYPos, mapXPos) == null) 
            {
                GameEventLogController.AddMessage($"There is no mob to fight on \"{MI.Player.CurrSuperLayer}\" at Y:{mapYPos}, X:{mapXPos}");
            }
            else 
            {
                GameEventLogController.AddMessage($"You need a Tool of type {Values.ToolType.Sword} to fight with other mobs");
            }

            return false;
        }

        /// <summary>
        /// Checks if there exists a mob at the given location in the player's superlayer
        /// and if the player has selected a proper fighting tool
        /// </summary>
        private static bool PlayerCanFightWithMob(int mapYPos, int mapXPos) 
        {
            return Inventory.GetPlayerItemFromItemSelection().GetType() == typeof(Tool) &&
                   ((Tool)Inventory.GetPlayerItemFromItemSelection()).Type == ToolType.Sword &&
                   MI.Player.CurrSuperLayer.GetMobLayerStock(mapYPos, mapXPos) != null;
        }

        /// <summary>
        /// Reduces health of target mob
        /// </summary>
        private static void PlayerFightWithMob(MobTile targetMob, Tool selTool) 
        {
            int damagePoints = 1 + (selTool.Class - targetMob.Defense);

            if (!MI.Player.CurrSuperLayer.TakeDamageMobAtPosition(targetMob.YPos, targetMob.XPos, damagePoints)) 
            {
                MI.Player.CurrSuperLayer.RemoveMobFromPosition(targetMob.YPos, targetMob.XPos);

                targetMob.XPos = -1;
                targetMob.YPos = -1;

                if (MI.Player.Inventory.Items.Contains(null)) 
                {
                    MI.Player.Inventory.AppendToItems(targetMob.DroppedUponDeath);
                }

                GameEventLogController.AddMessage($"Player killed \"{targetMob.stock_id}\"");
            }
            else 
            {
                GameEventLogController.AddMessage($"Player did {damagePoints} damage to \"{targetMob.stock_id}\"");
            }
        }
    }
}
