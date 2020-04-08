using System.Linq;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.SuperLayers;
using Mundus.Data.Tiles;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Mobs {
    public static class MobTerraforming {

        public static void PlayerDestroyAt(int mapYPos, int mapXPos, string place, int index) {
            //sel means selected
            if (LMI.Player.Inventory.GetTile(place, index).GetType() == typeof(Tool)) {
                var selTool = (Tool)LMI.Player.Inventory.GetTile(place, index);

                //Only shovels can destroy ground layer tiles, but not when there is something over the ground tile
                if (selTool.Type == ToolTypes.Shovel && LMI.Player.CurrSuperLayer.GetStructureLayerTile(mapYPos, mapXPos) == null) {
                    var selGround = LMI.Player.CurrSuperLayer.GetGroundLayerTile(mapYPos, mapXPos);

                    if (selGround.ReqShovelClass <= selTool.Class) {
                        LMI.Player.CurrSuperLayer.SetGroundAtPosition(null, mapYPos, mapXPos);

                        //When a shovel destroys ground tile, it destroys the structure below, if it is not walkable
                        ISuperLayer under = LMI.Player.GetLayerUndearneathCurr();
                        if (under != null && under.GetStructureLayerTile(mapYPos, mapXPos) != null) {
                            if (!under.GetStructureLayerTile(mapYPos, mapXPos).IsWalkable) {
                                under.RemoveStructureFromPosition(mapYPos, mapXPos);
                            }
                        }

                        if (LMI.Player.Inventory.Items.Contains(null) && selGround.DroppedMaterial != null) {
                            LMI.Player.Inventory.AppendToItems(new Material(selGround.DroppedMaterial));
                        }
                    }
                }
                else if (LMI.Player.CurrSuperLayer.GetStructureLayerTile(mapYPos, mapXPos) != null) {
                    var selStructure = LMI.Player.CurrSuperLayer.GetStructureLayerTile(mapYPos, mapXPos);

                    if (selStructure.ReqToolType == selTool.Type && selStructure.ReqToolClass <= selTool.Class) {
                        int damagePoints = 1 + (selTool.Class - selStructure.ReqToolClass);

                        if (selStructure.GetDrop() != selStructure) {
                            for (int i = 0; (i < damagePoints && i < selStructure.Health) && LMI.Player.Inventory.Items.Contains(null); i++) {
                                LMI.Player.Inventory.AppendToItems(new Material((Material)selStructure.GetDrop()));
                            }
                        }
                        else {
                            LMI.Player.Inventory.AppendToItems((Structure)selStructure.GetDrop());
                        }

                        if (!selStructure.Damage(damagePoints)) {
                            LMI.Player.CurrSuperLayer.SetStructureAtPosition(null, mapYPos, mapXPos);
                        }
                    }
                    else {
                        //TODO: add error to log
                    }
                }
            }
        }

        public static void PlayerBuildAt(int mapYPos, int mapXPos, string inventoryPlace, int inventoryPlaceIndex) {
            if (PlayerCanBuildAt(mapYPos, mapXPos)) {
                ItemTile[] toPlace = null;

                switch (inventoryPlace) {
                    case "hotbar": toPlace = LMI.Player.Inventory.Hotbar; break;
                    case "items": toPlace = LMI.Player.Inventory.Items; break;
                }

                if (toPlace != null) {
                    //Remove item from inventory, only if it is placed
                    if (PlayerBuildAt(mapYPos, mapXPos, (Structure)toPlace[inventoryPlaceIndex])) {
                        toPlace[inventoryPlaceIndex] = null;
                    }
                }
            }
        }

        private static bool PlayerBuildAt(int mapYPos, int mapXPos, Structure toPlace) {
            //You can't place things on top of "holes" (null in ground), but climable structures will be placed
            //under the hole (if they can be)
            if (toPlace.IsClimable && LMI.Player.CurrSuperLayer.GetGroundLayerTile(mapYPos, mapXPos) == null
                && LMI.Player.GetLayerUndearneathCurr().GetStructureLayerTile(mapYPos, mapXPos) == null) {
                LMI.Player.GetLayerUndearneathCurr().SetStructureAtPosition(toPlace, mapYPos, mapXPos);

                return true;
            }
            else if (LMI.Player.CurrSuperLayer.GetGroundLayerTile(mapYPos, mapXPos) != null) {
                LMI.Player.CurrSuperLayer.SetStructureAtPosition(toPlace, mapYPos, mapXPos);

                return true;
            }
            return false;
        }

        public static void TryPlaceStructure(ISuperLayer superLayer, int yPos, int xPos, Structure toPlace) {
            if (superLayer.GetStructureLayerTile(yPos, xPos) != null) {
                superLayer.SetStructureAtPosition(toPlace, yPos, xPos);
            }
        }

        public static bool PlayerCanBuildAt(int yPos, int xPos) {
            return LMI.Player.CurrSuperLayer.GetStructureLayerTile(yPos, xPos) == null;
        }

        public static bool PlayerCanDestroyAt(int yPos, int xPos) {
            return LMI.Player.CurrSuperLayer.GetStructureLayerTile(yPos, xPos) != null ||
                   LMI.Player.CurrSuperLayer.GetGroundLayerTile(yPos, xPos) != null;
        }
    }
}
