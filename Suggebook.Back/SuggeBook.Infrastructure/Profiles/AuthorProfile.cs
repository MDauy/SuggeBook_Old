﻿using AutoMapper;
using MongoDB.Bson;
using SuggeBook.Domain.Model;
using SuggeBook.Infrastructure.Documents;
using static SuggeBook.Infrastructure.Documents.BookDocument;

namespace SuggeBook.Infrastructure.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDocument>()
                .ForMember(document => document.Oid, opt => opt.MapFrom(dest => ObjectId.Parse(dest.Id)));
            CreateMap<AuthorDocument, Author>()
                .ForMember(author => author.Id, opt => opt.MapFrom(authorDocument => authorDocument.Oid.ToString()));
            CreateMap<Author, BookAuthorDocument>()
                .ForMember(document => document.Oid, opt => opt.MapFrom(dest => ObjectId.Parse(dest.Id)));
            CreateMap < BookAuthorDocument, Author > ()
                 .ForMember(model => model.Id, opt => opt.MapFrom(dest => dest.Oid.ToString()));
        }
    }
}
