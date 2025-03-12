using Application.Features.Mediatr.EventUsers.Commands;
using Application.Interfaces.EventUserInterface;
using Application.Interfaces.GoogleFormInterface;
using Application.Interfaces.UserInterface;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.EventUsers.Handlers.Write
{
    public class CreateEventUserCommandHandler : IRequestHandler<CreateEventUserCommand>
    {
        private readonly IEventUserRepository _eventUserRepository;
        private readonly IGoogleFormRepository _googleFormRepository;
        private readonly IUserRepository _userRepository;

        public CreateEventUserCommandHandler(IEventUserRepository eventUserRepository, IGoogleFormRepository googleFormRepository, IUserRepository userRepository)
        {
            _eventUserRepository = eventUserRepository;
            _googleFormRepository = googleFormRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(CreateEventUserCommand request, CancellationToken cancellationToken)
        {
            var values = await _googleFormRepository.GetAllGoogleForm();
            var users = await _userRepository.GetAllUserAsync();



            for(int i=0;i< values.Count;i++)
            {

                var user = await _userRepository.GetByFilterAsync(u => u.Name == values[i].Name && u.Surname == values[i].Surname);


                await _eventUserRepository.CreateUserAsync(new EventUser
                {
                    BasvuruZamanı = values[i].CreatedDate,
                    EventId = values[i].EventId,
                    UserId = user.UserId,
                    Status = values[i].IsJoin,
                    RejectedReason = values[i].RejectedReason,
                });
            }

            await _googleFormRepository.DeleteDataTable();

            //await _eventUserRepository.CreateUserAsync(new EventUser
            //{
            //    BasvuruZamanı = DateTime.Now,
            //    EventId = request.EventId,
            //    UserId = request.UserId,
            //    Status = request.Status,
            //    RejectedReason = request.RejectedReason,
            //});

        }
    }
}
