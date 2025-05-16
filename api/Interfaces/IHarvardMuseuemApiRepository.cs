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
        Task<List<PropDTO.Record>?> FindProperties(PropSearchQuery searchQuery);
        Task<List<CardInfoDTO.Record>?> GetArtWorks(ArtPieceSearchQuery searchQuery);
        Task<ObjectMetadataDTO.Record?> GetObjectInformation(int objectId);
        Task<CardInfoDTO.SearchResults<CardInfoDTO.Record>?> GetArtworksBasedOnKeywords(KeywordSearchQuery searchQuery);
        Task<List<RelatedToDTO.RecordDTO>?> GetArtworkdsRelatedToObject(int objectId);
        Task<List<ExhibitionDTO.Exhibition>?> GetExhibitionListOfArtwork(int objectId);
        Task<List<PublicationDTO.Publication>?> GetPublicationsListOfArtwork(int objectId);
        Task<List<PersonOtherWorksDTO.RecordDTO>?> GetOtherArtworks(GetOtherArtworksQuery query);

        
        
    }
}