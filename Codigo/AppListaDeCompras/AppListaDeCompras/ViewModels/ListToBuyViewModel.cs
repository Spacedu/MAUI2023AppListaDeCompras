using AppListaDeCompras.Models;
using CommunityToolkit.Mvvm.ComponentModel;
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
                        new Product {  },
                        new Product {  },
                        new Product {  }
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
                        new Product {  },
                        new Product {  },
                        new Product {  }
                    }
                }
            };
        }
    }
}
