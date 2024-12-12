using Application.Constants;
using Application.Enums;
using Application.Features.Mediatr.Roles.Commands;
using Application.Interfaces.RoleInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Roles.Handlers.Write
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public UpdateRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role=await _roleRepository.GetRoleById(request.RoleId);
            if (role != null)
            {
                role.RoleName=request.RoleName;
                await _roleRepository.UpdateRole(role);
            }
            else
                throw new Exception(Messages<Rol>.EntityNotFound);
        }
    }
}
