using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User: Entity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
        public Role Role { get; set; }

        public List<Event> Events { get; set; }
        public List<EventUser> EventsAndUsers { get; set; }

        public int? RegionId { get; set; }
        public Region Region { get; set; }

        

    }
}
