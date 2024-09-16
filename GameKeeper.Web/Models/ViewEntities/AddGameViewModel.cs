using GameKeeper.Web.Models.Entities;

namespace GameKeeper.Web.Models.ViewEntities
{
    public class AddGameViewModel
    {
        public required string Name { get; set; }

        public string? Publisher { get; set; }

        public List<Genre> Genres { get; } = [];
    }
}
