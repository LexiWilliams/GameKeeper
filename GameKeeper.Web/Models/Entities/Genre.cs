using System.ComponentModel.DataAnnotations;

namespace GameKeeper.Web.Models.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Game> Games { get; } = [];
    }
}
