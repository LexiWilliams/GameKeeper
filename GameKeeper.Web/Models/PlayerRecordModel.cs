using GameKeeper.Web.Models.Entities;

namespace GameKeeper.Web.Models
{
    public class PlayerRecordModel
    {
        public required Player Player { get; set; }

        public bool Won { get; set; }
    }
}
