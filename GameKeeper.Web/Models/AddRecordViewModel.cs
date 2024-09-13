using GameKeeper.Web.Models.Entities;

namespace GameKeeper.Web.Models
{
    public class AddRecordViewModel
    {
        public required Game Game { get; set; }

        public required List<PlayerRecord> PlayerRecords { get; set; }
    }
}
