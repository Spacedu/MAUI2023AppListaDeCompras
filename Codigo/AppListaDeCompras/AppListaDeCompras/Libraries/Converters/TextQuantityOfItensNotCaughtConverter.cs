using AppListaDeCompras.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaDeCompras.Libraries.Converters
{
    public class TextQuantityOfItensNotCaughtConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null)
                return "Falta 0 item";
            IList<Product> products = (IList<Product>)values[0]!;

            int notCaughtCount = products.Where(a => a.HasCaught == false).Count();

            return notCaughtCount > 1 ? $"Faltam {notCaughtCount} itens" : $"Falta {notCaughtCount} item";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
