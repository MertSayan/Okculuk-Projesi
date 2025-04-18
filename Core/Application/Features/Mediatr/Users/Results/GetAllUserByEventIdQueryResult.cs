﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Results
{
    public class GetAllUserByEventIdQueryResult
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string RoleName { get; set; }
        public string Email { get; set; }

        public string Status { get; set; }
        
        public DateTime BasvuruZamani {  get; set; }
        public string RejectedReason { get; set; }
    }
}
