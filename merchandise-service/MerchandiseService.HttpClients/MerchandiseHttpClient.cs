﻿using MerchandiseService.HttpModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.HttpClients
{
    public interface IMerchandiseHttpClient
    {
        Task<List<MerchandiseItemResponse>> V1GetAll(CancellationToken token);
    }

    public class MerchandiseHttpClient : IMerchandiseHttpClient
    {
        private readonly HttpClient _httpClient;

        public MerchandiseHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MerchandiseItemResponse>> V1GetAll(CancellationToken ct)
        {
            using var response = await _httpClient.GetAsync("v1/api/merchandise", ct);
            var body = await response.Content.ReadAsStringAsync(ct);
            return JsonSerializer.Deserialize<List<MerchandiseItemResponse>>(body);
        }

        public async Task<List<MerchandiseItemResponse>> V1PostMerch(CancellationToken ct)
        {
            using var response = await _httpClient.GetAsync("v1/api/merchandise", ct);
            var body = await response.Content.ReadAsStringAsync(ct);
            return JsonSerializer.Deserialize<List<MerchandiseItemResponse>>(body);
        }
    }
}