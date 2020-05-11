using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mundus.Data {
    [Table("GameEventLogs", Schema = "Mundus")]
    public class GameEventLog {
        [Key]
        public int ID { get; private set; }
        public string Message { get; private set; }

        public GameEventLog(string message) {
            this.Message = message;
        }
    }
}
