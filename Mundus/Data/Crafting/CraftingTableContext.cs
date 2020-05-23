namespace Mundus.Data.Crafting 
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Context for getting the crafting recipes
    /// </summary>
    public class CraftingTableContext : DbContext 
    {
        /// <summary>
        /// Gets DBSet of the CraftingRecipes table
        /// </summary>
        /// <value>The crafting recipes.</value>
        public DbSet<CraftingRecipe> CraftingRecipes { get; private set; }

        /// <summary>
        /// Truncates the table CraftingRecipes (doesn't save the changes)
        /// </summary>
        public void TruncateTable()
        {
            this.Database.ExecuteSqlRaw("TRUNCATE TABLE CraftingRecipes");
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
