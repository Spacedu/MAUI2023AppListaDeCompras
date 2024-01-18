using AppListaDeCompras.Libraries.Services;
using AppListaDeCompras.Libraries.Utilities;
using AppListaDeCompras.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaDeCompras.ViewModels
{
    [QueryProperty(nameof(User), "usuario")]
    public partial class AccessCodePageViewModel : ObservableObject
    {
        
        [ObservableProperty]
        private User user;

        [ObservableProperty]
        private string accessCode;

        [RelayCommand]
        private async Task VerifyAccessCode()
        {
            if(AccessCode == User.AccessCodeTemp)
            {
                var finalDate = User.AccessCodeTempCreatedAt.AddMinutes(5);

                if(DateTime.UtcNow > finalDate)
                {
                    await App.Current!.MainPage!.DisplayAlert("Alerta!", "Código de acesso expirado!", "Ok");
                    return;
                }

                UserLoggedManager.SetUser(User);

                WeakReferenceMessenger.Default.Send("Logado");

                TransferAllListToBuyAnonymousToUserLogged(User);

                await AppShell.Current.GoToAsync("../");
            }
            else
            {
                await App.Current!.MainPage!.DisplayAlert("Alerta!", "Código de acesso inválido!", "Ok");
                AccessCode = string.Empty;
                return;
            }
            
        }

        private void TransferAllListToBuyAnonymousToUserLogged(User userLogged)
        {
            var realm = MongoDBAtlasService.GetMainThreadRealm();
            var userLoggedId = new ObjectId(MongoDBAtlasService.CurrentUser.Id);
            var listToBuy = realm.All<ListToBuy>().Where(a => a.AnonymousUserId == userLoggedId).ToList();

            realm.WriteAsync(() =>
            {
                foreach (var list in listToBuy)
                {
                    list.AnonymousUserId = default(ObjectId);
                    list.Users.Add(userLogged);
                }
            });
        }
    }
}
