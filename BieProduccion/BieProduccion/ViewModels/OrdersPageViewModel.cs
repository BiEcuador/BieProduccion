using System;
using BieProduccion.Models;
using BieProduccion.Services;
using Prism.Navigation;

namespace BieProduccion.ViewModels
{
    public class OrdersPageViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private LoginResponse _token;

        public OrdersPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _apiService = apiService;
            Title = "TALLA/ORDEN (Activas)";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("Token"))
            {
                _token = parameters.GetValue<LoginResponse>("Token");
            }

            LoadOrders();
        }

        private async void LoadOrders()
        {
            var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.GetOrdenByProducto(
                url, 
                "/api",
                "/OrdenProduccion/GetOrdenByProducto", 
                _token.JwtToken);
        }
    }
}
