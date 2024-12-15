using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkculukDto.UserEventDtos
{
    public class CreateUserEvent
    {
        public int EventId { get; set; }
        public int UserId { get; set; }

        public string Status { get; set; }
    }
}
