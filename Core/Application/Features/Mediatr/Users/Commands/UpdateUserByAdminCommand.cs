using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Commands
{
    public class UpdateUserByAdminCommand:IRequest
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
