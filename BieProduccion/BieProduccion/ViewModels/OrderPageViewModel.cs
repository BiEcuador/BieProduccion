using BieProduccion.Models;
using Prism.Navigation;

namespace BieProduccion.ViewModels
{
    public class OrderPageViewModel : ViewModelBase
    {
        private OrdenProduccion _order;

        public OrderPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "OP: ...";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("Order"))
            {
                _order = parameters.GetValue<OrdenProduccion>("Order");
                Title = $"OP: {_order.NumPedido}";
            }
        }
    }
}
