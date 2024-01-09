using AppListaDeCompras.Libraries.Services;
using AppListaDeCompras.Models;
using AppListaDeCompras.Views.Popups;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mopups.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaDeCompras.ViewModels
{
    public partial class ListToBuyViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ListToBuy> _listToBuy;
        public ListToBuyViewModel() {
        
        }
        [RelayCommand]
        private async Task OnAppearing()
        {
            await MongoDBAtlasService.Init();
            await MongoDBAtlasService.LoginAsync();

            //TODO - Carregar os dados
        }

        [RelayCommand]
        private void OpenPopupSharePage(ListToBuy listSelected)
        {
            MopupService.Instance.PushAsync(new ListToBuySharePage(listSelected));
        }

        [RelayCommand]
        private void OpenListOfItensPage(ListToBuy listSelected)
        {
            var pageParameter = new Dictionary<string, object>() {
                { "ListToBuy", listSelected }
            };
            Shell.Current.GoToAsync("//ListToBuy/ListOfItens", pageParameter);
        }
    }
}
