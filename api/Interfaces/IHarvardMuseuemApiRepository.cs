using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.HarvardMusemApiDTOS;
using api.Helpers;
using api.Helpers.HarvardMuseumQueries;
using api.Models;
using static api.DTO.HarvardMusemApiDTOS.PropDTO;

namespace api.Interfaces
{
    public interface IHarvardMuseuemApiRepository
    {
        Task<List<PropDTO.Record>> FindProperties(PropSearchQuery searchQuery);
        Task<List<CardInfoDTO.Record>> GetArtWorks(ArtPieceSearchQuery searchQuery);
        Task<ObjectMetadataDTO.Record?> GetObjectInformation(int objectId);
        
        
    }
}