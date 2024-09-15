using Microsoft.Identity.Client;

namespace GameKeeper.Web.Models.Entities
{
    public partial class PlayerRecord
    {
        public int Id { get; set; }

        public int? PlayerId { get; set; }

        public bool Won { get; set; }

        public int? GameRecordId { get; set; }

        public virtual GameRecord? GameRecord { get; set; }

        //public virtual Player Player { get; set; } = null!;
    }
}
