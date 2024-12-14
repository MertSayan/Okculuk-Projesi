﻿using Application.Features.Mediatr.Users.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Queries
{
    public class GetAllUserByEventIdQuery:IRequest<List<GetAllUserByEventIdQueryResult>>
    {
        public int EventId { get; set; }

        public GetAllUserByEventIdQuery(int eventId)
        {
            EventId = eventId;
        }
    }
}
