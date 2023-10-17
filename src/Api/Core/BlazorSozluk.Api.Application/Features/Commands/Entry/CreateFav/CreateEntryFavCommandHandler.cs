using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorSozluk.Common;
using BlazorSozluk.Common.Events.Entry;
using BlazorSozluk.Common.Infrastructure;
using MediatR;

namespace BlazorSozluk.Api.Application.Features.Commands.Entry.CreateFav
{
    public class CreateEntryFavCommandHandler: IRequestHandler<CreateEntryFavCommand, bool>
    {
        public async Task<bool> Handle(CreateEntryFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName:SozlukConstants.FavExchangeName,
                exchangeType:SozlukConstants.DefaultExchangeType,
                queueName: SozlukConstants.CreateEntryFavQueueName,
                obj: new CreateEntryFavEvent
                {
                    EntryId = request.EntryId.Value,
                    CreatedBy = request.UserId.Value

                });

            return await Task.FromResult(true);
        }
    }
}
