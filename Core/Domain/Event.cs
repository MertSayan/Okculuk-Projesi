using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Event: Entity
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateAndTime { get; set; }

        public bool IsActive { get; set; }=true;
        public int UserId { get; set; }
        public User User { get; set; }
        public List<EventUser> EventsAndUsers { get; set; }

    }
}
