using AppListaDeCompras.Models.Enums;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaDeCompras.Models
{
    public partial class Product : ObservableObject
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public UnitMeasure QuantityUnitMeasure { get; set; }
        public decimal Price { get; set; }
        [ObservableProperty]
        private bool hasCaught = false;
    }
}
