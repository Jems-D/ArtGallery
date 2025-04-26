using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.HarvardMusemApiDTOS
{
    public class PublicationDTO
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

    public class Publication
    {
        public string publicationplace { get; set; }
        public string citation { get; set; }
        public int publicationyear { get; set; }
        public string pagenumbers { get; set; }
        public string format { get; set; }
        public string title { get; set; }
    }

    public class Record
    {
        public int imagepermissionlevel { get; set; }
        public int id { get; set; }
        public List<Publication> publications { get; set; }
    }

    public class Root
    {
        public Info info { get; set; }
        public List<Record> records { get; set; }
    }


    }
}