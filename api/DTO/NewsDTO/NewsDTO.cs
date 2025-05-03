using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.NewsDTO
{
    public class NewsDTO
    {
        public class Root
        {
            public string Status { get; set; }
            public List<News> News { get; set; }
            public int Page { get; set; }
        }

        public class News
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Url { get; set; }
            public string Author { get; set; }
            public string Image { get; set; }
            public string Language { get; set; }
            public List<string> Category { get; set; }
            public string Published { get; set; }
        }
    }
}