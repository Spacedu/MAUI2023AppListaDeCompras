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
        public int Quantity { get; set; }
        //TODO - Trocar para Enum
        public string QuantityUnitMeasure { get; set; }
        public decimal Price { get; set; }
        [ObservableProperty]
        private bool hasCaught = false;
    }
}
