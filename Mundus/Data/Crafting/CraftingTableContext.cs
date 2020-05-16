namespace Mundus.Data.Crafting 
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Mundus.Data.Tiles.Mobs;
    using Mundus.Data.Tiles.Presets;
    using Mundus.Service.Tiles.Crafting;

    /// <summary>
    /// Context for getting the crafting recipes
    /// </summary>
    public class CraftingTableContext : DbContext 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Mundus.Data.Crafting.CraftingTableContext"/> class and adds all the recipes to the table
        /// </summary>
        public CraftingTableContext() : base()
        {
            this.AddRecipes();
        }

        /// <summary>
        /// Gets DBSet of the CraftingRecipes table
        /// </summary>
        /// <value>The crafting recipes.</value>
        public DbSet<CraftingRecipe> CraftingRecipes { get; private set; }

        /// <summary>
        /// Returns an array with all the recipes that can be crafted with the items the player has
        /// </summary>
        public CraftingRecipe[] GetAvalableRecipes()
        {
            var recipes = this.CraftingRecipes.ToArray();
            return recipes.Where(cr => cr.HasEnoughItems(MI.Player.Inventory.Items)).ToArray();
        }

        /// <summary>
        /// Used to set the connection string
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseMySQL(DataBaseContexts.ConnectionStringMySQL);
        }

        /// <summary>
        /// Truncates CraftingRecipes table and adds the crafting recipes (and saves changes)
        /// </summary>
        private void AddRecipes()
        {
            this.TruncateTable();

            this.CraftingRecipes.Add(new CraftingRecipe(ToolPresets.GetAWoodenShovel().stock_id, 5, MaterialPresets.GetALandStick().stock_id));
            this.CraftingRecipes.Add(new CraftingRecipe(ToolPresets.GetAWoodenPickaxe().stock_id, 4, MaterialPresets.GetALandStick().stock_id));
            this.CraftingRecipes.Add(new CraftingRecipe(ToolPresets.GetAWoodenAxe().stock_id, 3, MaterialPresets.GetALandStick().stock_id));
            this.CraftingRecipes.Add(new CraftingRecipe(ToolPresets.GetAWoodenLongsword().stock_id, 4, MaterialPresets.GetALandStick().stock_id));

            this.CraftingRecipes.Add(new CraftingRecipe(ToolPresets.GetARockShovel().stock_id, 4, MaterialPresets.GetALandRock().stock_id, 2, MaterialPresets.GetALandStick().stock_id));
            this.CraftingRecipes.Add(new CraftingRecipe(ToolPresets.GetARockPickaxe().stock_id, 4, MaterialPresets.GetALandRock().stock_id, 2, MaterialPresets.GetALandStick().stock_id));
            this.CraftingRecipes.Add(new CraftingRecipe(ToolPresets.GetARockAxe().stock_id, 3, MaterialPresets.GetALandRock().stock_id, 2, MaterialPresets.GetALandStick().stock_id));
            this.CraftingRecipes.Add(new CraftingRecipe(ToolPresets.GetARockLongsword().stock_id, 5, MaterialPresets.GetALandRock().stock_id, 2, MaterialPresets.GetALandStick().stock_id));

            this.CraftingRecipes.Add(new CraftingRecipe(StructurePresets.GetAWoodenLadder().inventory_stock_id, 6, MaterialPresets.GetALandStick().stock_id));

            this.SaveChanges();
        }

        /// <summary>
        /// Truncates the table CraftingRecipes (doesn't save the changes)
        /// </summary>
        private void TruncateTable()
        {
            this.Database.ExecuteSqlRaw("TRUNCATE TABLE CraftingRecipes");
        }
    }
}
