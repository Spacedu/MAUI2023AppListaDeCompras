using AppListaDeCompras.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaDeCompras.ViewModels.Popups
{
    public partial class ListOfItemAddItemPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private Product? product;
    }
}
