using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Roles.Commands
{
    public class RemoveRoleCommand:IRequest
    {
        public int RoleId { get; set; }

        public RemoveRoleCommand(int roleId)
        {
            RoleId = roleId;
        }
    }
}
