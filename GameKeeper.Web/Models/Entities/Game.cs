using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameKeeper.Web.Models.Entities
{
    public partial class Game
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Publisher { get; set; }

        public virtual ICollection<GameGenre> GameGenres { get; set; } = new List<GameGenre>();

        public virtual ICollection<GameRecord> GameRecords { get; set; } = new List<GameRecord>();
    }
}
