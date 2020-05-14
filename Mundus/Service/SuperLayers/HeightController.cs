namespace Mundus.Service.SuperLayers 
{
    using System;
    using System.Linq;
    using Mundus.Data;
    using Mundus.Data.SuperLayers;
    using Mundus.Service.Tiles.Mobs;

    /// <summary>
    /// Works out which superlayer is above or below the given one
    /// </summary>
    public static class HeightController 
    {
        /// <summary>
        /// Contains the order of superlayers, from the one that is the highest (above all others)
        /// to the one that is the lowest (underneath all other)
        /// </summary>
        private static ISuperLayerContext[] superLayers = { 
                                                            DataBaseContexts.SContext, 
                                                            DataBaseContexts.LContext,
                                                            DataBaseContexts.UContext 
                                                          };
                                                           
        /// <summary>
        /// Returns the superlayer that is underneath the given one
        /// If there isn't any, returns null
        /// </summary>
        public static ISuperLayerContext GetSuperLayerUnderneath(ISuperLayerContext currentLayer) 
        {
            if (Array.IndexOf(superLayers, currentLayer) == superLayers.Length - 1) 
            {
                return null;
            }

            return superLayers[Array.IndexOf(superLayers, currentLayer) + 1];
        }

        /// <summary>
        /// Returns the superlayer that is above the given one
        /// If there isn't any, returns null
        /// </summary>
        public static ISuperLayerContext GetSuperLayerAbove(ISuperLayerContext currentLayer) 
        {
            if (Array.IndexOf(superLayers, currentLayer) == 0) 
            {
                return null;
            }

            return superLayers[Array.IndexOf(superLayers, currentLayer) - 1];
        }

        /// <summary>
        /// Returns the superlayer that is underneath the one that the given mob is in
        /// If there isn't any, returns null
        /// </summary>
        public static ISuperLayerContext GetSuperLayerUnderneathMob(MobTile currentMob) 
        {
            return GetSuperLayerUnderneath(currentMob.CurrSuperLayer);
        }

        /// <summary>
        /// Returns the superlayer that is above the one that the given mob is in
        /// If there isn't any, returns null
        /// </summary>
        public static ISuperLayerContext GetSuperLayerAboveMob(MobTile currentMob) 
        {
            return GetSuperLayerAbove(currentMob.CurrSuperLayer);
        }
    }
}
