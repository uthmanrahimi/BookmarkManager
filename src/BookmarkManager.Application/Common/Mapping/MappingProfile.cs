using AutoMapper;

using BookmarkManager.Application.Features;
using BookmarkManager.Domain.Entities;

using System;
using System.Linq;
using System.Reflection;

namespace BookmarkManager.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookmarkCommand, Bookmark>()
                .ForMember(dest => dest.Categories, src => src.MapFrom(x => x.Categories.Select(c => new BookmarkCategory { CategoryId = c })));
            CreateMap<UpdateBookmarkCommand, Bookmark>()
                .ForMember(dest => dest.Categories, src => src.MapFrom(x => x.Categories.Select(c => new BookmarkCategory { CategoryId = c })));
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<CreateBookmarkV2Command, Bookmark>().ForMember(dest => dest.Categories, src => src.Ignore());

            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>))).ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod("Mapping")
                    ?? type.GetInterface("IMapFrom`1").GetMethod("Mapping");

                methodInfo?.Invoke(instance, new object[] { this });

            }
        }


    }
}
