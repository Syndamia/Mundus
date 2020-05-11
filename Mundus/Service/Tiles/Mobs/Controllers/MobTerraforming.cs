using System.Linq;
using static Mundus.Data.Values;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.SuperLayers;
using Mundus.Service.SuperLayers;
using Mundus.Service.Tiles.Items;
using Mundus.Service.Tiles.Items.Presets;
using Mundus.Data;

namespace Mundus.Service.Tiles.Mobs.Controllers {
    public static class MobTerraforming {
        /// <summary>
        /// Tries to place a selected structure/ground tile or to mine/dig (destroy) at the selected location
        /// </summary>
        /// <param name="inventoryPlace">Place where the selected item is located ("hotbar", "items", ...)</param>
        /// <param name="inventoryIndex">Index of the place where the item is located</param>
        public static void PlayerTerraformAt(int mapYPos, int mapXPos, string inventoryPlace, int inventoryIndex) {
            var selectedItemType = Inventory.GetPlayerItem(inventoryPlace, inventoryIndex).GetType();

            // If player can place strucure
            if (selectedItemType == typeof(Structure)) {
                if (PlayerCanBuildStructureAt(mapYPos, mapXPos)) {
                    PlayerBuildStructureAt(mapYPos, mapXPos, inventoryPlace, inventoryIndex);
                    MI.Player.Inventory.DeleteItemTile(inventoryPlace, inventoryIndex);
                }
                else {
                    GameEventLogController.AddMessage($"Cannot build structure at Y:{mapYPos}, X:{mapXPos}");
                }

            }
            // If Player can place ground
            else if (selectedItemType == typeof(GroundTile)) {
                if (PlayerCanPlaceGroundAt(mapYPos, mapXPos)) {
                    PlayerPlaceGroundAt(mapYPos, mapXPos, inventoryPlace, inventoryIndex);
                    MI.Player.Inventory.DeleteItemTile(inventoryPlace, inventoryIndex);
                }
                else {
                    GameEventLogController.AddMessage($"Cannot place ground at Y:{mapYPos}, X:{mapXPos}");
                }
            }
            // If player can mine/dig
            else if (selectedItemType == typeof(Tool)) {
                if (PlayerCanDestroyAt(mapYPos, mapXPos)) {
                    PlayerDestroyAt(mapYPos, mapXPos, inventoryPlace, inventoryIndex);
                }
                else {
                    GameEventLogController.AddMessage($"Cannot destroy at Y:{mapYPos}, X:{mapXPos}");
                }
            }
        }

        // Player can't destory structures/ground tiles if there are none
        private static bool PlayerCanDestroyAt(int yPos, int xPos) {
            return MI.Player.CurrSuperLayer.GetStructureLayerStock(yPos, xPos) != null ||
                   MI.Player.CurrSuperLayer.GetGroundLayerStock(yPos, xPos) != null;
        }

        private const double ENERGY_TAKEN_FROM_DESTROYING = 0.6;
        private static void PlayerDestroyAt(int mapYPos, int mapXPos, string place, int index) {
            var selectedTool = (Tool)MI.Player.Inventory.GetItemTile(place, index);

            // Only shovels can destroy ground layer tiles, but not when there is something over the ground tile
            if (selectedTool.Type == ToolType.Shovel && MI.Player.CurrSuperLayer.GetStructureLayerStock(mapYPos, mapXPos) == null) {
                if (PlayerTryDestroyGroundAt(mapYPos, mapXPos, selectedTool)) {
                    MI.Player.DrainEnergy(ENERGY_TAKEN_FROM_DESTROYING + Values.DifficultyValueModifier());
                }
            }
            // Don't try to destroy structure if there is no structure
            else if (MI.Player.CurrSuperLayer.GetStructureLayerStock(mapYPos, mapXPos) != null) {
                if (PlayerTryDestroyStructureAt(mapYPos, mapXPos, selectedTool)) {
                    MI.Player.DrainEnergy(ENERGY_TAKEN_FROM_DESTROYING + Values.DifficultyValueModifier());
                }
            }
        }

        private static bool PlayerTryDestroyGroundAt(int mapYPos, int mapXPos, Tool shovel) {
            var selectedGround = GroundPresets.GetFromStock(MI.Player.CurrSuperLayer.GetGroundLayerStock(mapYPos, mapXPos));

            // Ground tiles that should be unbreakable have a negative required shovel class
            if (selectedGround.ReqShovelClass <= shovel.Class && selectedGround.ReqShovelClass >= 0) {
                MI.Player.CurrSuperLayer.SetGroundAtPosition(null, mapYPos, mapXPos);

                ISuperLayerContext under = HeightController.GetLayerUnderneathMob(MI.Player);
                // When a shovel destroys ground tile, it destroys the structure below it (but only if it is not walkable)
                if (under != null && under.GetStructureLayerStock(mapYPos, mapXPos) != null) {
                    if (!StructurePresets.GetFromStock(under.GetStructureLayerStock(mapYPos, mapXPos)).IsWalkable) {
                        under.RemoveStructureFromPosition(mapYPos, mapXPos);
                    }
                }

                if (MI.Player.Inventory.Items.Contains(null)) {
                    MI.Player.Inventory.AppendToItems(new GroundTile(selectedGround));
                }

                GameEventLogController.AddMessage($"Player destroyed \"{selectedGround.stock_id}\" from layer \"{MI.Player.CurrSuperLayer}\" at Y:{mapYPos}, X:{mapXPos}");
                return true;
            }
            else if (selectedGround.ReqShovelClass > shovel.Class) {
                GameEventLogController.AddMessage($"Ground \"{selectedGround.stock_id}\" requires minimum shovel class of: {selectedGround.ReqShovelClass}");
            }
            else { // selectedGround.ReqSHovelClass < 0
                GameEventLogController.AddMessage($"This ground cannot be destroyed.");
            }
            return false;
        }

        private static bool PlayerTryDestroyStructureAt(int mapYPos, int mapXPos, Tool tool) {
            var selStructure = StructurePresets.GetFromStock(MI.Player.CurrSuperLayer.GetStructureLayerStock(mapYPos, mapXPos));

            if (selStructure.ReqToolType == tool.Type && selStructure.ReqToolClass <= tool.Class) {
                int damagePoints = 1 + (tool.Class - selStructure.ReqToolClass);

                // Some structures have a "drop", a specific item that they give upon being damaged.
                // Other structures drop themselves (you "pick up" the structure after breaking it).
                if (selStructure.GetDrop() != selStructure) {
                    // The amount of dropped items it adds to inventory is that of the damage points.
                    // If the structure will "die" (health <= 0) before giving all items, it stops giving items.
                    for (int i = 0; i < damagePoints && i < selStructure.Health && MI.Player.Inventory.Items.Contains(null); i++) {
                        MI.Player.Inventory.AppendToItems(new Material((Material)selStructure.GetDrop()));
                    }
                }
                else if (MI.Player.Inventory.Items.Contains(null)) {
                    MI.Player.Inventory.AppendToItems((Structure)selStructure.GetDrop());
                }

                // Damage to the structure is done after adding the dropped item/items.
                if (!MI.Player.CurrSuperLayer.TakeDamageStructureAtPosition(mapYPos, mapXPos, damagePoints)) {
                    MI.Player.CurrSuperLayer.SetStructureAtPosition(null, -1, mapYPos, mapXPos);

                    GameEventLogController.AddMessage($"Player destroyed \"{selStructure.stock_id}\" from layer \"{MI.Player.CurrSuperLayer}\" at Y:{mapYPos}, X:{mapXPos}");
                }
                else {
                    GameEventLogController.AddMessage($"Player did {damagePoints} damage to \"{selStructure.stock_id}\"");
                }
                return true;
            }
            else if (selStructure.ReqToolType != tool.Type) {
                GameEventLogController.AddMessage($"Structure \"{selStructure.stock_id}\" requires tool type: {selStructure.ReqToolType}");
            }
            else { // selStructure.ReqToolClass > tool.Class
                GameEventLogController.AddMessage($"Structure \"{selStructure.stock_id}\" requires minimum tool class of: {selStructure.ReqToolClass}");
            }
            return false;
        }

        // Ground can be placed if there isnt a structure on an empty ground layer spot
        private static bool PlayerCanPlaceGroundAt(int yPos, int xPos) {
            return MI.Player.CurrSuperLayer.GetGroundLayerStock(yPos, xPos) == null &&
                   MI.Player.CurrSuperLayer.GetStructureLayerStock(yPos, xPos) == null;
        }

        private const double ENERGY_TAKEN_FROM_PLACING_GROUND = 0.4;
        private static void PlayerPlaceGroundAt(int yPos, int xPos, string inventoryPlace, int inventoryIndex) {
            GroundTile toPlace = (GroundTile)MI.Player.Inventory.GetItemTile(inventoryPlace, inventoryIndex);

            MI.Player.CurrSuperLayer.SetGroundAtPosition(toPlace.stock_id, yPos, xPos);
            MI.Player.DrainEnergy(ENERGY_TAKEN_FROM_PLACING_GROUND + Values.DifficultyValueModifier());

            GameEventLogController.AddMessage($"Set ground \"{toPlace.stock_id}\" on layer \"{MI.Player.CurrSuperLayer}\" at Y:{yPos}, X:{xPos}");
        }


        private static bool PlayerCanBuildStructureAt(int yPos, int xPos) {
            return MI.Player.CurrSuperLayer.GetStructureLayerStock(yPos, xPos) == null;
        }

        private const double ENERGY_TAKEN_FROM_BUILDING_STRUCTURE = 0.5;
        private static void PlayerBuildStructureAt(int yPos, int xPos, string inventoryPlace, int inventoryIndex) {
            Structure toBuild = (Structure)MI.Player.Inventory.GetItemTile(inventoryPlace, inventoryIndex);

            // Climable structures will be placed under a hole (if they can be).
            // Non climable structures won't be placed anywhere if there is a hole.
            if (toBuild.IsClimable && MI.Player.CurrSuperLayer.GetGroundLayerStock(yPos, xPos) == null && 
                HeightController.GetLayerUnderneathMob(MI.Player).GetStructureLayerStock(yPos, xPos) == null) 
            {
                HeightController.GetLayerUnderneathMob(MI.Player).SetStructureAtPosition(toBuild.stock_id, toBuild.Health, yPos, xPos);

                GameEventLogController.AddMessage($"Set structure \"{toBuild.stock_id}\" on layer \"{HeightController.GetLayerUnderneathMob(MI.Player)}\" at Y:{yPos}, X:{xPos}");
            }
            else if (MI.Player.CurrSuperLayer.GetGroundLayerStock(yPos, xPos) != null) {
                MI.Player.CurrSuperLayer.SetStructureAtPosition(toBuild.stock_id, toBuild.Health, yPos, xPos);

                GameEventLogController.AddMessage($"Set structure \"{toBuild.stock_id}\" on layer \"{MI.Player.CurrSuperLayer}\" at Y:{yPos}, X:{xPos}");
            }

            MI.Player.DrainEnergy(ENERGY_TAKEN_FROM_BUILDING_STRUCTURE + Values.DifficultyValueModifier());
        }
    }
}
