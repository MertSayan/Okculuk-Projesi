using Application.Features.Mediatr.Users.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Queries
{
    public class GetUserByIdForAdminQuery:IRequest<GetUserByIdForAdminQueryResuslt>
    {
        public int Id { get; set; }

        public GetUserByIdForAdminQuery(int id)
        {
            Id = id;
        }
    }
}
