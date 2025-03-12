using Application.Features.Mediatr.GoogleForms.Commands;
using Application.Interfaces.GoogleFormInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.GoogleForms.Handlers.Write
{
    public class DeleteGoogleFormCommandHandler : IRequestHandler<DeleteGoogleFormCommand>
    {
        private readonly IGoogleFormRepository _googleFormRepository;

        public DeleteGoogleFormCommandHandler(IGoogleFormRepository googleFormRepository)
        {
            _googleFormRepository = googleFormRepository;
        }

        public async Task Handle(DeleteGoogleFormCommand request, CancellationToken cancellationToken)
        {
            await _googleFormRepository.DeleteDataTable();
        }
    }
}
