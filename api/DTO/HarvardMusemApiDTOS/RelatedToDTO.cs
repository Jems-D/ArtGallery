using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace api.DTO.HarvardMusemApiDTOS
{
    public class RelatedToDTO
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
            public required string? Prev { get; set; }
            [JsonProperty("responsetime")]
            public required string? ResponseTime { get; set; }
        }

        public class Record
        {
            [JsonProperty("imagepermissionlevel")]
            public int ImagePermissionLevel { get; set; }
            [JsonProperty("id")]
            public int Id { get; set; }
            [JsonProperty("title")]
            public string? Title { get; set; } = string.Empty;
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

        public class RecordDTO
        {
            public string? Title { get; set; } = string.Empty;
            public int ObjectId { get; set; }
        }
    }
}