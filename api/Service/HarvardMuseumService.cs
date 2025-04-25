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
namespace api.Service
{
    public class HarvardMuseumService : IHarvardMuseuemApiRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string? apiKey;
        public HarvardMuseumService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            DotNetEnv.Env.Load();
            apiKey = Environment.GetEnvironmentVariable("HARVARD_MUSEUM_API_KEY");
        }


        public async Task<List<PropDTO.Record>> FindProperties(PropSearchQuery searchQuery)
        {
            try{
                var result = await _httpClient.GetAsync($"https://api.harvardartmuseums.org/{searchQuery.property}?apikey={apiKey}&level=1&size=100&page={searchQuery.pageNumber}{(searchQuery.property != "person" ? "&sort=name&fields=id,name" : "&fields=displayname,personid")}");
                if(result.IsSuccessStatusCode){
                    var content = await result.Content.ReadAsStringAsync();
                    var task = JsonConvert.DeserializeObject<PropDTO.Root>(content);
                    var records = task;
                    if(records != null){
                        return records.ToRecordFromPropRoot().ToList();
                    }
                    
                }
                    return null;
            }catch(Exception ex){
                return null;
            }
        }

        public async Task<List<CardInfoDTO.Record>> GetArtWorks(ArtPieceSearchQuery searchQuery)
        {
            try{
                var result = await _httpClient.GetAsync($"https://api.harvardartmuseums.org/object?apikey={apiKey}&{searchQuery.property}={searchQuery.Id}&size=5&page={searchQuery.pageNumber}&fields=objectid,title,primaryimageurl,technique,classification");
                if(result.IsSuccessStatusCode){
                    var content = await result.Content.ReadAsStringAsync();
                    var task = JsonConvert.DeserializeObject<CardInfoDTO.Root>(content);
                    if(task != null){
                        return task.ToCardInfoFromRoot().ToList();
                    }
                }
                return null;
            }catch(Exception err){
                return null;
            }
        }

        public async Task<ObjectMetadataDTO.Record?> GetObjectInformation(int objectId)
        {
            try{
                var result = await _httpClient.GetAsync($"https://api.harvardartmuseums.org/object?apikey={apiKey}&id={objectId}&fields=objectid,title,medium,classification,technique,dimensions,dated,genre,description,location,primaryimageurl,url,placeoforigin,people");      
                if(result.IsSuccessStatusCode){
                    var content = await result.Content.ReadAsStringAsync();
                    var task = JsonConvert.DeserializeObject<ObjectMetadataDTO.Root>(content);
                    if(task != null){
                        return task.ToObjMtdFromRoot();
                    }
                }
                return null;
            }catch(Exception ex){
                return null;
            }
        }

        
        
        
  
    }
}