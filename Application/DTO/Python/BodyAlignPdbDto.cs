﻿using System.Text.Json.Serialization;

namespace Application.DTO.Python
{
    public class BodyAlignPdbDto
    {
        [JsonPropertyName("prediction_pdb")]
        public byte[] PredictionPdb { get; set; }
        [JsonPropertyName("reference_pdb")]
        public byte[] ReferencePdb { get; set; }
    }
}
//python