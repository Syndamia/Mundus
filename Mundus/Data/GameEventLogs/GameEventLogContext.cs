namespace Mundus.Data.GameEventLogs 
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Add and get log messages from the GameEventLogs table
    /// </summary>
    public class GameEventLogContext : DbContext 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Mundus.Data.GameEventLogs.GameEventLogContext"/> class and truncates the table
        /// </summary>
        public GameEventLogContext() : base()
        {
            this.ResetTable();
        }

        /// <summary>
        /// Gets DbSet of the game event logs table
        /// </summary>
        public DbSet<GameEventLog> GameEventLogs { get; private set; }

        /// <summary>
        /// Adds a message to the GameEventLogs table
        /// </summary>
        public void AddMessage(string message) 
        {
            this.GameEventLogs.Add(new GameEventLog(message));
            this.SaveChanges();
        }

        /// <summary>
        /// Gets a message from the GameEventLogs table that has the specified id
        /// </summary>
        public string GetMessage(int id) 
        {
            return this.GameEventLogs.Single(x => x.ID == id).Message;
        }

        /// <summary>
        /// Gets count of game event logs
        /// </summary>
        public int GetCount() 
        {
            return this.GameEventLogs.Count();
        }

        /// <summary>
        /// Used to set the connection string
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseMySQL(DataBaseContexts.ConnectionStringMySQL);
        }

        /// <summary>
        /// Truncates the GameEventLogs table (saves the change)
        /// </summary>
        private void ResetTable() 
        {
            this.Database.ExecuteSqlRaw("TRUNCATE TABLE GameEventLogs;");
            this.SaveChanges();
        }
    }
}