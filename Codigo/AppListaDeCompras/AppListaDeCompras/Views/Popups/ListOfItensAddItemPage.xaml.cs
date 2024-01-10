using AppListaDeCompras.Models;
using AppListaDeCompras.ViewModels.Popups;
using Mopups.Pages;

namespace AppListaDeCompras.Views.Popups;

public partial class ListOfItensAddItemPage : PopupPage
{
    /// <summary>
    /// Construtor usado para cadastro do produto
    /// </summary>
    /// <param name="listToBuy"></param>
	public ListOfItensAddItemPage(ListToBuy listToBuy)
	{
		InitializeComponent();

		var vm = (ListOfItemAddItemPageViewModel)BindingContext;
        vm.List = listToBuy;
    }
    /// <summary>
    /// Construtor usado para edição do produto
    /// </summary>
    /// <param name="listToBuy"></param>
    public ListOfItensAddItemPage(ListToBuy listToBuy, Product product)
    {
        InitializeComponent();

        var vm = (ListOfItemAddItemPageViewModel)BindingContext;
        vm.List = listToBuy;
        vm.Product = product;
    }
}