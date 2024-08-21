using Lms.ExternalServices.Classes;
using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Lms.ExternalServices.Interfaces;

namespace Lms.ExternalServices.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSetting _smtpSetting;

        public EmailService(IOptions<SmtpSetting> smtpSettings)
        {
            _smtpSetting = smtpSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            try
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpSetting.SenderEmail, _smtpSetting.SenderName),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(toEmail);
                using var smtpClient = new SmtpClient(_smtpSetting.Server, _smtpSetting.Port)
                {
                    EnableSsl = _smtpSetting.EnableSsl,
                    Credentials = new System.Net.NetworkCredential(_smtpSetting.SenderEmail, _smtpSetting.Password)
                };
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Could not send email", ex);
            }
        }
    }
}
