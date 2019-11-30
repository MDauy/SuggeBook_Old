using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SuggeBook.Domain.Model;
using SuggeBook.Infrastructure.Documents;
using SuggeBook.ViewModels;
using System;
using System.Reflection;

namespace SuggeBook.IoC
{
    public static class AutoMapperDeclaration
    {
        public static void DeclareMaps(this IServiceCollection services)
        {
           services.AddAutoMapper(typeof(BaseModel), typeof(BaseViewModel), typeof(BaseDocument));
        }

        private static Assembly GetAssembly(Type type)
        {
            return Assembly.GetAssembly(type);
        }
    }
}
