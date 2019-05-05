using System;
using System.Collections.Generic;
using AutoMapper;

namespace SuggeBook.Framework
{
    public static class CustomAutoMapper
    {
        public static T2 Map<T1, T2>(T1 source)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<T1, T2>());

                var iMapper = config.CreateMapper();

                return iMapper.Map<T1, T2>(source);
            }
            catch (Exception)
            {
                throw new Exception($"Error matching {typeof(T1).Name} in {typeof(T2).Name}");
            }
        }

        public static IList<T2> MapLists<T1, T2>(IList<T1> source)
        {
            try
            {
                var result = new List<T2>();

                if (source != null)
                {
                    foreach (var t1 in source)
                    {
                        result.Add(Map<T1, T2>(t1));
                    }
                }

                return result;
            }

            catch (Exception)
            {
                throw new Exception($"Error matching lists of {typeof(T1).Name} in {typeof(T2).Name}");
            }
        }
    }
}
