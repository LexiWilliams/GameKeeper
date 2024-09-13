using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameKeeper.Web.Models.Entities
{
    public class Game
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Publisher { get; set; }

        public List<Genre> Genres { get; } = [];
    }
}
