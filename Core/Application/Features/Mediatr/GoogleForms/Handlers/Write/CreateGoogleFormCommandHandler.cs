using Application.Features.Mediatr.GoogleForms.Commands;
using Application.Interfaces.GoogleFormInterface;
using MediatR;

namespace Application.Features.Mediatr.GoogleForms.Handlers.Write
{
    public class CreateGoogleFormCommandHandler : IRequestHandler<CreateGoogleFormCommand>
    {
        private readonly IGoogleFormRepository _googleFormRepository;

        public CreateGoogleFormCommandHandler(IGoogleFormRepository googleFormRepository)
        {
            _googleFormRepository = googleFormRepository;
        }

        public async Task Handle(CreateGoogleFormCommand request, CancellationToken cancellationToken)
        {
            await _googleFormRepository.CreateGoogleForm(request.FormId);
        }
    }
}
