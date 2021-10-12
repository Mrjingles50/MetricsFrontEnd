﻿using PetShopMetrics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PetShopMetrics
{
    public class MonitoringAPIClient 
    {
        public HttpClient _httpClient;
        
        public MonitoringAPIClient(HttpClient client)
        {
            _httpClient = client;
        }

///////////////////////////////////////////////////// MerchandiseFilter /////////////////////////////////////////
        
        public async Task<IEnumerable<MerchandiseFilter>> GetMerchandiseFilter() 
        {
            var response = await _httpClient.GetAsync("MerchandiseFilter");
            response.EnsureSuccessStatusCode();
            //var responseContent = await response.Content.ReadAsAsync<IEnumerable<MerchandiseFilter>>();
  
            return await response.Content.ReadAsAsync<IEnumerable<MerchandiseFilter>>();
        }

        public async Task<IEnumerable<MerchandiseFilter>> GetMerchandiseByCategory(string category) 
        {
            var response = await _httpClient.GetAsync($"MerchandiseFilter/ByCategory/{category}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<IEnumerable<MerchandiseFilter>>();
        }

        public async Task<IEnumerable<MerchandiseFilter>> GetMerchandiseByMonth(int month)
        {
            var response = await _httpClient.GetAsync($"MerchandiseFilter/ByMonth/{month}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<IEnumerable<MerchandiseFilter>>();
        }

        public async Task<int> GetMerchandiseSearchCountByMonthAndCategory(int month, string category)
        {
            var response = await _httpClient.GetAsync($"MerchandiseFilter/ByMonth/{month}");
            response.EnsureSuccessStatusCode();
            
            var responseContent = await response.Content.ReadAsAsync<IEnumerable<MerchandiseFilter>>();
            IEnumerable<MerchandiseFilter> list = responseContent.ToList().Where(x => x.Category == category);

            return list.Count();
        }

        /////////////////////////////////////////////////////////// Session //////////////////////////////////////////////

        public async Task<IEnumerable<Session>> GetSessions() 
        {
            var response = await _httpClient.GetAsync("Session");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<IEnumerable<Session>>();
        }
       
    }
}
