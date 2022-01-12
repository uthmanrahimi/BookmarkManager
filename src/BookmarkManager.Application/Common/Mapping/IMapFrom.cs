﻿using AutoMapper;

namespace BookmarkManager.Application.Common
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
