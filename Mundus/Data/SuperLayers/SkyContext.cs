namespace Mundus.Data.SuperLayers 
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Mundus.Data.SuperLayers.DBTables;

    /// <summary>
    /// Add, remove and change values in the sky superlayer
    /// </summary>
    public class SkyContext : DbContext, ISuperLayerContext 
    {
        /// <summary>
        /// Initializes a new instance of the SkyContext class and truncates all related tables
        /// </summary>
        public SkyContext() : base()
        {
            this.Database.ExecuteSqlRaw("TRUNCATE TABLE SMobLayer");
            this.Database.ExecuteSqlRaw("TRUNCATE TABLE SStructureLayer");
            this.Database.ExecuteSqlRaw("TRUNCATE TABLE SGroundLayer");

            this.SaveChanges();
        }

        /// <summary>
        /// Gets DBSet of the sky mob layer table
        /// </summary>
        public DbSet<SMPlacedTile> SMobLayer { get; private set; }

        /// <summary>
        /// Gets DBSet of the sky structure layer table
        /// </summary>
        public DbSet<SSPlacedTile> SStructureLayer { get; private set; }

        /// <summary>
        /// Gets DBSet of the sky structure layer table
        /// </summary>
        public DbSet<SGPlacedTile> SGroundLayer { get; private set; }

        /// <summary>
        /// Returns the stock_id of the mob at the specified positoin
        /// </summary>
        public string GetMobLayerStock(int yPos, int xPos) 
        {
            return this.SMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id;
        }

        /// <summary>
        /// Returns the stock_id of the structure at the specified positoin
        /// </summary>
        public string GetStructureLayerStock(int yPos, int xPos) 
        {
            return this.SStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id;
        }

        /// <summary>
        /// Returns the stock_id of the ground (tile) at the specified positoin
        /// </summary>
        public string GetGroundLayerStock(int yPos, int xPos) 
        {
            return this.SGroundLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id;
        }

        /// <summary>
        /// Adds a mob's stock_id, it's health and the specified position in the mob layer table
        /// </summary>
        public void AddMobAtPosition(string stock_id, int health, int yPos, int xPos) 
        {
            this.SMobLayer.Add(new SMPlacedTile(stock_id, health, yPos, xPos));
        }

        /// <summary>
        /// Sets the mob's stock_id and health for the specified position of the mob layer table
        /// </summary>
        public void SetMobAtPosition(string stock_id, int health, int yPos, int xPos) 
        {
            this.SMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = stock_id;
            this.SMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).Health = health;
        }

        /// <summary>
        /// Sets invalid values for stock_id (null) and health (-1) for the specified position of the mob layer table
        /// </summary>
        public void RemoveMobFromPosition(int yPos, int xPos) 
        {
            this.SMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = null;
            this.SMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).Health = -1;
        }

        /// <summary>
        /// Removes health from the mob on the specified position in the mob layer table
        /// </summary>
        /// <returns><c>true</c>If the mob can still be damaged (alive)<c>false</c> otherwise.</returns>
        public bool TakeDamageMobAtPosition(int yPos, int xPos, int damage) 
        {
            this.SMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).Health -= damage;
            this.SaveChanges();
            return this.SMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).Health > 0;
        }

        /// <summary>
        /// Adds a structure's stock_id, it's health and the specified position in the structure layer table
        /// </summary>
        public void AddStructureAtPosition(string stock_id, int health, int yPos, int xPos) 
        {
            this.SStructureLayer.Add(new SSPlacedTile(stock_id, health, yPos, xPos));
        }

        /// <summary>
        /// Sets the structure's stock_id and health for the specified position of the structure layer table
        /// </summary>
        public void SetStructureAtPosition(string stock_id, int health, int yPos, int xPos) 
        {
            this.SStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = stock_id;
            this.SStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).Health = health;
        }

        /// <summary>
        /// Sets invalid values for stock_id (null) and health (-1) for the specified position of the structure layer table
        /// </summary>
        public void RemoveStructureFromPosition(int yPos, int xPos) 
        {
            this.SStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = null;
            this.SStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).Health = -1;
        }

        /// <summary>
        /// Removes health from the structure on the specified position in the structure layer table
        /// </summary>
        /// <returns><c>true</c>If the structure can still be damaged <c>false</c> otherwise.</returns>
        public bool TakeDamageStructureAtPosition(int yPos, int xPos, int damage) 
        {
            var structure = this.SStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos);
            structure.Health -= damage;
            return structure.Health > 0;
        }

        /// <summary>
        /// Adds a ground (tile)'s stock_id and the specified position in the ground (tile) layer table
        /// </summary>
        public void AddGroundAtPosition(string stock_id, int yPos, int xPos) 
        {
            this.SGroundLayer.Add(new SGPlacedTile(stock_id, yPos, xPos));
        }

        /// <summary>
        /// Sets the ground (tile)'s stock_id and health for the specified position of the ground (tile) layer table
        /// </summary>
        public void SetGroundAtPosition(string stock_id, int yPos, int xPos)
        {
            this.SGroundLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = stock_id;
        }

        /// <summary>
        /// Sets invalid values for stock_id (null) for the specified position of the ground (tile) layer table
        /// </summary>
        public void RemoveGroundFromPosition(int yPos, int xPos) 
        {
            this.SGroundLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = null;
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
