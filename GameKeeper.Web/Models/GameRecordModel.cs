using GameKeeper.Web.Models.Entities;

namespace GameKeeper.Web.Models
{
    public class GameRecordModel
    {
        public required Game Game { get; set; }

        public required List<PlayerRecordModel> PlayerRecords { get; set; }
    }
}
