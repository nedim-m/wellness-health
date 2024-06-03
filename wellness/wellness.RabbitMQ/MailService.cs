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


        public MailService()
        {
          

            _smtpServer = Environment.GetEnvironmentVariable("SMTP_SERVER") ?? throw new ArgumentNullException("SMTP_SERVER environment variable is not set");
            if (!int.TryParse(Environment.GetEnvironmentVariable("SMTP_PORT"), out _smtpPort))
            {
                throw new ArgumentException("SMTP_PORT environment variable is not a valid integer");
            }
            _smtpUsername = Environment.GetEnvironmentVariable("SMTP_USERNAME") ?? throw new ArgumentNullException("SMTP_USERNAME environment variable is not set");
            _smtpPassword = Environment.GetEnvironmentVariable("SMTP_PASSWORD") ?? throw new ArgumentNullException("SMTP_PASSWORD environment variable is not set");

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
