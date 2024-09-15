using System.ComponentModel.DataAnnotations;

namespace GameKeeper.Web.Models.Entities
{
    public partial class Player
    {

        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public virtual ICollection<PlayerRecord> PlayerRecords { get; set; } = new List<PlayerRecord>();
    }
}
