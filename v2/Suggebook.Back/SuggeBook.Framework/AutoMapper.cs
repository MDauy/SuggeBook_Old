using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Framework
{
    public static class CustomAutoMapper
    {
        public static T2 Map<T1, T2>(T1 source)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T1, T2>());

            var iMapper = config.CreateMapper();

            return iMapper.Map<T1, T2>(source);
        }

        public static List<T2> MapLists<T1, T2>(List<T1> source)
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
    }
}
