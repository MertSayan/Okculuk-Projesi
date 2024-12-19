using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.VisibleEvents.Commands
{
    public class CreateVisibleEventCommand:IRequest
    {
        public int EventId { get; set; }
        public List<int> UserId { get; set; }
    }
}
