using System;
using System.Net.Http;
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

    }
}
