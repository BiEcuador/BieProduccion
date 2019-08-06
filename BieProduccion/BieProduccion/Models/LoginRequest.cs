using Newtonsoft.Json;

namespace BieProduccion.Models
{
    public class LoginRequest
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
