using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Results
{
    public class GetUserByMailAndPasswordQueryResult
    {
        public int UserId { get; set; }

        public string RoleName { get; set; }
        public bool IsExist { get; set; }
    }
}
