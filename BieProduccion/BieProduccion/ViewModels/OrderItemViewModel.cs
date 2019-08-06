using BieProduccion.Models;
using Prism.Commands;
using Prism.Navigation;

namespace BieProduccion.ViewModels
{
    public class OrderItemViewModel : OrdenProduccion
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectOrderCommand;

        public OrderItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectOrderCommand => _selectOrderCommand ?? (_selectOrderCommand = new DelegateCommand(SelectOrder));

        private async void SelectOrder()
        {
            var parameters = new NavigationParameters
            {
                { "Order", this }
            };

            await _navigationService.NavigateAsync("OrderPage", parameters);
        }
    }
}
