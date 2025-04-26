using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.HarvardMusemApiDTOS
{
    public class RelatedToDTO
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
        public int imagepermissionlevel { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public int objectid { get; set; }
    }

    public class Root
    {
        public Info info { get; set; }
        public List<Record> records { get; set; }
    }
    }
}