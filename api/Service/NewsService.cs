using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.NewsDTO;
using api.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Newtonsoft.Json;

namespace api.Service
{
    public class NewsService :INewsService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<NewsService> _logger;
        private string? apiKey;
        public NewsService(HttpClient httpClient, ILogger<NewsService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            DotNetEnv.Env.Load();
            apiKey = Environment.GetEnvironmentVariable("CURRENT_NEWS_API_KEY");
        }

        public async Task<NewsDTO.Root?> GetLatestNewsAsync()
        {
            try{
                var result = await _httpClient.GetAsync($"https://api.currentsapi.services/v1/latest-news?category=art&limit=20&apiKey={apiKey}");
                if(result.IsSuccessStatusCode){
                    var content = await result.Content.ReadAsStringAsync();
                    var news = JsonConvert.DeserializeObject<NewsDTO.Root>(content);
                    if(news != null){
                        return news;
                    }
                }
                return null;

            }catch(Exception ex){
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}