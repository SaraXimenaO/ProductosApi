using Azure;
using Microsoft.Extensions.Configuration;
using Products.Domain.Entities;
using Products.Domain.Ports;
using System.Net;
using System.Text.Json;

namespace Products.Infrastructure.Adapters
{
    public class DiscountService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public DiscountService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<DiscountResponse> GetDiscountAsync(int productId)
        {
            try
            {
                var serviceUrl = _configuration.GetValue<string>("DiscountServiceUrl");
                var response = await _httpClient.GetAsync($"{serviceUrl}/{productId}");


                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Failed to retrieve discount. Status code: {response.StatusCode}");
                }

                var contentStream = await response.Content.ReadAsStreamAsync();
                var resp = await JsonSerializer.DeserializeAsync<DiscountResponse>(contentStream);
                return resp;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Failed to retrieve discount. Status code: {(int)HttpStatusCode.InternalServerError}", ex);
            }
        }
    }
}
