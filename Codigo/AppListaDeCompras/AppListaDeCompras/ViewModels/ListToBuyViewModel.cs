using AppListaDeCompras.Models;
using AppListaDeCompras.Views.Popups;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mopups.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaDeCompras.ViewModels
{
    public partial class ListToBuyViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ListToBuy> _listToBuy;
        public ListToBuyViewModel() {
            ListToBuy = new ObservableCollection<ListToBuy>()
            {
                new ListToBuy()
                {
                    Name = "Minha lista",
                    Users = new List<User>()
                    {
                        new User { Name = "Elias Ribeiro", Email = "elias@gmail.com" },
                        new User { Name = "Maria", Email = "maria@gmail.com" }
                    },
                    Products = new List<Product>()
                    {
                        new Product { Name = "Arroz 5Kg", Quantity = 10, QuantityUnitMeasure = Models.Enums.UnitMeasure.Un, Price = 28.99m, HasCaught = true },
                        new Product { Name = "Feijão 1Kg", Quantity = 3, QuantityUnitMeasure = Models.Enums.UnitMeasure.Un,Price = 7.49m, HasCaught = true },
                        new Product { Name = "Leite condensado", Quantity = 1, QuantityUnitMeasure = Models.Enums.UnitMeasure.Un, Price = 6.29m },
                        new Product { Name = "Coxão Mole", Quantity = 1.5m, QuantityUnitMeasure = Models.Enums.UnitMeasure.Kg, Price = 29.80m },
                        new Product { Name = "Alcatara", Quantity = 1.5m, QuantityUnitMeasure = Models.Enums.UnitMeasure.Kg }
                    }
                },
                new ListToBuy()
                {
                    Name = "Minha lista 2",
                    Users = new List<User>()
                    {
                        new User { Name = "Elias Ribeiro", Email = "elias@gmail.com" }
                    },
                    Products = new List<Product>()
                    {
                        new Product { Name = "Arroz 5Kg", Quantity = 2, Price = 36.99m, HasCaught = true },
                        new Product { Name = "Feijão 1Kg", Quantity = 2, Price = 8.49m, HasCaught = true },
                        new Product { Name = "Leite condensado", Quantity = 1, Price = 6.29m, HasCaught = true }
                    }
                }
            };
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
