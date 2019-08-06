using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BieProduccion.Models
{
    public class LoginResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("jwtToken")]
        public string JwtToken { get; set; }

        [JsonProperty("tokenRefresh")]
        public string TokenRefresh { get; set; }

        [JsonProperty("succeeded")]
        public bool Succeeded { get; set; }

        [JsonProperty("type")]
        public Uri Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("traceId")]
        public Guid TraceId { get; set; }
    }
}
