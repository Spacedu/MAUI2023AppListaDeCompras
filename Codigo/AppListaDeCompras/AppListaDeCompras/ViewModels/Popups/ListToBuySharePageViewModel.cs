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
        [RelayCommand]
        private void Close()
        {
            MopupService.Instance.PopAsync();
        }
    }
}
