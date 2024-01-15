using AppListaDeCompras.Libraries.Services;
using AppListaDeCompras.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaDeCompras.ViewModels
{
    public partial class ProfilePageViewModel : ObservableObject
    {
        [ObservableProperty]
        private User user;

        public ProfilePageViewModel()
        {
            user = new User();
        }

        [RelayCommand]
        private async void NavigateToAccessCodePage()
        {
            //TODO - Validar dados


            
            var realm = MongoDBAtlasService.GetMainThreadRealm();
            var userDb = realm.All<User>().FirstOrDefault(a=>a.Email == User!.Email.Trim().ToLower());

            if (userDb == null)
            {
                //TODO - Se Não existir usuário criar um novo e emitir um novo AccessCode;

                //TODO - Gerar AccessCode
                User.AccessCodeTemp = "1234";
                User.AccessCodeTempCreatedAt = DateTime.UtcNow;

                //TODO - Enviar o AccessCode por e-mail


                await realm.WriteAsync(() => {
                    realm.Add(User);
                });
            }
            else
            {
                //TODO - Se usuário existe emitir novo AccessCode e atualiza o nome;


                //TODO - Gerar AccessCode
                User.AccessCodeTemp = "1234";
                User.AccessCodeTempCreatedAt = DateTime.UtcNow;
                
                //TODO - Enviar o AccessCode por e-mail

                await realm.WriteAsync(() => {
                    realm.Add(User, update: true);
                });
            }

            var parameters = new Dictionary<string, object>();
            parameters.Add("usuario", User);
            await Shell.Current.GoToAsync("//Profile/AccessCode", parameters);
        }
    }
}
