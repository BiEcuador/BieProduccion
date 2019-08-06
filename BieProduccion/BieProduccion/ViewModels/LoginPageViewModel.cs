using BieProduccion.Models;
using BieProduccion.Services;
using Prism.Commands;
using Prism.Navigation;

namespace BieProduccion.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private string _password;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _loginCommand;

        public LoginPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Bie Producción";
            IsEnabled = true;

            //TODO: Delete those lines
            Email = "demo";
            Password = "ZGVtbw==";
        }

        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(Login));

        public string Email { get; set; }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes ingresar un email", "Acceptar");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes ingresar un password", "Acceptar");
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            var request = new LoginRequest
            {
                UserName = Email,
                Password = Password
            };

            var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.AuthenticateAsync(
                url, 
                "/api",
                "/Authentication/Authenticate", 
                request);

            IsRunning = false;
            IsEnabled = true;

            if (!response.Succeeded)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Usuario o contraseña no válidos", "Acceptar");
                Password = string.Empty;
                return;
            }

            var parameters = new NavigationParameters
            {
                { "Token", response }
            };

            await _navigationService.NavigateAsync("OrdersPage", parameters);
        }
    }
}
