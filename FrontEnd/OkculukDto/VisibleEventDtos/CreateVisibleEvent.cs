using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkculukDto.VisibleEventDtos
{
    public class CreateVisibleEvent
    {
        public int EventId { get; set; }
        public List<int> UserId { get; set; }
    }
}
