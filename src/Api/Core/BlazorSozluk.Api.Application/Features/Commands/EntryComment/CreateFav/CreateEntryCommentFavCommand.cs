using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BlazorSozluk.Api.Application.Features.Commands.EntryComment.CreateFav
{
    public class CreateEntryCommentFavCommand: IRequest<bool>
    {
        public Guid EntryCommentId { get; set; }

        public Guid UserId { get; set; }

        public CreateEntryCommentFavCommand(Guid userId, Guid entryCommentId)
        {
            UserId = userId;
            EntryCommentId = entryCommentId;
        }
    }
}
