using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EventUser: Entity
    {
        public int EventUserId { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int UserId { get; set; } 
        public User User { get; set; }
        public DateTime BasvuruZamanı { get; set; }
        public string Status { get; set; } = "Pending"; // "Pending", "Approved", "Rejected"

    }
}
