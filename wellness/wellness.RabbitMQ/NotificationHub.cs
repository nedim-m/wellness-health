using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.RabbitMQ
{
    public class NotificationHub : Hub
    {
        public async Task ReceiveNotification(string message)
        {
            // Implementirajte logiku slanja notifikacija klijentima
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}
