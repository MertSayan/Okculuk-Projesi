using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.GoogleForms.Commands
{
    public class CreateGoogleFormCommand:IRequest
    {
        public string FormId { get; set; }

        public CreateGoogleFormCommand(string formId)
        {
            FormId = formId;
        }
    }
}
