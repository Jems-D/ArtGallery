using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.HarvardMusemApiDTOS;
using api.Helpers.HarvardMuseumQueries;
using api.Interfaces;
using api.Mappers.HarvardMuseumApi;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using DotNetEnv;
using Humanizer;
namespace api.Service
{
    public class HarvardMuseumService : IHarvardMuseuemApiRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string? apiKey;
        private readonly ILogger<HarvardMuseumService> _logger;
        public HarvardMuseumService(HttpClient httpClient, ILogger<HarvardMuseumService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            DotNetEnv.Env.Load();
            apiKey = Environment.GetEnvironmentVariable("HARVARD_MUSEUM_API_KEY");
        }


        public async Task<CardInfoDTO.SearchResults<PropDTO.Record>> FindProperties(PropSearchQuery searchQuery)
        {
            try{
                var result = await _httpClient.GetAsync($"https://api.harvardartmuseums.org/{searchQuery.property}?apikey={apiKey}&level=1&size=20&page={searchQuery.pageNumber}{(searchQuery.property != "person" ? "&sort=name&fields=id,name" : "&fields=displayname,personid")}");
                if(result.IsSuccessStatusCode){
                    var content = await result.Content.ReadAsStringAsync();
                    var task = JsonConvert.DeserializeObject<PropDTO.Root>(content);
                    var records = task;
                    if(records != null){
                        var results = new CardInfoDTO.SearchResults<PropDTO.Record>
                        {
                            pageNumber = searchQuery.pageNumber,
                            totaCount = task.Info.TotalRecords,
                            pageSize = 20,
                            type= searchQuery.property,
                            result = records.ToRecordFromPropRoot()?.ToList(),
                        };
                        return results;
                    }
                    
                }
                    return null;
            }catch(Exception ex){
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<List<RelatedToDTO.RecordDTO>?> GetArtworkdsRelatedToObject(int objectId)
        {
            try{
                var result = await _httpClient.GetAsync($"https://api.harvardartmuseums.org/object?apikey={apiKey}&relatedto={objectId}&size=3&fields=title,objectid");
                var content = await result.Content.ReadAsStringAsync();
                var task = JsonConvert.DeserializeObject<RelatedToDTO.Root>(content);
                if(task != null){
                    return task.ToRecordFromRelatedRoot()?.ToList();
                }
                return null;

            }catch(Exception ex){
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<CardInfoDTO.SearchResults<CardInfoDTO.Record>> GetArtWorks(ArtPieceSearchQuery searchQuery)
        {
            try{
                var result = await _httpClient.GetAsync($"https://api.harvardartmuseums.org/object?apikey={apiKey}&{searchQuery.property}={searchQuery.Id}&size=20&page={searchQuery.pageNumber}&fields=objectid,title,primaryimageurl,technique,classification");
                if(result.IsSuccessStatusCode){
                    var content = await result.Content.ReadAsStringAsync();
                    var task = JsonConvert.DeserializeObject<CardInfoDTO.Root>(content);
                    if(task != null){
                        var records = new CardInfoDTO.SearchResults<CardInfoDTO.Record>
                        {
                            pageNumber = searchQuery.pageNumber,
                            pageSize = 20,
                            totaCount = task.Info.TotalRecords,
                            result = task.ToCardInfoFromRoot().ToList()
                        };

                        return records;
                    }
                }
                return null;
            }catch(Exception err){
                _logger.LogError(err, err.Message);
                return null;
            }
        }

        public async Task<CardInfoDTO.SearchResults<CardInfoDTO.Record>> GetArtworksBasedOnKeywords(KeywordSearchQuery searchQuery)
        {
            try{
                var result = await _httpClient.GetAsync($"https://api.harvardartmuseums.org/object?apikey={apiKey}&q={searchQuery.keyword}&size=20&page={searchQuery.pageNumber}&fields=objectid,title,primaryimageurl,technique,classification");
                if(result.IsSuccessStatusCode){
                    var content = await result.Content.ReadAsStringAsync();
                    var task = JsonConvert.DeserializeObject<CardInfoDTO.Root>(content);
                    if(task != null){
                        var artPieces = new CardInfoDTO.SearchResults<CardInfoDTO.Record>{
                            pageNumber = searchQuery.pageNumber,
                            totaCount = task.Info.TotalRecords,
                            pageSize = 20,
                            result = task.ToCardInfoFromRoot()?.ToList()
                        };
                        return artPieces;
                    }
                }
                return null;
            }catch(Exception ex){
                _logger.LogError(ex, ex.Message);
                return  null;
            }
        }

        public async Task<List<ExhibitionDTO.Exhibition>?> GetExhibitionListOfArtwork(int objectId)
        {
            try{
                var result = await _httpClient.GetAsync($"https://api.harvardartmuseums.org/object?apikey={apiKey}&id={objectId}&fields=exhibitions");
                if(result.IsSuccessStatusCode){
                     var content = await result.Content.ReadAsStringAsync();
                     var task = JsonConvert.DeserializeObject<ExhibitionDTO.Root>(content);
                     if(task != null){
                        var reversed = task.ToExhibitionFromExhibitionRoot();
                        reversed?.Reverse();
                        return reversed;
                    }
                }
                return null;
            }catch(Exception err){
                _logger.LogError(err, err.Message);
                return null;
            }
        }

        public async Task<ObjectMetadataDTO.Record?> GetObjectInformation(int objectId)
        {
            try{
                var result = await _httpClient.GetAsync($"https://api.harvardartmuseums.org/object?apikey={apiKey}&id={objectId}&fields=objectid,title,medium,classification,technique,dimensions,dated,genre,description,location,primaryimageurl,url,culture,people");      
                if(result.IsSuccessStatusCode){
                    var content = await result.Content.ReadAsStringAsync();
                    var task = JsonConvert.DeserializeObject<ObjectMetadataDTO.Root>(content);
                    if(task != null){
                        return task.ToObjMtdFromRoot();
                    }
                }
                return null;
            }catch(Exception ex){
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<List<PersonOtherWorksDTO.RecordDTO>?> GetOtherArtworks(GetOtherArtworksQuery query)
        {
            try{
                var result = await _httpClient.GetAsync($"https://api.harvardartmuseums.org/object?apikey={apiKey}&person={query.personId}&q=-id:{query.objectId}&size=20&fields=title,objectid");
                if(result.IsSuccessStatusCode){
                     var content = await result.Content.ReadAsStringAsync();
                    var task = JsonConvert.DeserializeObject<PersonOtherWorksDTO.Root>(content);
                    if(task != null){
                        return task.ToRecordFromOtherWorksDTO();
                    }
                }
                return null;
            }catch(Exception ex){
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<List<PublicationDTO.Publication>?> GetPublicationsListOfArtwork(int objectId)
        {
            try{
                var result = await _httpClient.GetAsync($"https://api.harvardartmuseums.org/object?apikey={apiKey}&id={objectId}&fields=publications.citation,publications.title,publications.publicationyear,publications.publicationplace,publications.format,publications.pagenumbers");
                if(result.IsSuccessStatusCode){
                    var content = await result.Content.ReadAsStringAsync();
                    var task = JsonConvert.DeserializeObject<PublicationDTO.Root>(content);
                    if(task != null){
                        var reversed = task.ToPublicationFromPublicationRoot();
                        reversed?.Reverse();
                        return reversed;
                    }
                }
                return null;
                
            }catch(Exception ex){
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }
    }
}