using Microsoft.VisualBasic;
using System.Net;
using System.Net.Mail;

namespace wellness.RabbitMQ
{
    public class MailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;


        public MailService(string smtpServer = "smtp.gmail.com", int smtpPort = 587, string smtpUsername = "wellnes.centar.health@gmail.com", string smtpPassword = "nkli naol eubd pmmw")
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _smtpUsername = smtpUsername;
            _smtpPassword = smtpPassword;
        }

        public void SendEmail(string to, string subject, string body)
        {
            using (SmtpClient client = new SmtpClient(_smtpServer, _smtpPort))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                client.EnableSsl = true;

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpUsername),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(to);

                client.Send(mailMessage);
            }
        }

        public void SendMailNotification(NotificationData data)
        {

            string subject = "Potvrda o rezervaciji";
            string body = $"Poštovanje, Vaša rezervacija za tretman: <b>{data.TretmentName}</b> datuma: {data.Date} u {data.Time} je <b>ODOBRENA</b>. Možete provjeriti na našoj mobilnoj aplikaciji. Vidimo se u dogovoreno vrijeme. Lijep pozdrav. Wellness centar - Health";
            if (data!=null && data.Status==false)
                body=$"Poštovanje, Vaša rezervacija za tretman: <b>{data.TretmentName}</b> datuma: {data.Date} u {data.Time} je <b>ODBIJENA</b>. Možete provjeriti na našoj mobilnoj aplikaciji. Molimo Vas za razumijevanje i nadamo se da će te pronaći novi termin. Lijep pozdrav. Wellness centar - Health";


            if (data!.Email!=null)
            {
                SendEmail(data.Email, subject, body);
            }

        }
    }
}
