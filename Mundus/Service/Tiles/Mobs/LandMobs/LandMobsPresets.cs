namespace Mundus.Service.Tiles.Mobs.LandMobs 
{
    using Mundus.Data;
    using Mundus.Service.Tiles.Items.Presets;
    using Mundus.Service.Tiles.Mobs;

    public static class LandMobsPresets 
    {
        private static MobTile cow = new MobTile("L_cow", 10, 1, DataBaseContexts.LContext, 1, MaterialPresets.GetALandBeefSteak());

        private static MobTile sheep = new MobTile("L_sheep", 8, 1, DataBaseContexts.LContext, 1, MaterialPresets.GetALandMuttonSteak());

        /// <summary>
        /// Returns a (static) cow MobTile. 
        /// Do not modify!
        /// </summary>
        public static MobTile GetCow() 
        {
            return cow;
        }

        /// <summary>
        /// Returns a (static) sheep MobTile. 
        /// Do not modify!
        /// </summary>
        public static MobTile GetSheep() 
        {
            return sheep;
        }

        public static MobTile GetFromStock(string stock_id) 
        {
            switch (stock_id) 
            {
                case "L_cow": return GetCow();
                case "L_sheep": return GetSheep();
                case "player": return MI.Player;
                default: return null;
            }
        }
    }
}
