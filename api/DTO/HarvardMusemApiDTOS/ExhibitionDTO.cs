using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace api.DTO.HarvardMusemApiDTOS
{
    public class ExhibitionDTO
    {
        public class Exhibition
        {
            [JsonProperty("begindate")]
            public string? Begindate { get; set; }
            [JsonProperty("enddate")]
            public string? Enddate { get; set; }
            [JsonProperty("citation")]
            public string? Citation { get; set; }
            [JsonProperty("exhibitionid")]
            public int ExhibitionId { get; set; }
            [JsonProperty("title")]
            public string? Title { get; set; }
        }

        public class Info
        {
            [JsonProperty("totalrecordsperquery")]
            public  required int TotalRecordsPerQuery { get; set; }
            [JsonProperty("totalrecords")]
            public required int TotalRecords { get; set; }
            [JsonProperty("pages")]
            public required int Pages { get; set; }
            [JsonProperty("page")]
            public required string? Prev { get; set; }
            [JsonProperty("responsetime")]
            public required string? ResponseTime { get; set; }
        }

        public class Record
        {
            [JsonProperty("exhibitions")]
            public List<Exhibition>? Exhibitions { get; set; }
            [JsonProperty("imagepermissionlevel")]
            public int ImagePermissionLevel { get; set; }
            [JsonProperty("id")]
            public int Id { get; set; }
        }

        public class Root
        {
            [JsonProperty("info")]
            public Info? Info { get; set; }
            [JsonProperty("records")]
            public List<Record>? Records { get; set; }
        }
    }
}