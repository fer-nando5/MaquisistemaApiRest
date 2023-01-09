using Maquisistema.Fondos.Dominio.Entity;
using Maquisistema.Fondos.Infraestructura.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Reflection.Metadata;

namespace Maquisistema.Fondos.Infraestructura.Repository
{
    public class DiscountProductRepository : IDiscountProductRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DiscountProductRepository(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;    
        }
        public async Task<int> GetDiscount(int id)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "/Api/V1/Product/" + id.ToString());
            var client = _httpClientFactory.CreateClient("DiscountApi");
            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return 0;
            }

            var responseDiscount = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<DiscountProduct>(responseDiscount, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (result == null)
                return 0;
            else
                return result.Discount;
        }

    }
}
