﻿using GameKeeper.Web.Models.Entities;

namespace GameKeeper.Web.Models.ViewEntities
{
    public class EditRecordViewModel
    {
        public required Game GameToRecord { get; set; }

        public required List<PlayerRecord> PlayerRecords { get; set; }
    }
}
