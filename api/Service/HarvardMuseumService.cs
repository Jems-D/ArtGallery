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

namespace api.Service
{
    public class HarvardMuseumService : IHarvardMuseuemApiRepository
    {
        private readonly HttpClient _httpClient;
        public HarvardMuseumService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CountryDTO.Record>> FindCountries(int parentId)
        {
            try{
                var result = await _httpClient.GetAsync($"https://api.harvardartmuseums.org/place?apikey=b32aafcc-321d-4f03-93ce-3534eb7c3080&parent={parentId}&level=2&size=20&fields=id,name");
                if(result.IsSuccessStatusCode){
                    var content = await result.Content.ReadAsStringAsync();
                    var task = JsonConvert.DeserializeObject<CountryDTO.Root>(content);
                    var records = task;
                    if(records != null){
                        return records.ToRecordFromCountryRoot().ToList();
                    }
                    
                }
                return null;
            }catch(Exception ex){
                return null;
            }
        }

        public async Task<List<RegionDTO.Record>> FindRegions()
        {
            try{
                var result = await _httpClient.GetAsync($"https://api.harvardartmuseums.org/place?apikey=b32aafcc-321d-4f03-93ce-3534eb7c3080&level=1&size=20&fields=id,name");
                if(result.IsSuccessStatusCode){
                    var content = await result.Content.ReadAsStringAsync();
                    var task = JsonConvert.DeserializeObject<RegionDTO.Root>(content);
                    var records = task;
                    if(records != null){
                        return records.ToRecordFromRegionRoot().ToList();
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
                var result = await _httpClient.GetAsync($"https://api.harvardartmuseums.org/object?apikey=b32aafcc-321d-4f03-93ce-3534eb7c3080&place={searchQuery.Id}&size=1&page={searchQuery.pageNumber}&fields=objectid,title,description,primaryimageurl,technique,classification");
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

        //https://api.harvardartmuseums.org/object?apikey=b32aafcc-321d-4f03-93ce-3534eb7c3080&id=203124 
    }
}