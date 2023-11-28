using AppListaDeCompras.Views;

namespace AppListaDeCompras
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new FirstPage();
        }
    }
}
