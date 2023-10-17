using AutoMapper;
using BlazorSozluk.Api.Application.Interfaces.Repositories;
using BlazorSozluk.Common.Models.RequestModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorSozluk.Common;
using BlazorSozluk.Common.Events.User;
using BlazorSozluk.Common.Infrastructure;
using BlazorSozluk.Common.Infrastructure.Exceptions;

namespace BlazorSozluk.Api.Application.Features.Commands.User.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existUser = await userRepository.GetSingleAsync(i => i.EmailAddress == request.EmailAddress);

            if (existUser != null)
                throw new DatabaseValidationException("User already exist");

            var dbUser = mapper.Map<Domain.Models.User>(request);

            var rows = await userRepository.AddAsync(dbUser);

            // Email Changed-Created
            if (rows > 0)
            {
                var @event = new UserEmailChangedEvent()
                {
                    OldEmailAddress = null,
                    NewEmailAddress = dbUser.EmailAddress
                };

                QueueFactory.SendMessageToExchange(SozlukConstants.UserExchangeName, SozlukConstants.DefaultExchangeType, SozlukConstants.UserEmailChangedQueueName, @event);
            }

            return dbUser.Id;
        }
    }
}
