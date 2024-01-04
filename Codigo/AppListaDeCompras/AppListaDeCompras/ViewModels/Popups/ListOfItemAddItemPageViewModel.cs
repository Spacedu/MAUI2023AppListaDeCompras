using AppListaDeCompras.Models;
using AppListaDeCompras.Models.Enums;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mopups.Services;
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

        [ObservableProperty]
        private string[] unitsMeasure;

        public ListOfItemAddItemPageViewModel()
        {
            unitsMeasure = Enum.GetNames(typeof(UnitMeasure));
        }
        [RelayCommand]
        private void Close()
        {
            MopupService.Instance.PopAsync();
        }

        [RelayCommand]
        private void Save()
        {

        }
    }
}
