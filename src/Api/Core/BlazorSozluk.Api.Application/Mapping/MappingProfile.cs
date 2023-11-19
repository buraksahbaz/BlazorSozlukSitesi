﻿using AutoMapper;
using BlazorSozluk.Api.Domain.Models;
using BlazorSozluk.Common.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorSozluk.Common.Models.RequestModels;

namespace BlazorSozluk.Api.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginUserViewModel>()   
                .ReverseMap();

            CreateMap<CreateUserCommand, User>();

            CreateMap<UpdateUserCommand, User>();

            CreateMap<User, UserDetailViewModel>()
                .ReverseMap();


            CreateMap<CreateEntryCommand, Entry>()
                .ReverseMap();

            CreateMap<Entry, GetEntriesViewModel>()
                .ForMember(x =>x.CommentCount, 
                    y=> y.MapFrom(z => z.EntryComments.Count));

            CreateMap<CreateEntryCommentCommand, EntryComment>()
                .ReverseMap();



        }
    }
}
