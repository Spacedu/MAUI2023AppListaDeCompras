using AppListaDeCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppListaDeCompras.Libraries.Utilities
{
    public class UserLoggedManager
    {
        private static string _key = "storage.user";
        public static User GetUser()
        {
            var userAsString = Preferences.Get(_key, null);
            if(userAsString != null)
            {
                return JsonSerializer.Deserialize<User>(userAsString);
            }

            return null;
        }
        public static void SetUser(User user)
        {
            RemoveUser();

            Preferences.Set(_key, JsonSerializer.Serialize(user));
        }
        public static void RemoveUser()
        {
            if (ExistsUser())
                Preferences.Remove(_key);
        }
        public static bool ExistsUser()
        {
            return Preferences.ContainsKey(_key);
        }
    }
}
