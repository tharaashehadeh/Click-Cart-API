using ClickCart.Core.IRepositiers.IServieces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace ClickCart.Servieces
{
    public class EmailServieces : IEmailServieces
    {
        private readonly IConfiguration configuration;

        public EmailServieces(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        /*  public async Task SendEmailAsync(string toemail, string subject, string message)
          {


              var emailMessage = new MimeMessage();
              emailMessage.From.Add(new MailboxAddress("thara shehadeh", configuration["EmailSettings:FromEmail"]));
              emailMessage.To.Add(new MailboxAddress("", toemail));
              emailMessage.Subject = subject;
              emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message };

              var client = new SmtpClient();

              //  await client.ConnectAsync(configuration["EmailSettings:SmtpServer"], int.Parse(configuration["EmailSettings:Port"]), bool.Parse(configuration["EmailSettings:UseSSL"]));
              await client.ConnectAsync(configuration["EmailSettings:SmtpServer"], int.Parse(configuration["EmailSettings:Port"]), MailKit.Security.SecureSocketOptions.StartTls);
              client.ServerCertificateValidationCallback = (s, c, h, e) => true;
              await client.AuthenticateAsync(configuration["EmailSettings:FromEmail"], configuration["EmailSettings:Password"]);
              await client.SendAsync(emailMessage);
              await client.DisconnectAsync(true);
          }*/
        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Thara Shehadeh", configuration["EmailSettings:FromEmail"]));
            emailMessage.To.Add(new MailboxAddress("", toEmail));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message };

            try
            {
                using var client = new SmtpClient();

                // Bypass certificate validation for development purposes
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await client.ConnectAsync(configuration["EmailSettings:SmtpServer"],
                                          int.Parse(configuration["EmailSettings:Port"]),
                                          MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(configuration["EmailSettings:FromEmail"], configuration["EmailSettings:Password"]);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while sending email: {ex.Message}");
                throw;
            }
        }
    }
}
