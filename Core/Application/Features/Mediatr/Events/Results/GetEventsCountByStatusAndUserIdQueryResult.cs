using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Events.Results
{
    public class GetEventsCountByStatusAndUserIdQueryResult
    {
        public int AcceptedCount { get; set; }
        public int RejectedCount { get; set; }
        public int PendingCount { get; set; }
    }
}
