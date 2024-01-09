using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaDeCompras.Models
{
    public partial class ListToBuy : IRealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("name")]
        public string Name { get; set; } = string.Empty;

        [MapTo("products")]
        public IList<Product> Products { get; }
        
        [MapTo("users")]
        public IList<User> Users { get; }

        [MapTo("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

    }
}
