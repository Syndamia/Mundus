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

        public void AddMobAtPosition(string stock_id, int health, int yPos, int xPos) {
            SMobLayer.Add(new SMPlacedTile(stock_id, health, yPos, xPos));
            
        }

        public void SetMobAtPosition(string stock_id, int health, int yPos, int xPos) {
            SMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = stock_id;
            SMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).Health = health;
        }
        public void RemoveMobFromPosition(int yPos, int xPos) {
            SMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = null;
            SMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).Health = -1;

        }
        public bool TakeDamageMobAtPosition(int yPos, int xPos, int damage) {
            var mob = SMobLayer.First(x => x.YPos == yPos && x.XPos == xPos);
            mob.Health -= damage;
            return mob.Health > 0;
        }

        public void AddStructureAtPosition(string stock_id, int health, int yPos, int xPos) {
            SStructureLayer.Add(new SSPlacedTile(stock_id, health, yPos, xPos));
            
        }

        public void SetStructureAtPosition(string stock_id, int health, int yPos, int xPos) {
            SStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = stock_id;
            SStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).Health = health;
            
        }
        public void RemoveStructureFromPosition(int yPos, int xPos) {
            SStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = null;
            SStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).Health = -1;

        }
        public bool TakeDamageStructureAtPosition(int yPos, int xPos, int damage) {
            var structure = SStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos);
            structure.Health -= damage;
            return structure.Health > 0;
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
