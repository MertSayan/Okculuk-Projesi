using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Events.Commands
{
    public class CreateEventCommand:IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateAndTime { get; set; }
        public bool IsActive { get; set; } = true;
        public int UserId { get; set; }
    }
}
