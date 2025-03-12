using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.GoogleForms.Results
{
    public class GetGoogleFormQueryResult
    {
        public int GoogleFormId { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IsJoin { get; set; }
        public string? RejectedReason { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
