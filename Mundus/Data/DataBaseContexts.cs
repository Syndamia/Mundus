namespace Mundus.Data 
{
    using Mundus.Data.Crafting;
    using Mundus.Data.GameEventLogs;
    using Mundus.Data.SuperLayers;

    /// <summary>
    /// Used to store all the contexts that correspond to the database tables
    /// </summary>
    public static class DataBaseContexts 
    {
        /// <summary>
        /// The connection string for MySQL
        /// </summary>
        public const string ConnectionStringMySQL = "server=localhost;" +
                                                    "port=3306;" +
                                                    "user id=root; " +
                                                    "password=password; " +
                                                    "database=Mundus; " +
                                                    "SslMode=none";

        /// <summary>
        /// Gets the crafting table context instance
        /// </summary>
        public static CraftingTableContext CTContext { get; private set; }

        /// <summary>
        /// Gets the game event log table context instance
        /// </summary>
        public static GameEventLogContext GELContext { get; private set; }

        /// <summary>
        /// Gets the sky superlayer context instance
        /// </summary>
        public static SkyContext SContext { get; private set; }

        /// <summary>
        /// Gets the land superlayer context instance
        /// </summary>
        public static LandContext LContext { get; private set; }

        /// <summary>
        /// Gets the underground superlayer context instance
        /// </summary>
        public static UndergroundContext UContext { get; private set; }

        /// <summary>
        /// Gets the an array of all superlayer context instances
        /// </summary>
        public static ISuperLayerContext[] SuperLayerContexts { get; private set; }

        /// <summary>
        /// Creates all instances of the contexts
        /// </summary>
        public static void CreateInstances() 
        {
            CTContext = new CraftingTableContext();
            GELContext = new GameEventLogContext();

            SContext = new SkyContext();
            LContext = new LandContext();
            UContext = new UndergroundContext();
            SuperLayerContexts = new ISuperLayerContext[] { SContext, LContext, UContext };
        }
    }
}
