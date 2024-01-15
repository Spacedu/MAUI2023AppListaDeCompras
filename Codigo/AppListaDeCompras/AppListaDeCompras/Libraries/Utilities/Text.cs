using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaDeCompras.Libraries.Utilities
{
    public class Text
    {
        static List<int> random_caches = new List<int>();
        public static int GerarNumeroAleatorio()
        {
            // não é necessário colocar o milissegundo para a semente
            // a semente gerada é com base em Environment.TickCount
            Random a = new Random();
            // para quê isso? é realmente inútil sendo que só irá atrasar em 1ms a semente
            //Thread.Sleep(1);

            // obtemos nosso número aleatório
            int c = a.Next(10000, 99999);
            // verifica se o número está em cache
            while (random_caches.Contains(c)) c = a.Next(10000, 99999);
            // adiciona o número ao cache
            random_caches.Add(c);
            // retorna
            return c;
        }
    }
}
