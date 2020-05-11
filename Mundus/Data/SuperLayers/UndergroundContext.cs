using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mundus.Data.SuperLayers.DBTables;
using Mundus.Service.SuperLayers;

namespace Mundus.Data.SuperLayers {
    public class UndergroundContext : DbContext, ISuperLayerContext {
    public DbSet<UMPlacedTile> UMobLayer { get; private set; }
    public DbSet<USPlacedTile> UStructureLayer { get; private set; }
    public DbSet<UGPlacedTile> UGroundLayer { get; private set; }

    public UndergroundContext() : base() {
        Database.ExecuteSqlRaw("TRUNCATE TABLE UMobLayer");
        Database.ExecuteSqlRaw("TRUNCATE TABLE UStructureLayer");
        Database.ExecuteSqlRaw("TRUNCATE TABLE UGroundLayer");
        SaveChanges();
    }

    public string GetMobLayerStock(int yPos, int xPos) {
        return UMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id;
    }
    public string GetStructureLayerStock(int yPos, int xPos) {
        return UStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id;
    }
    public string GetGroundLayerStock(int yPos, int xPos) {
        return UGroundLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id;
    }

    public void AddMobAtPosition(string stock_id, int yPos, int xPos) {
        UMobLayer.Add(new UMPlacedTile(stock_id, yPos, xPos));
        
    }

    public void SetMobAtPosition(string stock_id, int yPos, int xPos) {
        UMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = stock_id;
        
    }
    public void RemoveMobFromPosition(int yPos, int xPos) {
        UMobLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = null;
        
    }

    public void AddStructureAtPosition(string stock_id, int yPos, int xPos) {
        UStructureLayer.Add(new USPlacedTile(stock_id, yPos, xPos));
        
    }

    public void SetStructureAtPosition(string stock_id, int yPos, int xPos) {
        UStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = stock_id;
        
    }
    public void RemoveStructureFromPosition(int yPos, int xPos) {
        UStructureLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = null;
        
    }

    public void AddGroundAtPosition(string stock_id, int yPos, int xPos) {
        UGroundLayer.Add(new UGPlacedTile(stock_id, yPos, xPos));
        
    }

    public void SetGroundAtPosition(string stock_id, int yPos, int xPos) {
        UGroundLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = stock_id;
        
    }
    public void RemoveGroundFromPosition(int yPos, int xPos) {
        UGroundLayer.First(x => x.YPos == yPos && x.XPos == xPos).stock_id = null;
        
    }

    public string SuperLayerName() {
        return "Underground";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseMySQL(DataBaseContexts.ConnectionStringMySQL);
    }
}
}
