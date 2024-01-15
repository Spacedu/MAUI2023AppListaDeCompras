﻿using AppListaDeCompras.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

                //TODO - Registrar o Login do Usuário.

            }
            else
            {
                await App.Current!.MainPage!.DisplayAlert("Alerta!", "Código de acesso inválido!", "Ok");
                AccessCode = string.Empty;
                return;
            }
            
        }
    }
}
