using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Service.Tiles.Crafting;
using Mundus.Service.Tiles.Items.Presets;

namespace Mundus.Data.Crafting {
    public class CraftingTableContext : DbContext {
        public DbSet<CraftingRecipe> CraftingRecipes { get; set; }

        public CraftingTableContext() : base()
        { }


        public void AddRecipes() {
            ResetTable();

            CraftingRecipes.Add(new CraftingRecipe(ToolPresets.GetAWoodenShovel().stock_id, 5, MaterialPresets.GetALandStick().stock_id));
            CraftingRecipes.Add(new CraftingRecipe(ToolPresets.GetAWoodenPickaxe().stock_id, 4, MaterialPresets.GetALandStick().stock_id));
            CraftingRecipes.Add(new CraftingRecipe(ToolPresets.GetAWoodenAxe().stock_id, 3, MaterialPresets.GetALandStick().stock_id));
            CraftingRecipes.Add(new CraftingRecipe(ToolPresets.GetAWoodenLongsword().stock_id, 4, MaterialPresets.GetALandStick().stock_id));

            CraftingRecipes.Add(new CraftingRecipe(ToolPresets.GetARockShovel().stock_id, 4, MaterialPresets.GetALandRock().stock_id, 2, MaterialPresets.GetALandStick().stock_id));
            CraftingRecipes.Add(new CraftingRecipe(ToolPresets.GetARockPickaxe().stock_id, 4, MaterialPresets.GetALandRock().stock_id, 2, MaterialPresets.GetALandStick().stock_id));
            CraftingRecipes.Add(new CraftingRecipe(ToolPresets.GetARockAxe().stock_id, 3, MaterialPresets.GetALandRock().stock_id, 2, MaterialPresets.GetALandStick().stock_id));
            CraftingRecipes.Add(new CraftingRecipe(ToolPresets.GetARockLongsword().stock_id, 5, MaterialPresets.GetALandRock().stock_id, 2, MaterialPresets.GetALandStick().stock_id));

            CraftingRecipes.Add(new CraftingRecipe(StructurePresets.GetAWoodenLadder().inventory_stock_id, 6, MaterialPresets.GetALandStick().stock_id));

            this.SaveChanges();
        }

        private void ResetTable() {
            CraftingRecipes.RemoveRange(CraftingRecipes);
        }

        public CraftingRecipe[] GetAvalableRecipes() {
            var recipes = CraftingRecipes.ToArray();
            return recipes.Where(cr => cr.HasEnoughItems(MI.Player.Inventory.Items)).ToArray();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySQL(
                "server=localhost;" +
                "port=3306;" +
                "user id=root; " +
                "password=password; " +
                "database=Mundus; " +
                "SslMode=none");
        }
    }
}
