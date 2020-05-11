using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mundus.Service;

namespace Mundus.Data {
    public class GameEventLogContext : DbContext {
        public DbSet<GameEventLog> GameEventLogs { get; private set; }

        public GameEventLogContext() :base() 
        {
            ResetTable();
        }

        private void ResetTable() {
            Database.ExecuteSqlRaw("TRUNCATE TABLE GameEventLogs;");
            SaveChanges();
        }

        public void AddMessage(string message) {
            GameEventLogs.Add(new GameEventLog(message));
            this.SaveChanges();
        }

        public string GetMessage(int id) {
            return GameEventLogs.Single(x => x.ID == id).Message;
        }

        public int GetCount() {
            return GameEventLogs.Count();
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
