﻿using api.Domain.Models;
using System.Text.Json.Serialization;

namespace api.Domain.Dto.Response
{
    public class PlacePerkResponse
    {
        public int PlaceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int PerkId { get; set; }
        public PerkResponse Perk { get; set; }
    }
}
