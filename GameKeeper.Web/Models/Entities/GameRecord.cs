using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameKeeper.Web.Models.Entities
{
    public class GameRecord
    {
        public int Id { get; set; }

        public required Game Game { get; set; }

        public required List<PlayerRecord> PlayerRecords { get; set; }
    }
}
