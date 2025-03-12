using Application.Features.Mediatr.GoogleForms.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.GoogleForms.Queries
{
    public class GetGoogleFormQuery:IRequest<List<GetGoogleFormQueryResult>>
    {
    }
}
