using System.Collections.ObjectModel;
using System.Linq;
using BieProduccion.Models;
using BieProduccion.Services;
using Prism.Navigation;

namespace BieProduccion.ViewModels
{
    public class OrdersPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private LoginResponse _token;
        private ObservableCollection<OrderItemViewModel> _orders;
        private bool _isRefreshing;

        public OrdersPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "TALLA/ORDEN (Activas)";
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }


        public ObservableCollection<OrderItemViewModel> Orders
        {
            get => _orders;
            set => SetProperty(ref _orders, value);
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
            IsRefreshing = true;
            var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.GetOrdenByProducto(
                url,
                "/api",
                "/OrdenProduccion/GetOrdenByProducto",
                _token.JwtToken);

            Orders = new ObservableCollection<OrderItemViewModel>(response.OrdenProduccion.Select(o => new OrderItemViewModel(_navigationService)
            {
                Cliente = o.Cliente,
                NumPedido = o.NumPedido,
                OrdenEstado = o.OrdenEstado,
                OrdenId = o.OrdenId,
                Producto = o.Producto,
                Size = o.Size
            }).ToList());

            IsRefreshing = false;
        }
    }
}
