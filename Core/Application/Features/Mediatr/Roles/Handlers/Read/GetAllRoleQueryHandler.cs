using Application.Features.Mediatr.Roles.Queries;
using Application.Features.Mediatr.Roles.Results;
using Application.Interfaces.RoleInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Roles.Handlers.Read
{
    public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, List<GetAllRoleQueryResult>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetAllRoleQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<GetAllRoleQueryResult>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository.GetAllRole();
            return roles.Select(x => new GetAllRoleQueryResult
            {
                RoleId=x.RoleId,
                RoleName=x.RoleName,    
            }).ToList();
        }
    }
}
