using System.ComponentModel.DataAnnotations;

namespace GameKeeper.Web.Models.Entities
{
    public class Player
    {
        public Guid Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }
    }
}
