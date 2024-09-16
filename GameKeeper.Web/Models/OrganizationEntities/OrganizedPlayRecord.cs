using GameKeeper.Web.Models.Entities;

namespace GameKeeper.Web.Models.OrganizationEntities
{
    public class OrganizedPlayRecord
    {
        public int GameRecordId;
        public Game? game;
        public List<Player>? playerList;
        public List<PlayerRecord>? winnerList;
        public List<PlayerRecord> playerRecordList;
        public List<bool>? winnerBoolList;

    }
}
