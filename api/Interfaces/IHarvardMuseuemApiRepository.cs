using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.HarvardMusemApiDTOS;
using api.Helpers.HarvardMuseumQueries;
using api.Models;
using static api.DTO.HarvardMusemApiDTOS.RegionDTO;

namespace api.Interfaces
{
    public interface IHarvardMuseuemApiRepository
    {
        Task<List<RegionDTO.Record>> FindRegions();
        Task<List<CountryDTO.Record>> FindCountries(int parentId);
        Task<List<CardInfoDTO.Record>> GetArtWorks(ArtPieceSearchQuery searchQuery);
    }
}