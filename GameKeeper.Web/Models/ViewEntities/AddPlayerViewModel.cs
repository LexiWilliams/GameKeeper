﻿namespace GameKeeper.Web.Models.ViewEntities
{
    public class AddPlayerViewModel
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }

        public required string LastName { get; set; }
    }
}
