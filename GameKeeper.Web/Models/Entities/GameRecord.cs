using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameKeeper.Web.Models.Entities
{
    public partial class GameRecord
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public virtual ICollection<PlayerRecord> PlayerRecords { get; set; } = new List<PlayerRecord>();
    }
}
