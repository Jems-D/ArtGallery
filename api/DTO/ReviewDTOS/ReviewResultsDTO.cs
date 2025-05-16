using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.ReviewDTOS
{
    public class ReviewResultsDTO<T>
    {
        public int totalCount { get; set; }
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public List<T>? reviews { get; set; }
    }
}