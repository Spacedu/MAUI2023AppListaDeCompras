using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace AppListaDeCompras.Libraries.Utilities
{
    public class Email
    {
        public static void SendMailWithAccessCode()
        {
            var smtp = App.Current!.MainPage!.Handler!.MauiContext!.Services.GetRequiredService<SmtpClient>();

        }
    }
}
