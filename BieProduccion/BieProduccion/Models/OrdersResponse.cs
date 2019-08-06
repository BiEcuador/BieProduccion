using System.Collections.Generic;
using Newtonsoft.Json;

namespace BieProduccion.Models
{
    public class OrdersResponse
    {
        [JsonProperty("ordenProduccion")]
        public List<OrdenProduccion> OrdenProduccion { get; set; }
    }
}
