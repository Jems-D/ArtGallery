using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace api.DTO.HarvardMusemApiDTOS
{
    public class PersonOtherWorksDTO
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
            public string? Title { get; set; }
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
            public string? Title { get; set; }
            public int ObjectId { get; set; }
        }

    }
}