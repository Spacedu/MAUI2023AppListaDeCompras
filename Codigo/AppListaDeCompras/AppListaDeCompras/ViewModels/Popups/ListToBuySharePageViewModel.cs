using AppListaDeCompras.Libraries.Services;
using AppListaDeCompras.Models;
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
    public partial class ListToBuySharePageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? _email;

        [ObservableProperty]
        private ListToBuy _list = new ListToBuy() { };

        [RelayCommand]
        private void Close()
        {
            MopupService.Instance.PopAsync();
        }
        [RelayCommand]
        private void Add()
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                App.Current!.MainPage!.DisplayAlert("Erro!", "Preencha o campo E-mail!", "OK");
                return;
            }

            var realm = MongoDBAtlasService.GetMainThreadRealm();
            var user = realm.All<User>().Where(a => a.Email == Email.Trim().ToLower()).FirstOrDefault();

            if(user == null)
            {
                App.Current!.MainPage!.DisplayAlert("Não localizado.", "Usuário não localizado com o e-mail informado!", "OK");
                return;
            }

            realm.WriteAsync(() => {
                List.Users.Add(user);
            });
            
        }
    }
}
