﻿using api.Domain.Models;
using System.Text.Json.Serialization;

namespace api.Domain.Dto.Response
{
    public class PerkResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
