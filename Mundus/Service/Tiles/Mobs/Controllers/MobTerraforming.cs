namespace Mundus.Service.Tiles.Mobs.Controllers 
{
    using System.Linq;
    using Mundus.Data;
    using Mundus.Data.SuperLayers;
    using Mundus.Data.Tiles.Mobs;
    using Mundus.Data.Tiles.Presets;
    using Mundus.Service.SuperLayers;
    using Mundus.Service.Tiles.Items.Types;
    using static Mundus.Data.Values;

    public static class MobTerraforming 
    {
        /// <summary>
        /// Tries to place a selected structure/ground tile or to mine/dig (destroy) at the selected location
        /// </summary>
        public static void PlayerTerraformAt(int mapYPos, int mapXPos) 
        {
            var selectedItemType = Inventory.GetPlayerItemFromItemSelection().GetType();

            // If player can place strucure
            if (selectedItemType == typeof(Structure)) 
            {
                PlayerTryBuildStructureAt(mapYPos, mapXPos);
            }

            // If Player can place ground
            else if (selectedItemType == typeof(GroundTile)) 
            {
                PlayerTryPlaceGroundAt(mapYPos, mapXPos);
            }

            // If player can mine/dig
            else if (selectedItemType == typeof(Tool)) 
            {
                PlayerTryDestroyAt(mapYPos, mapXPos);
            }
        }

        // Player can't destory structures/ground tiles if there are none
        private static bool PlayerCanDestroyAt(int yPos, int xPos) 
        {
            return MI.Player.CurrSuperLayer.GetStructureLayerStock(yPos, xPos) != null ||
                   MI.Player.CurrSuperLayer.GetGroundLayerStock(yPos, xPos) != null;
        }

        private static void PlayerTryDestroyAt(int mapYPos, int mapXPos) {
            if (PlayerCanDestroyAt(mapYPos, mapXPos)) 
            {
                var selectedTool = (Tool)Inventory.GetPlayerItemFromItemSelection();

                // Only shovels can destroy ground layer tiles, but not when there is something over the ground tile
                if (selectedTool.Type == ToolType.Shovel && MI.Player.CurrSuperLayer.GetStructureLayerStock(mapYPos, mapXPos) == null) 
                {
                    if (PlayerTryDestroyGroundAt(mapYPos, mapXPos, selectedTool)) 
                    {
                        MI.Player.DrainEnergy(ENERGY_TAKEN_FROM_DESTROYING + DifficultyValueModifier());
                    }
                }

                // Don't try to destroy structure if there is no structure
                else if (MI.Player.CurrSuperLayer.GetStructureLayerStock(mapYPos, mapXPos) != null) 
                {
                    if (PlayerTryDestroyStructureAt(mapYPos, mapXPos, selectedTool)) 
                    {
                        MI.Player.DrainEnergy(ENERGY_TAKEN_FROM_DESTROYING + DifficultyValueModifier());
                    }
                }
            }
            else 
            {
                GameEventLogController.AddMessage($"Cannot destroy at Y:{mapYPos}, X:{mapXPos}");
            }
        }

        private static bool PlayerTryDestroyGroundAt(int mapYPos, int mapXPos, Tool shovel) 
        {
            var selectedGround = GroundPresets.GetFromStock(MI.Player.CurrSuperLayer.GetGroundLayerStock(mapYPos, mapXPos));

            // Ground tiles that should be unbreakable have a negative required shovel class
            if (selectedGround.ReqShovelClass <= shovel.Class && selectedGround.ReqShovelClass >= 0) 
            {
                MI.Player.CurrSuperLayer.RemoveGroundFromPosition(mapYPos, mapXPos);

                ISuperLayerContext under = HeightController.GetSuperLayerUnderneathMob(MI.Player);

                // When a shovel destroys ground tile, it destroys the structure below it (but only if it is not walkable)
                if (under != null && under.GetStructureLayerStock(mapYPos, mapXPos) != null) 
                {
                    if (!StructurePresets.GetFromStock(under.GetStructureLayerStock(mapYPos, mapXPos)).IsWalkable) 
                    {
                        under.RemoveStructureFromPosition(mapYPos, mapXPos);
                    }
                }

                if (MI.Player.Inventory.Items.Contains(null)) 
                {
                    MI.Player.Inventory.AppendToItems(new GroundTile(selectedGround));
                }

                GameEventLogController.AddMessage($"Player destroyed \"{selectedGround.stock_id}\" from layer \"{MI.Player.CurrSuperLayer}\" at Y:{mapYPos}, X:{mapXPos}");
                return true;
            }
            else if (selectedGround.ReqShovelClass > shovel.Class) 
            {
                GameEventLogController.AddMessage($"Ground \"{selectedGround.stock_id}\" requires minimum shovel class of: {selectedGround.ReqShovelClass}");
            }
            else 
            {
                GameEventLogController.AddMessage($"This ground cannot be destroyed.");
            }

            return false;
        }

        private static bool PlayerTryDestroyStructureAt(int mapYPos, int mapXPos, Tool tool) 
        {
            var selStructure = StructurePresets.GetFromStock(MI.Player.CurrSuperLayer.GetStructureLayerStock(mapYPos, mapXPos));

            if (selStructure.ReqToolType == tool.Type && selStructure.ReqToolClass <= tool.Class) 
            {
                int damagePoints = 1 + (tool.Class - selStructure.ReqToolClass);

                // Some structures have a "drop", a specific item that they give upon being damaged.
                // Other structures drop themselves (you "pick up" the structure after breaking it).
                if (selStructure.GetDrop() != selStructure) 
                {
                    // The amount of dropped items it adds to inventory is that of the damage points.
                    // If the structure will "die" (health <= 0) before giving all items, it stops giving items.
                    for (int i = 0; i < damagePoints && i < selStructure.Health && MI.Player.Inventory.Items.Contains(null); i++) 
                    {
                        MI.Player.Inventory.AppendToItems(new Material((Material)selStructure.GetDrop()));
                    }
                }
                else if (MI.Player.Inventory.Items.Contains(null)) 
                {
                    MI.Player.Inventory.AppendToItems((Structure)selStructure.GetDrop());
                }

                // Damage to the structure is done after adding the dropped item/items.
                if (!MI.Player.CurrSuperLayer.TakeDamageStructureAtPosition(mapYPos, mapXPos, damagePoints)) 
                {
                    MI.Player.CurrSuperLayer.RemoveStructureFromPosition(mapYPos, mapXPos);

                    GameEventLogController.AddMessage($"Player destroyed \"{selStructure.stock_id}\" from layer \"{MI.Player.CurrSuperLayer}\" at Y:{mapYPos}, X:{mapXPos}");
                }
                else 
                {
                    GameEventLogController.AddMessage($"Player did {damagePoints} damage to \"{selStructure.stock_id}\"");
                }

                return true;
            }
            else if (selStructure.ReqToolType != tool.Type) 
            {
                GameEventLogController.AddMessage($"Structure \"{selStructure.stock_id}\" requires tool type: {selStructure.ReqToolType}");
            }
            else 
            {
                GameEventLogController.AddMessage($"Structure \"{selStructure.stock_id}\" requires minimum tool class of: {selStructure.ReqToolClass}");
            }

            return false;
        }

        // Ground can be placed if there isnt a structure on an empty ground layer spot
        private static bool PlayerCanPlaceGroundAt(int yPos, int xPos) 
        {
            return MI.Player.CurrSuperLayer.GetGroundLayerStock(yPos, xPos) == null &&
                   MI.Player.CurrSuperLayer.GetStructureLayerStock(yPos, xPos) == null;
        }


        private static void PlayerTryPlaceGroundAt(int yPos, int xPos) 
        {
            if (PlayerCanPlaceGroundAt(yPos, xPos)) 
            {
                GroundTile toPlace = (GroundTile)Inventory.GetPlayerItemFromItemSelection();

                MI.Player.CurrSuperLayer.SetGroundAtPosition(toPlace.stock_id, yPos, xPos);
                MI.Player.DrainEnergy(ENERGY_TAKEN_FROM_PLACING_GROUND + DifficultyValueModifier());

                GameEventLogController.AddMessage($"Set ground \"{toPlace.stock_id}\" on layer \"{MI.Player.CurrSuperLayer}\" at Y:{yPos}, X:{xPos}");

                Inventory.DeletePlayerItemTileFromItemSelection();
            }
            else 
            {
                GameEventLogController.AddMessage($"Cannot place ground at Y:{yPos}, X:{xPos}");
            }
        }

        private static bool PlayerCanBuildStructureAt(int yPos, int xPos) 
        {
            return MI.Player.CurrSuperLayer.GetStructureLayerStock(yPos, xPos) == null;
        }

        private static void PlayerTryBuildStructureAt(int yPos, int xPos) 
        {
            if (PlayerCanBuildStructureAt(yPos, xPos)) 
            {
                Structure toBuild = (Structure)Inventory.GetPlayerItemFromItemSelection();

                // Climable structures will be placed under a hole (if they can be).
                // Non climable structures won't be placed anywhere if there is a hole.
                if (toBuild.IsClimable && MI.Player.CurrSuperLayer.GetGroundLayerStock(yPos, xPos) == null &&
                    HeightController.GetSuperLayerUnderneathMob(MI.Player).GetStructureLayerStock(yPos, xPos) == null) 
                {
                    HeightController.GetSuperLayerUnderneathMob(MI.Player).SetStructureAtPosition(toBuild.stock_id, toBuild.Health, yPos, xPos);

                    GameEventLogController.AddMessage($"Set structure \"{toBuild.stock_id}\" on layer \"{HeightController.GetSuperLayerUnderneathMob(MI.Player)}\" at Y:{yPos}, X:{xPos}");
                }
                else if (MI.Player.CurrSuperLayer.GetGroundLayerStock(yPos, xPos) != null) 
                {
                    MI.Player.CurrSuperLayer.SetStructureAtPosition(toBuild.stock_id, toBuild.Health, yPos, xPos);

                    GameEventLogController.AddMessage($"Set structure \"{toBuild.stock_id}\" on layer \"{MI.Player.CurrSuperLayer}\" at Y:{yPos}, X:{xPos}");
                }

                MI.Player.DrainEnergy(ENERGY_TAKEN_FROM_BUILDING_STRUCTURE + Values.DifficultyValueModifier());

                Inventory.DeletePlayerItemTileFromItemSelection();
            }
            else 
            {
                GameEventLogController.AddMessage($"Cannot build structure at Y:{yPos}, X:{xPos}");
            }
        }
    }
}
