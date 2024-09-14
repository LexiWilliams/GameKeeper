using GameKeeper.Web.Models.Entities;

namespace GameKeeper.Web.Models
{
    public class AddRecordViewModel
    {
        public Game? GameToRecord { get; set; }
        public required List<Game> GameList { get; set; }
        public required List<Player> PlayerList { get; set; }
        public List<Player>? PlayersToRecord { get; set; }
        public List<bool>? WinnerBoolList {  get; set; }
    }
}
