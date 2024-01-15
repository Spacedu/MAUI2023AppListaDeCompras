using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using AppListaDeCompras.Models;

namespace AppListaDeCompras.Libraries.Utilities
{
    public class Email
    {
        public static void SendMailWithAccessCode(User user)
        {
            var smtp = App.Current!.MainPage!.Handler!.MauiContext!.Services.GetRequiredService<SmtpClient>();

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("elias.ribeiro.s@gmail.com");
            msg.To.Add(user.Email);
            msg.Subject = "App Lista de Compras - Código de Acesso";
            msg.Body = $"Seu código de acesso é {user.AccessCodeTemp}";

            smtp.Send(msg);
        }
    }
}
