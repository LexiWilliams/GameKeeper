using Microsoft.Identity.Client;

namespace GameKeeper.Web.Models.Entities
{
    public class PlayerRecord
    {
        public int Id { get; set; }
        public required Player Player { get; set; }

        public bool Won { get; set; }
    }
}
