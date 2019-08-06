using BieProduccion.ViewModels;
using Xamarin.Forms;

namespace BieProduccion.Views
{
    public partial class OrderPage : ContentPage
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            OrderPageViewModel.GetInstance().ChangeEntry(e.NewTextValue);
        }
    }
}
