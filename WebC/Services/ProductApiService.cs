using Core;
using Core.DTOs;

namespace WebC.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<ProductDto>> GetAllProducts()
        {
            var result = await _httpClient.GetFromJsonAsync<CResponseDto<List<ProductDto>>>("products");
            return result.Data;
        }

        public async Task<ProductDto> Save(ProductDto productDto)
        {
            var result = await _httpClient.PostAsJsonAsync("products", productDto);
            if (!result.IsSuccessStatusCode) return null;

            var response = await result.Content.ReadFromJsonAsync<CResponseDto<ProductDto>>();
            return response.Data;

        }
    }
}