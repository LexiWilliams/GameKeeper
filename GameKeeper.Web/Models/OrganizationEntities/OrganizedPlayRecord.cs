using GameKeeper.Web.Models.Entities;

namespace GameKeeper.Web.Models.OrganizationEntities
{
    public class OrganizedPlayRecord
    {
        public Game? game;
        public List<Player>? playerList;
        public List<bool>? winnerList;

    }
}
