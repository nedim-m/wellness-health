using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.RabbitMQ
{
    public class NotificationData
    {
        public int? UserID { get; set; }
        public string? Email { get; set; } = null!;
        public string? TretmentName { get; set; } = null!;
        public bool? Status { get; set; }
        public bool SentFromMobile { get; set; }
        public string Date { get; set; } = null!;

        public string Time { get; set; } = null!;
    }
}
