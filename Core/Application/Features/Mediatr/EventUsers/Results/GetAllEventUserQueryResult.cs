using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.EventUsers.Results
{
    public class GetAllEventUserQueryResult
    {
        public int EventUserId { get; set; }
        public string EventTitle { get; set; }
        public string UserName { get; set; }
        public DateTime BasvuruZamanı { get; set; }
        public string Status { get; set; }
    }
}
