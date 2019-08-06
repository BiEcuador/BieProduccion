using BieProduccion.Models;
using Prism.Navigation;

namespace BieProduccion.ViewModels
{
    public class OrderPageViewModel : ViewModelBase
    {
        private OrdenProduccion _order;
        private bool _hasPallet;
        private bool _hasOperador;
        private bool _hasTipoProducto;
        private bool _isEnabled;
        private string _picking;
        private static OrderPageViewModel instance;
        private string _pallet;
        private string _operador;
        private string _tipoProducto;
        private bool _isRunning;

        public OrderPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            instance = this;
            Title = "OP: ...";
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public string Operador
        {
            get => _operador;
            set => SetProperty(ref _operador, value);
        }

        public string Pallet
        {
            get => _pallet;
            set => SetProperty(ref _pallet, value);
        }

        public string TipoProducto
        {
            get => _pallet;
            set => SetProperty(ref _tipoProducto, value);
        }

        public string Picking
        {
            get => _picking;
            set => SetProperty(ref _picking, value);
        }

        public bool HasPallet
        {
            get => _hasPallet;
            set => SetProperty(ref _hasPallet, value);
        }

        public bool HasOperador
        {
            get => _hasOperador;
            set => SetProperty(ref _hasOperador, value);
        }

        public bool HasTipoProducto
        {
            get => _hasTipoProducto;
            set => SetProperty(ref _hasTipoProducto, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public static OrderPageViewModel GetInstance()
        {
            return instance;
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

        public void ChangeEntry(string entry)
        {
            var blank = false;
            //TODO: Setup the same scanner character
            if (entry.Contains("*"))
            {
                entry = entry.Substring(0, entry.Length - 1);
                blank = true;
            }

            if (entry.StartsWith("OP"))
            {
                Operador = entry.Substring(2);
            }

            if (entry.StartsWith("PL"))
            {
                Pallet = entry.Substring(2);
            }

            if (entry.StartsWith("PR"))
            {
                TipoProducto = entry.Substring(2);
            }

            if (blank)
            {
                Picking = string.Empty;
            }

            ValidateFlags();
        }

        private void ValidateFlags()
        {
            HasPallet = !string.IsNullOrEmpty(Pallet);
            HasOperador = !string.IsNullOrEmpty(Operador);
            HasTipoProducto = !string.IsNullOrEmpty(TipoProducto);
            IsEnabled = HasPallet && HasOperador && HasTipoProducto;
        }
    }
}
