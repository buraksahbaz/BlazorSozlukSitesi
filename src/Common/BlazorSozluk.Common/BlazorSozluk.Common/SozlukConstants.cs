﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Common
{
    public class SozlukConstants
    {
        public const string RabbitMQHost = "localhost";
        public const string UserName = "necil";
        public const string Password = "1234";
        public const string DefaultExchangeType = "direct";

        public const string UserExchangeName = "UserExchange";
        public const string UserEmailChangedQueueName = "UserEmailChangedQueue";

        public const string FavExchangeName = "FavExchange";
        public const string CreateEntryFavQueueName = "CreateEntryFavFavQueue";
        public const string CreateEntryCommentFavQueueName = "CreateEntryCommentFavQueue";
        public const string CreateEntryCommentVoteQueueName = "CreateEntryCommentVoteQueue";

        public const string DeleteEntryFavQueueName = "DeleteEntryFavQueue";
        public const string DeleteEntryCommentFavQueueName = "DeleteEntryCommentFavQueue";
        public const string DeleteEntryCommentVoteQueueName = "DeleteEntryCommentVoteQueue";

        public const string DeleteEntryVoteQueueName = "DeleteEntryVoteQueue";

        public const string VoteExchangeName = "VoteExchangeName";

        public const string CreateEntryVoteQueueName = "CreateEntryVoteQueue";

    }
}
