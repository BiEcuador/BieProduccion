using Newtonsoft.Json;

namespace BieProduccion.Models
{
    public class OrdenProduccion
    {
        [JsonProperty("ordenId")]
        public long OrdenId { get; set; }

        [JsonProperty("numPedido")]
        public string NumPedido { get; set; }

        [JsonProperty("cliente")]
        public string Cliente { get; set; }

        [JsonProperty("producto")]
        public string Producto { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("ordenEstado")]
        public long OrdenEstado { get; set; }

        public string NumPedidoAndCliente => $"{NumPedido} ({Cliente})";
    }
}
