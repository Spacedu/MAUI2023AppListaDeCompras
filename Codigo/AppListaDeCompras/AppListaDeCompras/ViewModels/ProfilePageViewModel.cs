using AppListaDeCompras.Libraries.Services;
using AppListaDeCompras.Libraries.Utilities;
using AppListaDeCompras.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using FluentValidation.Results;
using MongoDB.Bson;
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
        private bool isLogged;
        [ObservableProperty]
        private string textUserLogged;

        [ObservableProperty]
        private User user;

        public ProfilePageViewModel()
        {
            user = new User();
            GetLoggedUserMessage();

            WeakReferenceMessenger.Default.Register(string.Empty, (object obj, string str) => {
                GetLoggedUserMessage();
            });
        }

        private void GetLoggedUserMessage()
        {
            IsLogged = UserLoggedManager.ExistsUser();
            if (IsLogged) { 
                var user = UserLoggedManager.GetUser();
                TextUserLogged = $"Usuário logado! {user.Name} ({user.Email})";
            }
        }
        [RelayCommand]
        private async void Logout()
        {
            UserLoggedManager.RemoveUser();
            User = new User();
            IsLogged = false;
        }

        [RelayCommand]
        private async void NavigateToAccessCodePage()
        {
            //TODO - Validar dados
            var realm = MongoDBAtlasService.GetMainThreadRealm();
            var userDb = realm.All<User>().Where(a=>a.Email == User!.Email.Trim().ToLower()).FirstOrDefault();

            

            if (userDb == null)
            {   
                await realm.WriteAsync(() => {
                    User.AccessCodeTemp = Text.GerarNumeroAleatorio().ToString();
                    User.AccessCodeTempCreatedAt = DateTime.UtcNow;
                    User.CreatedAt = DateTime.UtcNow;
                    User.Id = ObjectId.GenerateNewId();
                    realm.Add(User);
                });

                Libraries.Utilities.Email.SendMailWithAccessCode(User);
            }
            else
            {
                
                await realm.WriteAsync(() => {
                    User.Id = userDb.Id;
                    User.CreatedAt = userDb.CreatedAt;
                    User.Name = userDb.Name;
                    User.AccessCodeTemp = Text.GerarNumeroAleatorio().ToString();
                    User.AccessCodeTempCreatedAt = DateTime.UtcNow;
                    realm.Add(User, update: true);
                });

                Libraries.Utilities.Email.SendMailWithAccessCode(User);
            }

            var parameters = new Dictionary<string, object>();
            parameters.Add("usuario", User);
            await Shell.Current.GoToAsync("//Profile/AccessCode", parameters);
        }
    }
}
