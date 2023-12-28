using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaDeCompras.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        //TODO - Trocar para Enum
        public string QuantityUnitMeasure { get; set; }
        public decimal Price { get; set; }
        public bool HasCaught { get; set; } = false;
    }
}
