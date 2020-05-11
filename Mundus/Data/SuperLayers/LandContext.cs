using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mundus.Data.SuperLayers.DBTables;
using Mundus.Service.SuperLayers;
using Mundus.Service.Tiles.Mobs.LandMobs;

namespace Mundus.Data.SuperLayers {
    public class LandContext : DbContext, ISuperLayerContext {
        public DbSet<LMPlacedTile> LMobLayer { get; private set; }
        public DbSet<LSPlacedTile> LStructureLayer { get; private set; }
        public DbSet<LGPlacedTile> LGroundLayer { get; private set; }

        public LandContext() : base() {
            Database.ExecuteSqlRaw("TRUNCATE TABLE LMobLayer");
            Database.ExecuteSqlRaw("TRUNCATE TABLE LStructureLayer");
            Database.ExecuteSqlRaw("TRUNCATE TABLE LGroundLayer");
            SaveChanges();
        }

        public string GetMobLayerStock(int yPos, int xPos) {
            return LMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id;
        }
        public string GetStructureLayerStock(int yPos, int xPos) {
            return LStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id;
        }
        public string GetGroundLayerStock(int yPos, int xPos) {
            return LGroundLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id;
        }

        public void AddMobAtPosition(string stock_id, int health, int yPos, int xPos) {
            LMobLayer.Add(new LMPlacedTile(stock_id, health, yPos, xPos));
            
        }

        public void SetMobAtPosition(string stock_id, int health, int yPos, int xPos) {
            LMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = stock_id;
            LMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).Health = health;
        }
        public void RemoveMobFromPosition(int yPos, int xPos) {
            LMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = null;
            LMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).Health = -1;

        }
        public bool TakeDamageMobAtPosition(int yPos, int xPos, int damage) {
            var mob = LMobLayer.First(x => x.YPos == yPos && x.XPos == xPos);
            mob.Health -= damage;
            return mob.Health > 0;
        }

            public void AddStructureAtPosition(string stock_id, int health, int yPos, int xPos) {
            LStructureLayer.Add(new LSPlacedTile(stock_id, health, yPos, xPos));
            
        }

        public void SetStructureAtPosition(string stock_id, int health, int yPos, int xPos) {
            LStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = stock_id;
            LStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).Health = health;
            
        }
        public void RemoveStructureFromPosition(int yPos, int xPos) {
            LStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = null;
            LStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).Health = -1;

        }
        public bool TakeDamageStructureAtPosition(int yPos, int xPos, int damage) {
            var structure = LStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos);
            structure.Health -= damage;
            return structure.Health > 0;
        }

        public void AddGroundAtPosition(string stock_id, int yPos, int xPos) {
            LGroundLayer.Add(new LGPlacedTile(stock_id, yPos, xPos));
            
        }

        public void SetGroundAtPosition(string stock_id, int yPos, int xPos) {
            LGroundLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = stock_id;
            
        }
        public void RemoveGroundFromPosition(int yPos, int xPos) {
            LGroundLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = null;
            
        }

        public string SuperLayerName() {
            return "Land";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySQL(DataBaseContexts.ConnectionStringMySQL);
        }
    }
}
