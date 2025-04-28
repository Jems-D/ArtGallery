using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace api.DTO.HarvardMusemApiDTOS
{
    public class PropDTO
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
            [JsonProperty("responsetime")]
            public required string? ResponseTime { get; set; }
    }

    public class Record
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("displayname")]
        private string? DisplayName{
            set => Name = value;
        }
        [JsonProperty("personid")]
        private int PersonId{
            set => Id = value;
        }
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