﻿using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class BodyAlignDto
    {
        [JsonPropertyName("pattern")]
        public string Pattern { get; set; }
        [JsonPropertyName("subject")]
        public string Subject { get; set; }
        [JsonPropertyName("global")]
        public bool Global { get; set; }
    }
}