using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace api.DTO.HarvardMusemApiDTOS
{
    public class ObjectMetadataDTO
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

    public class Person
    {
        [JsonProperty("role")]
        public string? Role { get; set; }
        [JsonProperty("birthplace")] 
        public string? Birthplace { get; set; }
        [JsonProperty("gender")]
        public string? Gender { get; set; }
        [JsonProperty("displaydate")]
        public string? DisplayDate { get; set; }
        [JsonProperty("prefix")]
        public object? Prefix { get; set; }
        [JsonProperty("culture")]
        public string? Culture { get; set; }
        [JsonProperty("dsiplayname")]
        public string? DisplayName { get; set; }
        [JsonProperty("alphasort")]
        public string? AlphaSort { get; set; }
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("personid")]
        public int PersonId { get; set; }
        [JsonProperty("deathplace")]
        public string? DeathPlace { get; set; }
        [JsonProperty("displayorder")]
        public int? DisplayOrder { get; set; }
    }

    public class Record
    {
        [JsonProperty("technique")]
        public string? Technique { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
        [JsonProperty("medium")]
        public string? Medium { get; set; }
        [JsonProperty("classification")]
        public string? Classification { get; set; }
        [JsonProperty("title")]
        public string? Title { get; set; }
        [JsonProperty("primaryimageurl")]
        public string? PrimaryImageUrl { get; set; }
        [JsonProperty("people")]
        public List<Person>? People { get; set; }
        [JsonProperty("url")]
        public string? Url { get; set; }
        [JsonProperty("imagepermissionlevel")]
        public int ImagePermissionLevel { get; set; }
        [JsonProperty("dated")]
        public string? Dated { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("objectid")]
        public int ObjectId { get; set; }
        [JsonProperty("dimensions")]
        public string? Dimensions { get; set; }
        [JsonProperty("provenance")]
        public string? Provenance { get; set; }
        [JsonProperty("culture")]
        public string? Culture { get; set; }
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