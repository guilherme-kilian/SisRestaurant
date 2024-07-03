using Microsoft.Extensions.Options;
using SisRestaurant.Infra.Domain.Users;
using SisRestaurant.Models;
using System.Net;
using System.Net.Mail;

namespace SisRestaurant.Infra.Services.Notification
{
    public class EmailSender : INotificationSender
    {
        private readonly SmtpClient _smtpClient;
        private readonly AppSettings _appSettings;

        public EmailSender(SmtpClient client, IOptions<AppSettings> options)
        {
            _smtpClient = client;
            _appSettings = options.Value;
        }

        public Task Send(User user, string message, string? subject = null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(user.Email);

            return _smtpClient.SendMailAsync(new()
            {
                Body = message,
                From = new MailAddress(_appSettings.Mail.Email, _appSettings.Mail.Name),
                To = { user.Email },
                Subject = subject,
            });
        }
    }
}
