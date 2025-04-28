using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace api.DTO.HarvardMusemApiDTOS
{
    public class PublicationDTO
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
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

    public class Publication
    {
        [JsonProperty("publicationplace")]
        public string? PublicationPlace { get; set; }
        [JsonProperty("citation")]
        public string? Citation { get; set; }
        [JsonProperty("publicationyear")]
        public int PublicationYear { get; set; }
        [JsonProperty("pagenumbers")]
        public string? PageNumbers { get; set; }
        [JsonProperty("format")]
        public string? Format { get; set; }
        [JsonProperty("title")]
        public string? Title { get; set; }
    }

    public class Record
    {
        [JsonProperty("imagepermissionlevel")]
        public int ImagePermissionLevel { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("publications")]
        public List<Publication>? Publications { get; set; }
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