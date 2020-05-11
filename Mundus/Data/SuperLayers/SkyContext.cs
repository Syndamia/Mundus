using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mundus.Data.SuperLayers.DBTables;
using Mundus.Service.SuperLayers;
using Mundus.Service.SuperLayers.Generators;

namespace Mundus.Data.SuperLayers {
    public class SkyContext : DbContext, ISuperLayerContext {
        public DbSet<SMPlacedTile> SMobLayer { get; private set; }
        public DbSet<SSPlacedTile> SStructureLayer { get; private set; }
        public DbSet<SGPlacedTile> SGroundLayer { get; private set; }

        public SkyContext() :base() {
            Database.ExecuteSqlRaw("TRUNCATE TABLE SMobLayer");
            Database.ExecuteSqlRaw("TRUNCATE TABLE SStructureLayer");
            Database.ExecuteSqlRaw("TRUNCATE TABLE SGroundLayer");
            SaveChanges();
        }

        public string GetMobLayerStock(int yPos, int xPos) {
            return SMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id;
        }
        public string GetStructureLayerStock(int yPos, int xPos) {
            return SStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id;
        }
        public string GetGroundLayerStock(int yPos, int xPos) {
            return SGroundLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id;
        }

        public void AddMobAtPosition(string stock_id, int yPos, int xPos) {
            SMobLayer.Add(new SMPlacedTile(stock_id, yPos, xPos));
            
        }

        public void SetMobAtPosition(string stock_id, int yPos, int xPos) {
            SMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = stock_id;
            
        }
        public void RemoveMobFromPosition(int yPos, int xPos) {
            SMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = null;
            
        }

        public void AddStructureAtPosition(string stock_id, int yPos, int xPos) {
            SStructureLayer.Add(new SSPlacedTile(stock_id, yPos, xPos));
            
        }

        public void SetStructureAtPosition(string stock_id, int yPos, int xPos) {
            SStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = stock_id;
            
        }
        public void RemoveStructureFromPosition(int yPos, int xPos) {
            SStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = null;
            
        }

        public void AddGroundAtPosition(string stock_id, int yPos, int xPos) {
            SGroundLayer.Add(new SGPlacedTile(stock_id, yPos, xPos));
            
        }

        public void SetGroundAtPosition(string stock_id, int yPos, int xPos) {
            SGroundLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = stock_id;
            
        }
        public void RemoveGroundFromPosition(int yPos, int xPos) {
            SGroundLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = null;
            
        }

        public string SuperLayerName() {
            return "Sky";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySQL(DataBaseContexts.ConnectionStringMySQL);
        }
    }
}
