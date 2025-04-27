using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.HarvardMusemApiDTOS
{
    public class ObjectMetadataDTO
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Info
    {
        public int totalrecordsperquery { get; set; }
        public int totalrecords { get; set; }
        public int pages { get; set; }
        public int page { get; set; }
        public string responsetime { get; set; }
    }

    public class Person
    {
        public string? role { get; set; }
        public string? birthplace { get; set; }
        public string? gender { get; set; }
        public string? displaydate { get; set; }
        public object? prefix { get; set; }
        public string? culture { get; set; }
        public string? displayname { get; set; }
        public string? alphasort { get; set; }
        public string? name { get; set; }
        public int personid { get; set; }
        public string? deathplace { get; set; }
        public int? displayorder { get; set; }
    }

    public class Record
    {
        public string? technique { get; set; }
        public object? description { get; set; }
        public object? medium { get; set; }
        public string? classification { get; set; }
        public string? title { get; set; }
        public string? primaryimageurl { get; set; }
        public List<Person>? people { get; set; }
        public string? url { get; set; }
        public int? imagepermissionlevel { get; set; }
        public string? dated { get; set; }
        public int id { get; set; }
        public int objectid { get; set; }
        public string? dimensions { get; set; }
        public string? provenance { get; set; }
    }

    public class Root
    {
        public Info info { get; set; }
        public List<Record> records { get; set; }
    }


    }
}