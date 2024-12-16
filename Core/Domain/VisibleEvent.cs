using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class VisibleEvent
    {
        public int VisibleEventId { get; set; }
        public int EventId { get; set; }
        public Event Events { get; set; }
        public int UserId { get; set; }
        public User Users { get; set; }
        public bool IsAnswered { get; set; }


    }
}
