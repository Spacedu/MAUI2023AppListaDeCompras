using AppListaDeCompras.Libraries.Services;
using AppListaDeCompras.Libraries.Utilities;
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
        [ObservableProperty]
        private bool _enabledAddProduct;

        private ListToBuy? _listToBuy;
        public ListToBuy? ListToBuy
        {
            get => _listToBuy;
            set {
                ListToBuyName = value!.Name;
                SetProperty(ref _listToBuy, value);
                EnabledAddProduct = true;
            }
        }

        [ObservableProperty]
        private string listToBuyName;
        public ListOfItensPageViewModel()
        {
            ListToBuy = new ListToBuy();
            EnabledAddProduct = false;

            if (!WeakReferenceMessenger.Default.IsRegistered<string>("NewItem"))
            {
                WeakReferenceMessenger.Default.Register<string>("NewItem", (obj, str) => {
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
                    //Mongo > App Services > App User (User Anonymous)
                    

                    if (UserLoggedManager.ExistsUser())
                    {
                        var user = UserLoggedManager.GetUser();
                        var userDB = realm.All<User>().Where(a => a.Id == user.Id).FirstOrDefault();

                        if(userDB != null)
                        {
                            ListToBuy.Users.Add(userDB);
                        }
                    }
                    else
                    {
                        ListToBuy.AnonymousUserId = new ObjectId(MongoDBAtlasService.CurrentUser.Id);
                    }

                    realm.Add(ListToBuy);
                }
                else
                {
                    ListToBuy.Name = ListToBuyName;
                    realm.Add(ListToBuy, update: true);
                }
                EnabledAddProduct = true;
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