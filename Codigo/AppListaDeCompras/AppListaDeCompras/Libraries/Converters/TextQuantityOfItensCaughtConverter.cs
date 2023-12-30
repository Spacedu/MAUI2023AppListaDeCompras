using AppListaDeCompras.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaDeCompras.Libraries.Converters
{
    public class TextQuantityOfItensCaughtConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            List<Product> products = (List<Product>)value!;

            var caughtCount = products.Where(a => a.HasCaught == true).Count();

            return caughtCount > 0 ? $"{caughtCount} itens": $"{caughtCount} item";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
