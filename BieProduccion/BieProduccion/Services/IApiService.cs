using System.Threading.Tasks;
using BieProduccion.Models;

namespace BieProduccion.Services
{
    public interface IApiService
    {
        Task<LoginResponse> AuthenticateAsync(
            string urlBase, 
            string servicePrefix, 
            string controller, 
            LoginRequest request);

        Task<OrdersResponse> GetOrdenByProducto(
            string urlBase,
            string servicePrefix,
            string controller,
            string token);
    }
}