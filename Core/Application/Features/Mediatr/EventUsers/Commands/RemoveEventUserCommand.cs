using MediatR;

namespace Application.Features.Mediatr.EventUsers.Commands
{
    public class RemoveEventUserCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveEventUserCommand(int id)
        {
            Id = id;
        }
    }
}
