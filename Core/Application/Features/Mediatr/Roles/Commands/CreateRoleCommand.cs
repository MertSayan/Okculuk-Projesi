using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Roles.Commands
{
    public class CreateRoleCommand:IRequest
    {
        public string RoleName { get; set;}
    }
}
