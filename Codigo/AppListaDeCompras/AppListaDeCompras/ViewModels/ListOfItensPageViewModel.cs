using AppListaDeCompras.Libraries.Services;
using AppListaDeCompras.Models;
using AppListaDeCompras.Views.Popups;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MongoDB.Bson;
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
            set {
                ListToBuyName = value!.Name;
                SetProperty(ref _listToBuy, value);
            }
        }

        [ObservableProperty]
        private string listToBuyName;
        public ListOfItensPageViewModel()
        {
            ListToBuy = new ListToBuy();

            if (!WeakReferenceMessenger.Default.IsRegistered<string>(string.Empty))
            {
                WeakReferenceMessenger.Default.Register<string>(string.Empty, (obj, str) => {
                    UpdateListToBuy();
                });
            }            
        }

        [RelayCommand]
        private async Task SaveListToBuy()
        {
            if (string.IsNullOrWhiteSpace(ListToBuyName)) {
                await App.Current!.MainPage!.DisplayAlert("Validação", "O nome da lista deve ser preenchido!", "OK");
                return;
            }

            var realm = MongoDBAtlasService.GetMainThreadRealm();
            await realm.WriteAsync(() => { 
                if(ListToBuy!.Id == default(ObjectId))
                {
                    ListToBuy.Id = ObjectId.GenerateNewId();
                    ListToBuy.Name = ListToBuyName;
                    ListToBuy.CreatedAt = DateTime.UtcNow;

                    realm.Add(ListToBuy);
                }
                else
                {
                    ListToBuy.Name = ListToBuyName;
                    realm.Add(ListToBuy, update: true);
                }
            });
        }

        [RelayCommand]
        private void BackPage()
        {
            Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private void OpenPopupAddItemPage()
        {
            MopupService.Instance.PushAsync(new ListOfItensAddItemPage(ListToBuy!));
        }

        [RelayCommand]
        private void OpenPopupEditItemPage(Product product)
        {
            MopupService.Instance.PushAsync(new ListOfItensAddItemPage(ListToBuy!, product));
        }

        [RelayCommand]
        private async Task DeleteItem(Product product)
        {
            var realm = MongoDBAtlasService.GetMainThreadRealm();
            await realm.WriteAsync(() => {
                realm.Remove(product);
            });
        }

        [RelayCommand]
        private void UpdateListToBuy()
        {
            OnPropertyChanged(nameof(ListToBuy));
        }
    }
}