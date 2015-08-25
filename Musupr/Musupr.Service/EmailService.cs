using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;

namespace Musupr.Service
{
    public class EmailService
    {
        public enum RESPONSE { INVALID = 800 }

        public bool EnviarEmail(string emailDest, string nomeDest, string assunto, string texto, bool isHTML = false)
        {
            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();

            m.From = new MailAddress("musupr@musupr.com", "MUSUPR");
            m.To.Add(new MailAddress(emailDest, nomeDest));
            //similarly BCC
            m.Subject = assunto;
            m.Body = texto;
            m.IsBodyHtml = isHTML;


            sc.Host = "mail.musupr.com";
            sc.Port = 587;
            sc.Credentials = new System.Net.NetworkCredential("musupr@musupr.com", "password@musupr952");
            sc.EnableSsl = false; // runtime encrypt the SMTP communications using SSL
            sc.Send(m);
            

            return true;
        }

        public bool EnviarEmailTrocarSenha(string emailDest, string nomeDest, string usuarioDest, string GUID) {

            string link = "http://musupr.com/#!/TrocarSenha/" + GUID;

            string textoEmail = "Olá, " + nomeDest + "." + "<br><br>"
                + "Foi feito um pedido para mudança de senha do seu usuário (" + usuarioDest[0] + "**...**" + usuarioDest[usuarioDest.Length - 1] + ") no MUSUPR." + "<br><br>"

                + "Se deseja realmente mudar a senha clique nesse link (ou cole na barra de endereços do seu navegador): <a href=\"" + link + "\">" + link + "</a>" + "<br><br>"
                + "Se não reconhece este e-mail, favor ignorar.";

            return EnviarEmail(emailDest, nomeDest, "Solicitação de troca de senha - MUSUPR", textoEmail, true);
        }
    }
}
