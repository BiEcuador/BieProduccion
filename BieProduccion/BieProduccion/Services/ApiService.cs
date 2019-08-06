using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BieProduccion.Models;
using Newtonsoft.Json;

namespace BieProduccion.Services
{
    public class ApiService : IApiService
    {
        public async Task<LoginResponse> AuthenticateAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            LoginRequest request)
        {
            try
            {
                var requestString = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestString, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{servicePrefix}{controller}";
                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<LoginResponse>(result);
            }
            catch (Exception ex)
            {
                return new LoginResponse
                {
                    Succeeded = false,
                    Title = ex.Message
                };
            }
        }

        public async Task<OrdersResponse> GetOrdenByProducto(
            string urlBase,
            string servicePrefix,
            string controller,
            string token)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                var url = $"{servicePrefix}{controller}";
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                return JsonConvert.DeserializeObject<OrdersResponse>(result);
            }
            catch
            {
                return null;
            }
        }
    }
}
