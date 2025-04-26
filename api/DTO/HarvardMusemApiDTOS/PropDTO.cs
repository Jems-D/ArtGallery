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
        public int totalrecordsperquery { get; set; }
        public int totalrecords { get; set; }
        public int pages { get; set; }
        public int page { get; set; }
        public string responsetime { get; set; }
    }

    public class Record
    {
        public string name { get; set; }
        public int id { get; set; }
        [JsonProperty("displayname")]
        private string displayname{
            set => name = value;
        }
        [JsonProperty("personid")]
        private int personid{
            set => id = value;
        }
    }

    public class Root
    {
        public Info info { get; set; }
        public List<Record> records { get; set; }
    }

    }
}