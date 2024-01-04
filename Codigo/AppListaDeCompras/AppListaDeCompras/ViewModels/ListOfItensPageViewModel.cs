using AppListaDeCompras.Models;
using AppListaDeCompras.Views.Popups;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mopups.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaDeCompras.ViewModels
{
    [QueryProperty(nameof(ListToBuy), "ListToBuy")]
    public partial class ListOfItensPageViewModel : ObservableObject
    {
        private ListToBuy? _listToBuy;
        public ListToBuy? ListToBuy
        {
            get => _listToBuy;
            set => SetProperty(ref _listToBuy, value);
        }

        [RelayCommand]
        private void UpdateListToBuy()
        {
            OnPropertyChanged(nameof(ListToBuy));
        }

        [RelayCommand]
        private void BackPage()
        {
            Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private void OpenPopupAddItemPage()
        {
            MopupService.Instance.PushAsync(new ListOfItensAddItemPage());
        }
    }
}
