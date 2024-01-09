using AppListaDeCompras.Libraries.Services;

namespace AppListaDeCompras.Views;

public partial class ListToBuyPage : ContentPage
{
	public ListToBuyPage()
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        await MongoDBAtlasService.Init();
        await MongoDBAtlasService.LoginAsync();
    }
}