﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Text.Json;
using System.Net.Http.Headers;
using WeatherObservationAnalysis.Models;
using System.Text.Json.Serialization;

namespace WeatherObservationAnalysis.Services
{
    public class NWSDetailsService
    {
        private IConfiguration configuration { get; set; } = default!;
        
        private readonly IHttpClientFactory clientFactory; 

        private readonly HttpClient? httpClient;
        private string? stationId { get; set; }
        private string? start { get; set; }
        private string? end { get; set; }
        private int? limit { get; set; }
        private string? closestWeatherStationURL { get; set; }
        private string? histWeatherObsPrefixURL { get; set; }
        private string? histWeatherObsSuffixURL { get; set; }
        private string? BaseUrl { get; set; }

        public NWSDetailsService(HttpClient _httpClient, IConfiguration _configuration,
            IHttpClientFactory _clientFactory)
        {
            this.httpClient = _httpClient;
            this.configuration = _configuration;
            this.clientFactory = _clientFactory;

            BaseUrl = configuration.GetValue<string>("NWSAPI:BaseUrl");

            this.closestWeatherStationURL = $"{BaseUrl}stations/";
            this.histWeatherObsPrefixURL = $"{BaseUrl}stations/" + stationId; 
            this.histWeatherObsSuffixURL = $"/observations";
        }

        public async Task<Stations> GetClosestWeatherStation(string location)
        {
            Stations result = new Stations();
            
            var url = string.Format(closestWeatherStationURL + location);

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/geo+json");
            request.Headers.Add("User-Agent", "My application");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<Stations>(stringResponse);
            }

            return result;
        }

        public async Task<Feature> GetHistWeatherObservations(string location) 
        {
            Feature histResult = new Feature();

            var url = string.Format(histWeatherObsPrefixURL + location + histWeatherObsSuffixURL);

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/geo+json");
            request.Headers.Add("User-Agent", "My application");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                histResult = JsonSerializer.Deserialize<Feature>(stringResponse);
            }

            return histResult;
        }
    }
}
