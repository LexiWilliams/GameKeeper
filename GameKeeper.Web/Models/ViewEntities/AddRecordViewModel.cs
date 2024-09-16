using GameKeeper.Web.Models.Entities;

namespace GameKeeper.Web.Models.ViewEntities
{
    public class AddRecordViewModel
    {
        public Game? GameToRecord { get; set; }
        public List<Game>? GameList { get; set; }
        public List<Player>? PlayerList { get; set; }
        public List<Player>? PlayersToRecord { get; set; }
        public List<Player>? WinnerPlayerList { get; set; }
    }
}
