namespace Mundus.Data.SuperLayers 
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Mundus.Data.SuperLayers.DBTables;

    /// <summary>
    /// Add, remove and change values in the underground superlayer
    /// </summary>
    public class UndergroundContext : DbContext, ISuperLayerContext 
    {
        /// <summary>
        /// Initializes a new instance of the UndergroundContext class and truncates all related tables
        /// </summary>
        public UndergroundContext()
        {
            this.Database.ExecuteSqlRaw("TRUNCATE TABLE UMobLayer");
            this.Database.ExecuteSqlRaw("TRUNCATE TABLE UStructureLayer");
            this.Database.ExecuteSqlRaw("TRUNCATE TABLE UGroundLayer");

            this.SaveChanges();
        }

        /// <summary>
        /// Gets DBSet of the underground mob layer table
        /// </summary>
        public DbSet<UMPlacedTile> UMobLayer { get; private set; }

        /// <summary>
        /// Gets DBSet of the underground structure layer table
        /// </summary>
        public DbSet<USPlacedTile> UStructureLayer { get; private set; }

        /// <summary>
        /// Gets DBSet of the sky underground layer table
        /// </summary>
        public DbSet<UGPlacedTile> UGroundLayer { get; private set; }

        /// <summary>
        /// Returns the stock_id of the mob at the specified positoin
        /// </summary>
        public string GetMobLayerStock(int yPos, int xPos) 
        {
            return this.UMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id;
        }

        /// <summary>
        /// Returns the stock_id of the structure at the specified positoin
        /// </summary>
        public string GetStructureLayerStock(int yPos, int xPos) 
        {
            return this.UStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id;
        }

        /// <summary>
        /// Returns the stock_id of the ground (tile) at the specified positoin
        /// </summary>
        public string GetGroundLayerStock(int yPos, int xPos) 
        {
            return this.UGroundLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id;
        }

        /// <summary>
        /// Adds a mob's stock_id, it's health and the specified position in the mob layer table
        /// </summary>
        public void AddMobAtPosition(string stock_id, int health, int yPos, int xPos) 
        {
            this.UMobLayer.Add(new UMPlacedTile(stock_id, health, yPos, xPos));
        }

        /// <summary>
        /// Sets the mob's stock_id and health for the specified position of the mob layer table
        /// </summary>
        public void SetMobAtPosition(string stock_id, int health, int yPos, int xPos) 
        {
            this.UMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = stock_id;
            this.UMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).Health = health;
        }

        /// <summary>
        /// Sets invalid values for stock_id (null) and health (-1) for the specified position of the mob layer table
        /// </summary>
        public void RemoveMobFromPosition(int yPos, int xPos) 
        {
            this.UMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = null;
            this.UMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).Health = -1;
        }

        /// <summary>
        /// Removes health from the mob on the specified position in the mob layer table
        /// </summary>
        /// <returns><c>true</c>If the mob can still be damaged (alive)<c>false</c> otherwise.</returns>
        public bool TakeDamageMobAtPosition(int yPos, int xPos, int damage) 
        {
            this.UMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).Health -= damage;
            return this.UMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).Health > 0;
        }

        /// <summary>
        /// Adds a structure's stock_id, it's health and the specified position in the structure layer table
        /// </summary>
        public void AddStructureAtPosition(string stock_id, int health, int yPos, int xPos) 
        {
            this.UStructureLayer.Add(new USPlacedTile(stock_id, health, yPos, xPos));
        }

        /// <summary>
        /// Sets the structure's stock_id and health for the specified position of the structure layer table
        /// </summary>
        public void SetStructureAtPosition(string stock_id, int health, int yPos, int xPos) 
        {
            this.UStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = stock_id;
            this.UStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).Health = health;
        }

        /// <summary>
        /// Sets invalid values for stock_id (null) and health (-1) for the specified position of the structure layer table
        /// </summary>
        public void RemoveStructureFromPosition(int yPos, int xPos) 
        {
            this.UStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = null;
            this.UStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).Health = -1;
        }

        /// <summary>
        /// Removes health from the structure on the specified position in the structure layer table
        /// </summary>
        /// <returns><c>true</c>If the structure can still be damaged <c>false</c> otherwise.</returns>
        public bool TakeDamageStructureAtPosition(int yPos, int xPos, int damage) 
        {
            var structure = this.UStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos);
            structure.Health -= damage;
            return structure.Health > 0;
        }

        /// <summary>
        /// Adds a ground (tile)'s stock_id and the specified position in the ground (tile) layer table
        /// </summary>
        public void AddGroundAtPosition(string stock_id, int yPos, int xPos) 
        {
            this.UGroundLayer.Add(new UGPlacedTile(stock_id, yPos, xPos));
        }

        /// <summary>
        /// Sets the ground (tile)'s stock_id and health for the specified position of the ground (tile) layer table
        /// </summary>
        public void SetGroundAtPosition(string stock_id, int yPos, int xPos) 
        {
            this.UGroundLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = stock_id;
        }

        /// <summary>
        /// Sets invalid values for stock_id (null) for the specified position of the ground (tile) layer table
        /// </summary>
        public void RemoveGroundFromPosition(int yPos, int xPos) 
        {
            this.UGroundLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = null;
        }

        public override string ToString()
        {
            return "Underground";
        }

        /// <summary>
        /// Used to set the connection string
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(DataBaseContexts.ConnectionStringMySQL);
        }
    }
}
