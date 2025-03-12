using Application.Features.Mediatr.GoogleForms.Queries;
using Application.Features.Mediatr.GoogleForms.Results;
using Application.Interfaces.GoogleFormInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.GoogleForms.Handlers.Read
{
    public class GetGoogleFormQueryHandler : IRequestHandler<GetGoogleFormQuery, List<GetGoogleFormQueryResult>>
    {
        private readonly IGoogleFormRepository _googleFormRepository;

        public GetGoogleFormQueryHandler(IGoogleFormRepository googleFormRepository)
        {
            _googleFormRepository = googleFormRepository;
        }

        public async Task<List<GetGoogleFormQueryResult>> Handle(GetGoogleFormQuery request, CancellationToken cancellationToken)
        {
            var values = await _googleFormRepository.GetAllGoogleForm();
            return values.Select(x => new GetGoogleFormQueryResult
            {
                CreatedDate=x.CreatedDate,
                EventId=x.EventId,
                GoogleFormId=x.GoogleFormId,
                IsJoin=x.IsJoin,
                Name=x.Name,
                Surname = x.Surname,
                RejectedReason =x.RejectedReason
            }).ToList();
        }
    }
}
