using GameKeeper.Web.Models.Entities;

namespace GameKeeper.Web.Models.OrganizationEntities
{
    public class PLayRecordRawData
    {
        public List<Game>? gameList { get; set; }
        public List<Player>? playerList { get; set; }
        public List<Genre>? genreList { get; set; }
        public List<PlayerRecord>? playerRecordList { get; set; }
        public List<GameRecord>? gameRecordList { get; set; }

    }
}
