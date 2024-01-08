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
    public partial class AccessCodePageViewModel : ObservableObject
    {
        [ObservableProperty]
        private User user;

        [RelayCommand]
        private void VerifyAccessCode()
        {
            throw new NotImplementedException();
        }
    }
}
