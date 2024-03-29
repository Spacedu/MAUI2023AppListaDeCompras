﻿using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AppListaDeCompras.Libraries.Utilities;

namespace AppListaDeCompras.Models
{
    public partial class User : IRealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }

        [MapTo("name")]
        public string Name { get; set; } = string.Empty;
        
        [MapTo("email")]
        public string Email { get; set; } = string.Empty;

        [MapTo("access_code_temp")]
        public string AccessCodeTemp { get; set; } = string.Empty;

        [MapTo("access_code_temp_created_at")]
        public DateTimeOffset AccessCodeTempCreatedAt { get; set; }

        [MapTo("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
