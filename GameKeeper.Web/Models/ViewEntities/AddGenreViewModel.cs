﻿using GameKeeper.Web.Models.Entities;

namespace GameKeeper.Web.Models.ViewEntities
{
    public class AddGenreViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Game> Games { get; } = [];
    }
}

