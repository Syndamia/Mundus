namespace Mundus.Data.GameEventLogs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Data type for the DBSet of GameEventLogs table
    /// </summary>
    [Table("GameEventLogs", Schema = "Mundus")]
    public class GameEventLog 
    {
        public GameEventLog(string message)
        {
            this.Message = message;
        }

        /// <summary>
        /// Gets the unique identifier (primary key ; only used in the tables by MySQL)
        /// </summary>
        [Key]
        public int ID { get; private set; }

        /// <summary>
        /// Gets the message of the log
        /// </summary>
        public string Message { get; private set; }
    }
}