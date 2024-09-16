namespace GameKeeper.Web.Models.Entities
{
    public partial class GameGenre
    {
        public int Id { get; set; }

        public int GamesId { get; set; }

        public int GenresId { get; set; }

        public virtual Game Games { get; set; } = null!;

        public virtual Genre Genres { get; set; } = null!;
    }
}
