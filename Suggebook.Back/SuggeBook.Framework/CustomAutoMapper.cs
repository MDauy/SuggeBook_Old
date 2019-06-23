using System;
using System.Collections.Generic;
using AutoMapper;

namespace SuggeBook.Framework
{
    public static class CustomAutoMapper
    {
        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());

                var iMapper = config.CreateMapper();
                return iMapper.Map<TSource, TDestination>(source);
            }
            catch (Exception)
            {
                throw new Exception($"Error matching {typeof(TSource).Name} in {typeof(TDestination).Name}");
            }
        }

        public static IList<TDestination> MapLists<TSource, TDestination>(IList<TSource> source)
        {
            try
            {
                var result = new List<TDestination>();

                if (source != null)
                {
                    foreach (var elt in source)
                    {
                        result.Add(Map<TSource, TDestination>(elt));
                    }
                }

                return result;
            }

            catch (Exception)
            {
                throw new Exception($"Error matching lists of {typeof(TSource).Name} in {typeof(TDestination).Name}");
            }
        }
    }
}
