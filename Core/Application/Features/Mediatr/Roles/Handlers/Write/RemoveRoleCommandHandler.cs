using Application.Constants;
using Application.Enums;
using Application.Features.Mediatr.Roles.Commands;
using Application.Interfaces.RoleInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Roles.Handlers.Write
{
    public class RemoveRoleCommandHandler : IRequestHandler<RemoveRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public RemoveRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task Handle(RemoveRoleCommand request, CancellationToken cancellationToken)
        {
            var role= await _roleRepository.GetRoleById(request.RoleId);
            if (role != null)
            {
                await _roleRepository.DeleteRole(role);
            }
            else
                throw new Exception(Messages<Rol>.EntityNotFound);
        }
    }
}
