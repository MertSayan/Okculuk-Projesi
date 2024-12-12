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
    public class GetRoleByIDQueryHandler : IRequestHandler<GetRoleByIdQuery, GetRoleByIdQueryResult>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRoleByIDQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<GetRoleByIdQueryResult> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role=await _roleRepository.GetRoleById(request.Id);
            if (role != null)
            {
                return new GetRoleByIdQueryResult
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName,
                };
            }
            else
                return null;
            
        }
    }
}
