using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IS_Doc_Server.Classes.Log
{
    public static class MailManager
    {

        /// <summary>
        /// Отправка письма на почтовый ящик C# mail send
        /// </summary>
        /// <param name="smtpServer">Имя SMTP-сервера</param>
        /// <param name="from">Адрес отправителя</param>
        /// <param name="password">пароль к почтовому ящику отправителя</param>
        /// <param name="mailto">Адрес получателя</param>
        /// <param name="caption">Тема письма</param>
        /// <param name="message">Сообщение</param>
        /// <param name="attachFile">Присоединенный файл</param>
        private static void SendMail(string smtpServer, string from, string password,
            string mailto, string caption, string message, string attachFile = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception e)
            {
                Logger.Error("<MailManager::SendMail> " + e.Message + "\n" + " smtpServer =" + smtpServer + " from =" + from + " psw =" + password + " mailto =" + mailto + " caption =" + caption + " message =" + message + " attachFile =" + attachFile + "\n" + e.StackTrace);
                throw new Exception("Mail.Send: " + e.Message);
            }
        }

        /// <summary>
        /// Отправка письма с текущим логом на мой ящик
        /// </summary>
        /// <param name="message">Сообщение</param>
        public static void SendEmail(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new Exception("Пустое Email сообщение");
            }
            SendMail("smtp.yandex.ru", "mr.workbox@ya.ru", "M2zsJGMYWk", "vsb95@mail.ru", "IS_Doc_Server" + UpdateManager.LocalVersion, message, "log.txt");
        }

    }
}
