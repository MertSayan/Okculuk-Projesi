using Application.Features.Mediatr.Roles.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Roles.Queries
{
    public class GetAllRoleQuery:IRequest<List<GetAllRoleQueryResult>>
    {
        
    }
}
