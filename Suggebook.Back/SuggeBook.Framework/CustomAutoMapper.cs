using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SuggeBook.Framework
{
    public static class CustomAutoMapper
    {
        public static object Map(object source, Type typeDestination)
        {
            var destinationObject = new object();
            if (typeDestination == typeof(String))
            {
                destinationObject = source;
            }
            else
            {
                destinationObject = Activator.CreateInstance(typeDestination);
                foreach (var property in source.GetType().GetProperties())
                {
                    var destinationProperty = destinationObject.GetType().GetProperty(property.Name);
                    if (destinationProperty != null)
                    {
                        if (destinationProperty.PropertyType == property.PropertyType)
                        {
                            destinationProperty.SetValue(destinationObject, property.GetValue(source));
                        }
                        else
                        {
                            var sourceValue = property.GetValue(source);
                            if (sourceValue != null)
                            {
                                if (typeof(IEnumerable).IsAssignableFrom(sourceValue.GetType()))
                                {
                                    var listType = typeof(List<>);
                                    var sourceListType = property.PropertyType.GenericTypeArguments.First();
                                    var destinationListType = destinationProperty.PropertyType.GenericTypeArguments.First();
                                    var constructedListType = listType.MakeGenericType(destinationListType);
                                    var destinationList = Activator.CreateInstance(constructedListType) as IList;
                                    var sourceList = sourceValue as IList;
                                    foreach (var item in sourceList)
                                    {
                                        destinationList.Add(CustomAutoMapper.Map(item, destinationListType));
                                    }
                                    destinationProperty.SetValue(destinationObject, destinationList);
                                }
                                else
                                {
                                    var propertyValue = CustomAutoMapper.Map(property.GetValue(source), destinationProperty.PropertyType);
                                    destinationProperty.SetValue(destinationObject, propertyValue);
                                }
                            }
                        }
                        //if (typeof(ICollection<>).IsAssignableFrom(property.PropertyType))
                        //{
                        //    var property2 = source.GetType().GetProperty(property.Name);
                        //}
                    }
                }
            }
            return destinationObject;

        }

        public static TDestination Map<TDestination>(object source) where TDestination : new()
        {
            return ((TDestination)Map(source, typeof(TDestination)));
        }

        public static IEnumerable<TDestination> MapLists<TDestination>(IEnumerable<object> source) where TDestination : new()
        {
            List<TDestination> resultList = new List<TDestination>();
            foreach (var item in source)
            {
                resultList.Add(CustomAutoMapper.Map<TDestination>(item));
            }

            return resultList;
        }
    }
}
