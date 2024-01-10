using AppListaDeCompras.Libraries.Services;
using AppListaDeCompras.Models;
using AppListaDeCompras.Models.Enums;
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

namespace AppListaDeCompras.ViewModels.Popups
{
    public partial class ListOfItemAddItemPageViewModel : ObservableObject
    {
        private Product? _product;
        public Product? Product { 
            get { return _product; } 
            set { 
                _product = value;
                ProductForm = new Product()
                {
                    Id = value.Id,
                    HasCaught = value.HasCaught,
                    CreatedAt = value.CreatedAt,
                    Name = value.Name,
                    Price = value.Price,
                    Quantity = value.Quantity,
                    QuantityUnitMeasure = value.QuantityUnitMeasure
                };
            } 
        }

        [ObservableProperty]
        private Product? productForm;


        [ObservableProperty]
        private string[] unitsMeasure;

        [ObservableProperty]
        private ListToBuy _list;

        public ListOfItemAddItemPageViewModel()
        {
            unitsMeasure = Enum.GetNames(typeof(UnitMeasure));
            Product = new Product();
            ProductForm = new Product();
        }
        [RelayCommand]
        private void Close()
        {
            MopupService.Instance.PopAsync();
        }

        [RelayCommand]
        private async Task Save()
        {
            //TODO - Validar os dados
            

            //TODO - Salvar as informações
            var realm = MongoDBAtlasService.GetMainThreadRealm();
            await realm.WriteAsync(() => { 
                if(Product!.Id == default(ObjectId))
                {
                    ProductForm!.Id = ObjectId.GenerateNewId();
                    ProductForm.CreatedAt = DateTime.UtcNow;

                    List.Products.Add(ProductForm);
                    realm.Add(List, update:false);
                    WeakReferenceMessenger.Default.Send(string.Empty);
                }
                else
                {
                    Product.Name = ProductForm!.Name;
                    Product.Quantity = ProductForm.Quantity;
                    Product.QuantityUnitMeasure = ProductForm.QuantityUnitMeasure;
                    Product.Price = ProductForm.Price;
                }
            });

            await MopupService.Instance.PopAsync();
        }
    }
}
