using AppListaDeCompras.Models.Enums;
using CommunityToolkit.Mvvm.ComponentModel;
using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaDeCompras.Models
{
    public partial class Product : IRealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; }
        
        [MapTo("name")]
        public string Name { get; set; } = string.Empty;

        [MapTo("quantity")]
        public decimal Quantity { get; set; }

        [MapTo("quantity_unit_measure")]
        public int QuantityUnitMeasure { get; set; }

        [MapTo("price")]
        public decimal Price { get; set; }
        
        private bool hasCaught = false;

        [MapTo("has_caught")]
        public bool HasCaught {
            get { return hasCaught; }
            set { hasCaught = value; OnPropertyChanged(nameof(HasCaught)); }
        }

        [MapTo("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
