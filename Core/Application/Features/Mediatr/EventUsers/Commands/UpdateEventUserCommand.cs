using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.EventUsers.Commands
{
    public class UpdateEventUserCommand:IRequest
    {
        public int EventUserId { get; set; }
        public string Status { get; set; } // "Pending", "Approved", "Rejected"
    }
}
