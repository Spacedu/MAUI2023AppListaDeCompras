using AppListaDeCompras.Models;
using AppListaDeCompras.ViewModels.Popups;
using Mopups.Pages;

namespace AppListaDeCompras.Views.Popups;

public partial class ListOfItensAddItemPage : PopupPage
{
	public ListOfItensAddItemPage(ListToBuy listToBuy)
	{
		InitializeComponent();

		var vm = (ListOfItemAddItemPageViewModel)BindingContext;
        vm.List = listToBuy;
    }
}