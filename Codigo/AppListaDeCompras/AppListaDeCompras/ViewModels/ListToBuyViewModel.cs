using AppListaDeCompras.Libraries.Services;
using AppListaDeCompras.Models;
using AppListaDeCompras.Views.Popups;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mopups.Services;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources.Management;

namespace AppListaDeCompras.ViewModels
{
    public partial class ListToBuyViewModel : ObservableObject
    {
        [ObservableProperty]
        private IQueryable<ListToBuy> _listsOfListToBuy;
        public ListToBuyViewModel() {
        
        }
        [RelayCommand]
        private async Task OnAppearing()
        {
            await MongoDBAtlasService.Init();
            await MongoDBAtlasService.LoginAsync();

            var realm = MongoDBAtlasService.GetMainThreadRealm();
            ListsOfListToBuy = realm.All<ListToBuy>();
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
