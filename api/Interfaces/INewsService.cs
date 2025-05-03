using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.NewsDTO;

namespace api.Interfaces
{
    public interface INewsService
    {
        Task<NewsDTO.Root?> GetLatestNewsAsync();
    }
}