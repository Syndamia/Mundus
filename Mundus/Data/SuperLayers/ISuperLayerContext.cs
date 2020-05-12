namespace Mundus.Data.SuperLayers 
{
    /// <summary>
    /// Add, remove and change values in the different superlayers (database tables)
    /// </summary>
    public interface ISuperLayerContext 
    {
        /// <summary>
        /// Returns the stock_id of the mob at the specified positoin
        /// </summary>
        string GetMobLayerStock(int yPos, int xPos);

        /// <summary>
        /// Returns the stock_id of the structure at the specified positoin
        /// </summary>
        string GetStructureLayerStock(int yPos, int xPos);

        /// <summary>
        /// Returns the stock_id of the ground (tile) at the specified positoin
        /// </summary>
        string GetGroundLayerStock(int yPos, int xPos);

        /// <summary>
        /// Adds a mob's stock_id, it's health and the specified position in the mob layer table
        /// </summary>
        void AddMobAtPosition(string stock_id, int health, int yPos, int xPos);

        /// <summary>
        /// Sets the mob's stock_id and health for the specified position of the mob layer table
        /// </summary>
        void SetMobAtPosition(string stock_id, int health, int yPos, int xPos);

        /// <summary>
        /// Sets invalid values for stock_id (null) and health (-1) for the specified position of the mob layer table
        /// </summary>
        void RemoveMobFromPosition(int yPos, int xPos);

        /// <summary>
        /// Removes health from the mob on the specified position in the mob layer table
        /// </summary>
        /// <returns><c>true</c>If the mob can still be damaged (alive)<c>false</c> otherwise.</returns>
        bool TakeDamageMobAtPosition(int yPos, int xPos, int damage);

        /// <summary>
        /// Adds a structure's stock_id, it's health and the specified position in the structure layer table
        /// </summary>
        void AddStructureAtPosition(string stock_id, int health, int yPos, int xPos);

        /// <summary>
        /// Sets the structure's stock_id and health for the specified position of the structure layer table
        /// </summary>
        void SetStructureAtPosition(string stock_id, int health, int yPos, int xPos);

        /// <summary>
        /// Sets invalid values for stock_id (null) and health (-1) for the specified position of the structure layer table
        /// </summary>
        void RemoveStructureFromPosition(int yPos, int xPos);

        /// <summary>
        /// Removes health from the structure on the specified position in the structure layer table
        /// </summary>
        /// <returns><c>true</c>If the structure can still be damaged <c>false</c> otherwise.</returns>
        bool TakeDamageStructureAtPosition(int yPos, int xPos, int damage);

        /// <summary>
        /// Adds a ground (tile)'s stock_id and the specified position in the ground (tile) layer table
        /// </summary>
        void AddGroundAtPosition(string stock_id, int yPos, int xPos);

        /// <summary>
        /// Sets the ground (tile)'s stock_id and health for the specified position of the ground (tile) layer table
        /// </summary>
        void SetGroundAtPosition(string stock_id, int yPos, int xPos);

        /// <summary>
        /// Sets invalid values for stock_id (null) for the specified position of the ground (tile) layer table
        /// </summary>
        void RemoveGroundFromPosition(int yPos, int xPos);
    }
}
