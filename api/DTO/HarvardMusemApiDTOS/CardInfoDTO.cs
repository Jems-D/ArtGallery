using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace api.DTO.HarvardMusemApiDTOS
{
    public class CardInfoDTO
    {
        public class Info
        {
            [JsonProperty("totalrecordsperquery")]
            public  required int TotalRecordsPerQuery { get; set; }
            [JsonProperty("totalrecords")]
            public required int TotalRecords { get; set; }
            [JsonProperty("pages")]
            public required int Pages { get; set; }
            [JsonProperty("page")]
            public required int Page { get; set; }
            [JsonProperty("next")]
            public required string? Next { get; set; }
            [JsonProperty("prev")]
            public required string? Prev { get; set; }
            [JsonProperty("responsetime")]
            public required string? ResponseTime { get; set; }
        }

        public class Record
        {
            [JsonProperty("imagepermissionlevel")]
            public int ImagePermissionLevel { get; set; }
            [JsonProperty("technique")]
            public string? Technique { get; set; }
            [JsonProperty("description")]
            public object? Description { get; set; }
            [JsonProperty("id")]
            public int Id { get; set; }
            [JsonProperty("classification")]
            public string? Classification { get; set; }
            [JsonProperty("title")]
            public string? Title { get; set; }
            [JsonProperty("primaryimageurl")]
            public string? PrimaryImageUrl { get; set; }
            [JsonProperty("objectid")]
            public int ObjectId { get; set; }
        }

        public class Root
        {
            [JsonProperty("info")]
            public Info? Info { get; set; }
            [JsonProperty("records")]
            public List<Record>? Records { get; set; }
        }


        public class SearchResults<T>
        {
            public int totaCount { get; set; }
            public int pageSize { get; set; }
            public int pageNumber { get; set; }
            public List<T>? artPieces { get; set; }    
        }

    }
}