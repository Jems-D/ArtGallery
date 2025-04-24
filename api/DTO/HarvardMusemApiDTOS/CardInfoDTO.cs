using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.HarvardMusemApiDTOS
{
    public class CardInfoDTO
    {
         public class Info
    {
        public int totalrecordsperquery { get; set; }
        public int totalrecords { get; set; }
        public int pages { get; set; }
        public int page { get; set; }
        public string? next { get; set; }
        public string? prev { get; set; }
        public string? responsetime { get; set; }
    }

    public class Record
    {
        public int imagepermissionlevel { get; set; }
        public string? technique { get; set; }
        public object? description { get; set; }
        public int id { get; set; }
        public string? classification { get; set; }
        public string? title { get; set; }
        public string? primaryimageurl { get; set; }
        public int objectid { get; set; }
    }

    public class Root
    {
        public Info info { get; set; }
        public List<Record> records { get; set; }
    }

    }
}