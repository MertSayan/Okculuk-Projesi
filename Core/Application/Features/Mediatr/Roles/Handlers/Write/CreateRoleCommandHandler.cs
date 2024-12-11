using Application.Features.Mediatr.Roles.Commands;
using Application.Interfaces.RoleInterface;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Roles.Handlers.Write
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public CreateRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleRepository.CreateRole(new Role
            {
                RoleName = request.RoleName,
            });
        }
    }
}
