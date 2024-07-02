using SisRestaurant.Infra.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Infra.Services.Notification
{
    public interface INotificationSender
    {
        Task Send(User user, string message, string? subject = null);
    }
}
