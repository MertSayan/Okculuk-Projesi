using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkculukDto.EventDtos
{
    public class ResultEventsByStatusForUser
    {

        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateAndTime { get; set; }
        public string UserName { get; set; }

    }
}
