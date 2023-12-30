using AppListaDeCompras.Models;
using AppListaDeCompras.ViewModels.Popups;
using Mopups.Pages;

namespace AppListaDeCompras.Views.Popups;

public partial class ListToBuySharePage : PopupPage
{
	public ListToBuySharePage(ListToBuy list)
	{
		InitializeComponent();

		var vm = (ListToBuySharePageViewModel)BindingContext;
		vm.List = list;
	}
}