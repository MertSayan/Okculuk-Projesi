using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkculukDto.EventDtos
{
    public class ResutlEventsCountByUserId
    {

        public int AcceptedCount { get; set; }
        public int RejectedCount { get; set; }
        public int PendingCount { get; set; }

    }
}
