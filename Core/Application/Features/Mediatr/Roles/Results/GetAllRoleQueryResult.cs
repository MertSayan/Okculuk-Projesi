using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Roles.Results
{
    public class GetAllRoleQueryResult
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }    
    }
}
